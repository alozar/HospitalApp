using HospitalApp.Models.Api.ListViewModels.Options;
using HospitalApp.Models.Entities.Interfaces;
using HospitalApp.Services.Interfaces;
using System.Linq.Expressions;

namespace HospitalApp.Services
{
    public class ListEntityService<E> : IListEntityService<E> where E : IEntity
    {
        private readonly ParameterExpression pe = Expression.Parameter(typeof(E), "e");

        public List<int> GetIds(IQueryable<E> query, FilterOptions filter, OrderOptions orderOptions, PageOptions pageOptions)
        {
            query = QueryFilter(query, filter);
            query = QueryOrder(query, orderOptions);

            var count = query.Count();
            pageOptions.Count = count;
            pageOptions.PageTotal = count / pageOptions.PageSize + 1;

            query = QueryPage(query, pageOptions);

            return query.Select(i => i.Id).ToList();
        }

        public IQueryable<E> QueryFilter(IQueryable<E> query, FilterOptions filter)
        {
            var filterProps = filter.GetType().GetProperties();
            
            foreach (var prop in filterProps)
            {
                var value =  prop.GetValue(filter);
                if (value is not null)
                {
                    var type = Nullable.GetUnderlyingType(prop.PropertyType) // Убираем Nullable-обертку
                        ?? prop.PropertyType;
                    var property = Expression.Property(pe, prop.Name);
                    var constant = Expression.Constant(value, type);
                    if (type == typeof(string))
                    {
                        var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                        var containsMethodExp = Expression.Call(property, method, constant);
                        query = query.Where(Expression.Lambda<Func<E, bool>>(containsMethodExp, pe));
                    }
                    else
                    {
                        query = query.Where(Expression.Lambda<Func<E, bool>>(Expression.Equal(property, constant), pe));
                    }
                }
            };

            return query;
        }

        public IQueryable<E> QueryOrder(IQueryable<E> query, OrderOptions orderOptions)
        {
            if (orderOptions.Direction == OrderDirection.None)
            {
                return query;
            }
            
            var propExpression = Expression.Property(pe, orderOptions.Field);
            var convPropExpression = Expression.Convert(propExpression, typeof(object));

            if (orderOptions.Direction == OrderDirection.Asc) {
                return query.OrderBy(Expression.Lambda<Func<E, dynamic>>(convPropExpression, pe));
            }

            // OrderDirection.Desc
            return query.OrderByDescending(Expression.Lambda<Func<E, dynamic>>(convPropExpression, pe));
        }

        public IQueryable<E> QueryPage(IQueryable<E> query, PageOptions pageOptions)
        {
            return query
            .Skip((pageOptions.PageCurrent - 1) * pageOptions.PageSize)
            .Take(pageOptions.PageSize);
        }
    }
}

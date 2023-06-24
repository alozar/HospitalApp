using HospitalApp.Models.Api.ListViewModels.Options;
using HospitalApp.Models.Entities.Interfaces;
using HospitalApp.Services.Interfaces;

namespace HospitalApp.Services
{
    public class ListEntityService<E> : IListEntityService<E> where E : IEntity
    {
        public List<int> GetIds(IQueryable<E> query, FilterOptions filter, OrderOptions orderOptions, PageOptions pageOptions)
        {
            query = QueryFilter(query);
            query = QueryOrder(query, orderOptions);

            var count = query.Count();
            pageOptions.Count = count;
            pageOptions.PageTotal = count / pageOptions.PageSize + 1;

            query = QueryPage(query, pageOptions);

            return query.Select(i => i.Id).ToList();
        }

        public IQueryable<E> QueryFilter(IQueryable<E> query)
        {
            //Todo рефлексия
            return query;
        }

        public IQueryable<E> QueryOrder(IQueryable<E> query, OrderOptions orderOptions)
        {
            //Todo рефлексия
            return query;
        }

        public IQueryable<E> QueryPage(IQueryable<E> query, PageOptions pageOptions)
        {
            return query
            .Skip((pageOptions.PageCurrent - 1) * pageOptions.PageSize)
            .Take(pageOptions.PageSize);
        }
    }
}

using HospitalApp.Models.Api.ListViewModels.Options;
using HospitalApp.Models.Entities.Interfaces;

namespace HospitalApp.Services.Interfaces;

public interface IListEntityService<E> where E : IEntity
{
    List<int> GetIds(IQueryable<E> query, FilterOptions filter, OrderOptions orderOptions, PageOptions pageOptions);

    IQueryable<E> QueryFilter(IQueryable<E> query, FilterOptions filter);

    IQueryable<E> QueryOrder(IQueryable<E> query, OrderOptions orderOptions);

    IQueryable<E> QueryPage(IQueryable<E> query, PageOptions pageOptions);
}

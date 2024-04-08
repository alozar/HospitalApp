using HospitalApp.Models.Api.ListViewModels.Options;
using HospitalApp.Models.Entities.Interfaces;

namespace HospitalApp.Services.Interfaces;

public interface IListEntityService<E> where E : IEntity
{
    List<int> GetIds(IQueryable<E> query, FilterOptions filter, OrderOptions orderOptions, PageOptions pageOptions);

    void QueryFilter(ref IQueryable<E> query, FilterOptions filter);

    void QueryOrder(ref IQueryable<E> query, OrderOptions orderOptions);

    void QueryPage(ref IQueryable<E> query, PageOptions pageOptions);
}

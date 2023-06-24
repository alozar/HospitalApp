using HospitalApp.Models.Api.ListViewModels;
using HospitalApp.Models.Api.ListViewModels.Options;
using HospitalApp.Models.Api.ViewModels.Interfaces;

namespace HospitalApp.Services.Interfaces;

public interface IListViewModelService<E, F> where E : IViewModel where F : FilterOptions
{
    ListViewModel<E, F> Get(ListOptions<F> options);
}

using HospitalApp.Models.Api.ListViewModels.Options;
using HospitalApp.Models.Api.ViewModels.Interfaces;

namespace HospitalApp.Models.Api.ListViewModels;

public class ListViewModel<I, F> where I : IViewModel where F : FilterOptions
{
    public List<I> List { get; set; }

    public ListOptions<F> Options { get; set; }
}

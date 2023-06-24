using HospitalApp.Models.Api.ListViewModels.Options;

namespace HospitalApp.Models.Api.ListViewModels;

public class ListOptions<F> where F : FilterOptions
{
    public OrderOptions Order { get; set; }

    public PageOptions Page { get; set; }

    public F Filter { get; set; }
}

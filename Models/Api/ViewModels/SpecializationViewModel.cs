using HospitalApp.Models.Api.ViewModels.Interfaces;

namespace HospitalApp.Models.Api.ViewModels;

public class SpecializationViewModel : IViewModel
{
    public int Id { get; set; }

    public string Name { get; set; }
}

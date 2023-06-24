using HospitalApp.Models.Api.ViewModels.Interfaces;

namespace HospitalApp.Models.Api.ViewModels;

public class DoctorViewModel : IViewModel
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public short Cabinet { get; set; }

    public string Specialization { get; set; }

    public short? District { get; set; }
}

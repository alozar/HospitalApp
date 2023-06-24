using HospitalApp.Models.Api.ViewModels.Interfaces;

namespace HospitalApp.Models.Api.ViewModels;

public class CabinetViewModel : IViewModel
{
    public int Id { get; set; }

    public short Num { get; set; }
}

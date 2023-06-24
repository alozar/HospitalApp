using HospitalApp.Models.Api.ViewModels;

namespace HospitalApp.Services
{
    public interface INsiService
    {
        List<CabinetViewModel> GetCabinets();

        List<DistrictViewModel> GetDistricts();

        List<SpecializationViewModel> GetSpecializations();
    }
}

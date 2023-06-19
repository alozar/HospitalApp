using HospitalApp.Models.Dto;

namespace HospitalApp.Services
{
    public interface INsiService
    {
        List<CabinetDto> GetCabinets();

        List<DistrictDto> GetDistricts();

        List<SpecializationDto> GetSpecializations();
    }
}

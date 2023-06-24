namespace HospitalApp.Models.Dto;

public class DoctorDto
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public int CabinetId { get; set; }

    public int SpecializationId { get; set; }

    public int? DistrictId { get; set; }
}

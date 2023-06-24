namespace HospitalApp.Models.Dto;

public class PatientDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Patronymic { get; set; }

    public string Address { get; set; }

    public DateTime BirthdayDate { get; set; }

    public bool Gender { get; set; }

    public int? DistrictId { get; set; }
}

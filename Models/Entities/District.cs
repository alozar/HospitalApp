using HospitalApp.Models.Entities.Interfaces;

namespace HospitalApp.Models.Entities;

public partial class District : IEntity
{
    public int Id { get; set; }

    public short Num { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}

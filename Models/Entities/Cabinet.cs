using HospitalApp.Models.Entities.Interfaces;

namespace HospitalApp.Models.Entities;

public partial class Cabinet : IEntity
{
    public int Id { get; set; }

    public short Num { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}

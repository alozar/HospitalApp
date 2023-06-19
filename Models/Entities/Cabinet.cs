namespace HospitalApp.Models.Entities;

public partial class Cabinet
{
    public int Id { get; set; }

    public short Num { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}

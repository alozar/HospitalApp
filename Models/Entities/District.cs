namespace HospitalApp.Models.Entities;

public partial class District
{
    public int Id { get; set; }

    public short Num { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }
}

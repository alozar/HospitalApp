namespace HospitalApp.Models.Entities;

public partial class Specialization
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual Doctor? Doctor { get; set; }
}

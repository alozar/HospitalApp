using HospitalApp.Models.Entities;
using HospitalApp.Models.Entities.Interfaces;

namespace HospitalApp.Models;

public partial class Doctor : IEntity
{
    public int Id { get; set; }

    public string FullName { get; set; }

    public int CabinetId { get; set; }

    public int SpecializationId { get; set; }

    public int? DistrictId { get; set; }

    public virtual Cabinet Cabinet { get; set; } = null!;

    public virtual Specialization Specialization { get; set; } = null!;

    public virtual District District { get; set; } = null!;
}

﻿using HospitalApp.Models.Entities.Interfaces;

namespace HospitalApp.Models.Entities;

public partial class Specialization : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}

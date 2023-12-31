﻿using HospitalApp.Models.Entities.Interfaces;

namespace HospitalApp.Models.Entities;

public partial class Patient : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Address { get; set; } = null!;

    public DateTime BirthdayDate { get; set; }

    public bool Gender { get; set; }

    public int DistrictId { get; set; }

    public virtual District District { get; set; } = null!;
}

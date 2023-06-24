using HospitalApp.Models.Entities;
using HospitalApp.Models.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Models;

public partial class HospitalAppContext : DbContext
{
    public HospitalAppContext()
    {
    }

    public HospitalAppContext(DbContextOptions<HospitalAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HospitalApp;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CabinetConfiguration());

        modelBuilder.ApplyConfiguration(new DistrictConfiguration());

        modelBuilder.ApplyConfiguration(new DoctorConfiguration());

        modelBuilder.ApplyConfiguration(new PatientConfiguration());

        modelBuilder.ApplyConfiguration(new SpecializationConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

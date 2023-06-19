using HospitalApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalApp.Models.EntityTypeConfigurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patient");

            builder.HasKey(e => e.Id).HasName("PK_Patient");

            builder.Property(e => e.Address).HasMaxLength(100);

            builder.Property(e => e.BirthdayDate).HasColumnType("datetime");

            builder.Property(e => e.Name).HasMaxLength(30);

            builder.Property(e => e.Patronymic).HasMaxLength(30);

            builder.Property(e => e.Surname).HasMaxLength(30);

            builder.HasOne(d => d.District).WithOne(p => p.Patient)
                .HasForeignKey<Patient>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patient_District");
        }
    }
}

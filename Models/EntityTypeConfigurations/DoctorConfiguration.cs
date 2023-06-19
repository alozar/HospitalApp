using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalApp.Models.EntityTypeConfigurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctor");

            builder.HasKey(e => e.Id).HasName("PK_Doctor");

            builder.Property(e => e.FullName).HasMaxLength(100);

            builder.HasOne(d => d.Cabinet).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.CabinetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctor_Cabinet");

            builder.HasOne(d => d.District).WithOne(p => p.Doctor)
                .HasForeignKey<Doctor>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctor_District");

            builder.HasOne(d => d.Specialization).WithOne(p => p.Doctor)
                .HasForeignKey<Doctor>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Doctor_Specialization");
        }
    }
}

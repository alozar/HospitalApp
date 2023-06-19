using HospitalApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalApp.Models.EntityTypeConfigurations
{
    public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.ToTable("Specialization");

            builder.HasKey(e => e.Id).HasName("PK_Specialization");

            builder.Property(p => p.Name).IsRequired();
        }
    }
}

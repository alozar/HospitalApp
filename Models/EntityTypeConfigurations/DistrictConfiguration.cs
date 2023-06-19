using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HospitalApp.Models.Entities;

namespace HospitalApp.Models.EntityTypeConfigurations
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("District");

            builder.HasKey(e => e.Id).HasName("PK_District");

            builder.Property(p => p.Num).IsRequired();
        }
    }
}

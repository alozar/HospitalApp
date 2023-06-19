using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HospitalApp.Models.Entities;

namespace HospitalApp.Models.EntityTypeConfigurations
{
    public class CabinetConfiguration : IEntityTypeConfiguration<Cabinet>
    {
        public void Configure(EntityTypeBuilder<Cabinet> builder)
        {
            builder.ToTable("Cabinet");

            builder.HasKey(e => e.Id).HasName("PK_Cabinet");

            builder.Property(p => p.Num).IsRequired();
        }
    }
}

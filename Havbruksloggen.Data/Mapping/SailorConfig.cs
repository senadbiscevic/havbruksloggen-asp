using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Havbruksloggen.Entities;

namespace Havbruksloggen.Data.Mapping
{
    public class SailorConfig : IEntityTypeConfiguration<Sailor>
    {
        public void Configure(EntityTypeBuilder<Sailor> builder)
        {
            // Mapping for table
            builder.ToTable("Sailor", "Fishing");

            // Set key for entity
            builder.HasKey(x => x.SailorId);

            // Set mapping for columns
            builder.Property(p => p.SailorId).HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(p => p.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.Picture).HasColumnType("nvarchar(256)");
            builder.Property(p => p.BirthDate).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.Email).HasColumnType("nvarchar(256)").IsRequired();
            builder.Property(p => p.CertifiedUntil).HasColumnType("datetime").IsRequired();
        }
    }
}

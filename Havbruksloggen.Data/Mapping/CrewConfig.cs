using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Havbruksloggen.Entities;

namespace Havbruksloggen.Data.Mapping
{
    public class CrewConfig : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> builder)
        {
            // Mapping for table
            builder.ToTable("Crew", "Fishing");

            // Set key for entity
            builder.HasKey(x => x.CrewId);

            // Set mapping for columns
            builder.Property(p => p.CrewId).HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(p => p.BoatId).HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(p => p.SailorId).HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(p => p.Role).HasColumnType("smallint");

            builder
                .HasOne(p => p.Boat)
                .WithMany(b => b.BoatCrewCollection)
                .HasForeignKey(p => p.BoatId);

            builder
                .HasOne(p => p.Sailor)
                .WithMany(b => b.BoatCrewCollection)
                .HasForeignKey(p => p.SailorId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Havbruksloggen.Entities;

namespace Havbruksloggen.Data.Mapping
{
    public class BoatConfig : IEntityTypeConfiguration<Boat>
    {
        public void Configure(EntityTypeBuilder<Boat> builder)
        {
            // Mapping for table
            builder.ToTable("Boat", "Fishing");

            // Set key for entity
            builder.HasKey(x => x.BoatId);

            // Set mapping for columns
            builder.Property(p => p.BoatId).HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(p => p.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.Producer).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.BuildNumber).HasColumnType("nvarchar(15)").IsRequired();
            builder.Property(p => p.Loa).HasColumnType("decimal(8, 2)").IsRequired();
            builder.Property(p => p.B).HasColumnType("decimal(8, 1)").IsRequired();
            builder.Property(p => p.Picture).HasColumnType("nvarchar(256)");

        }
    }
}

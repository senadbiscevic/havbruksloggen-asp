using Microsoft.EntityFrameworkCore;
using Havbruksloggen.Data.Mapping;

namespace Havbruksloggen.Data
{
    public class HavbruksloggenContext : DbContext
    {
        public HavbruksloggenContext()
        {

        }

        public HavbruksloggenContext(DbContextOptions<HavbruksloggenContext> options)
            : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .ApplyConfiguration(new BoatConfig())
                .ApplyConfiguration(new SailorConfig())
                .ApplyConfiguration(new CrewConfig())
                ;

            new Seed(modelBuilder);
        }
    }
}

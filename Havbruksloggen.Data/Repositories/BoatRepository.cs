using System.Linq;
using System.Threading.Tasks;
using Havbruksloggen.Data.Contracts;
using Havbruksloggen.Entities;
using Microsoft.EntityFrameworkCore;

namespace Havbruksloggen.Data
{
    public class BoatRepository : Repository, IBoatRepository
    {
        public BoatRepository(HavbruksloggenContext dbContext)
            : base(dbContext) {}

        public IQueryable<Boat> GetBoats()
        {
            var query = from boat in DbContext.Set<Boat>()
                            .Include(x => x.BoatCrewCollection)
                                .ThenInclude(x => x.Sailor)
                        select boat;

            return query;
        }

        public async Task<Boat> GetBoatAsync(Boat entity)
            => await DbContext.Set<Boat>()
                .Include(x => x.BoatCrewCollection)
                    .ThenInclude(x => x.Sailor)
                .FirstOrDefaultAsync(item => item.BoatId == entity.BoatId);
    }
}

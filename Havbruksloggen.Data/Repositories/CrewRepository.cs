using Havbruksloggen.Data.Contracts;
using Havbruksloggen.Entities;
using System;
using System.Linq;

namespace Havbruksloggen.Data
{
    public class CrewRepository : Repository, ICrewRepository
    {
        public CrewRepository(HavbruksloggenContext dbContext)
            : base(dbContext) { }

        public IQueryable<Crew> GetBoatCrew(Guid? boatId = null)
            => DbContext.Set<Crew>().Where(item => item.BoatId == boatId);
    }
}

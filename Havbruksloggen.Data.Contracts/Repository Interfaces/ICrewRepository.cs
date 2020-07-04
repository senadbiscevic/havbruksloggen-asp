using System;
using System.Linq;
using Havbruksloggen.Entities;

namespace Havbruksloggen.Data.Contracts
{
    public interface ICrewRepository : IRepository
    {
        IQueryable<Crew> GetBoatCrew(Guid? boatId = null);

    }
}

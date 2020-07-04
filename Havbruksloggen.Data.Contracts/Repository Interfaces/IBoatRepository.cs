using System.Linq;
using System.Threading.Tasks;
using Havbruksloggen.Entities;

namespace Havbruksloggen.Data.Contracts
{
    public interface IBoatRepository : IRepository
    {
        IQueryable<Boat> GetBoats();

        Task<Boat> GetBoatAsync(Boat entity);

    }
}

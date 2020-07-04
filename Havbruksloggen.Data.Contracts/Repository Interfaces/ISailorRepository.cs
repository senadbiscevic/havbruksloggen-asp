using System.Linq;
using System.Threading.Tasks;
using Havbruksloggen.Entities;

namespace Havbruksloggen.Data.Contracts
{
    public interface ISailorRepository : IRepository
    {
        IQueryable<Sailor> GetSailors();

        Task<Sailor> GetSailorAsync(Sailor entity);
    }
}

using System.Linq;
using System.Threading.Tasks;
using Havbruksloggen.Data.Contracts;
using Havbruksloggen.Entities;
using Microsoft.EntityFrameworkCore;

namespace Havbruksloggen.Data
{
    public class SailorRepository : Repository, ISailorRepository
    {
        public SailorRepository(HavbruksloggenContext dbContext)
            : base(dbContext) { }

        public IQueryable<Sailor> GetSailors()
        {
            var query = from boat in DbContext.Set<Sailor>()
                        select boat;

            return query;
        }

        public async Task<Sailor> GetSailorAsync(Sailor entity)
            => await DbContext.Set<Sailor>().FirstOrDefaultAsync(item => item.SailorId == entity.SailorId);
    }
}

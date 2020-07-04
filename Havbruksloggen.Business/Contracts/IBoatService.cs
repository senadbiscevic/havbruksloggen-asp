using System;
using System.Threading.Tasks;
using Havbruksloggen.Business.Models;
using Havbruksloggen.Business.Responses;
using Havbruksloggen.Entities;

namespace Havbruksloggen.Business.Contracts
{
    public interface IBoatService : IService
    {
        Task<IListResponse<BoatData>> GetBoatsAsync();

        Task<ISingleResponse<BoatData>> GetBoatAsync(Guid? boatId = null);

        Task<ISingleResponse<BoatData>> CreateBoatAsync(Boat boat, Crew[] crewCollection);

        Task<ISingleResponse<BoatData>> UpdateBoatAsync(Boat boat, Crew[] crewCollection);

        Task<ISingleResponse<BoatData>> DeleteBoatAsync(Guid? boatId = null);
    }
}

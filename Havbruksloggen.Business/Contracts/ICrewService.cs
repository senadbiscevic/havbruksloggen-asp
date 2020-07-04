using System;
using System.Threading.Tasks;
using Havbruksloggen.Business.Models;
using Havbruksloggen.Business.Responses;
using Havbruksloggen.Entities;

namespace Havbruksloggen.Business.Contracts
{
    public interface ICrewService : IService
    {
        Task<IListResponse<CrewData>> GetCrewsAsync();

        Task<IListResponse<CrewData>> GetCrewAsync(Guid? crewId = null);

        Task<ISingleResponse<CrewData>> CreateCrewAsync(Crew crew);

        Task<ISingleResponse<CrewData>> UpdateCrewAsync(Crew crew);

        Task<ISingleResponse<CrewData>> DeleteCrewAsync(Guid? crewId = null);

    }
}

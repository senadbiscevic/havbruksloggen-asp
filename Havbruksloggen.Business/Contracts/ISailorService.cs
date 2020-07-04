using System;
using System.Threading.Tasks;
using Havbruksloggen.Business.Models;
using Havbruksloggen.Business.Responses;
using Havbruksloggen.Entities;

namespace Havbruksloggen.Business.Contracts
{
    public interface ISailorService : IService
    {
        Task<IListResponse<SailorData>> GetSailorsAsync();

        Task<ISingleResponse<SailorData>> GetSailorAsync(Guid? sailorId = null);

        Task<ISingleResponse<SailorData>> CreateSailorAsync(Sailor sailor);

        Task<ISingleResponse<SailorData>> UpdateSailorAsync(Sailor sailor);

        Task<ISingleResponse<SailorData>> DeleteSailorAsync(Guid? sailorId = null);
    }
}

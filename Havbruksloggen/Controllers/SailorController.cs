using System;
using System.Linq;
using System.Threading.Tasks;
using Havbruksloggen.Business.Contracts;
using Havbruksloggen.Core;
using Havbruksloggen.RequestModels;
using Havbruksloggen.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Havbruksloggen.Controllers
{
    [Route("[controller]")]
    public class SailorController : ApiControllerBase
    {
        protected ISailorService SailorService;

        public SailorController(ISailorService sailorService)
        {
            SailorService = sailorService;
        }

        protected override void Dispose(bool disposing)
        {
            SailorService?.Dispose();

            base.Dispose(disposing);
        }

        [HttpGet("Sailors")]
        public async Task<IActionResult> GetSailorsAsync()
        {
            var response = await SailorService.GetSailorsAsync();

            return response.ToHttpResponse();
        }

        [HttpGet("Sailor")]
        public async Task<IActionResult> GetSailorAsync(Guid? sailorId = null)
        {
            var response = await SailorService.GetSailorAsync(sailorId);

            return response.ToHttpResponse();
        }

        [HttpPost]
        [Route("Sailor")]
        public async Task<IActionResult> CreateSailorAsync([FromBody] SailorRequestModel value)
        {
            var response = await SailorService.CreateSailorAsync(value.GetSailor());

            return response.ToHttpResponse();
        }

        [HttpPut]
        [Route("Sailor")]
        public async Task<IActionResult> UpdateSailorAsync([FromBody] SailorRequestModel value)
        {
            var response = await SailorService.UpdateSailorAsync(value.GetSailor());

            return response.ToHttpResponse();
        }

        [HttpDelete]
        [Route("Sailor")]
        public async Task<IActionResult> RemoveSailorAsync(Guid? sailorId)
        {
            var response = await SailorService.DeleteSailorAsync(sailorId);

            return response.ToHttpResponse();
        }
    }
}
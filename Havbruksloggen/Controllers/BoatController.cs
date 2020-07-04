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
    public class BoatController : ApiControllerBase
    {
        protected IBoatService BoatService;

        public BoatController(IBoatService boatService)
        {
            BoatService = boatService;
        }

        protected override void Dispose(bool disposing)
        {
            BoatService?.Dispose();

            base.Dispose(disposing);
        }

        [HttpGet("Boats")]
        public async Task<IActionResult> GetBoatsAsync()
        {
            var response = await BoatService.GetBoatsAsync();

            return response.ToHttpResponse();
        }

        [HttpGet("Boat")]
        public async Task<IActionResult> GetBoatAsync(Guid? boatId = null)
        {
            var response = await BoatService.GetBoatAsync(boatId);

            return response.ToHttpResponse();
        }

        [HttpPost]
        [Route("Boat")]
        public async Task<IActionResult> CreateBoatAsync([FromBody] BoatRequestModel value)
        {
            var response = await BoatService.CreateBoatAsync(value.GetBoat(), value.GetCrew().ToArray());

            return response.ToHttpResponse();
        }

        [HttpPut]
        [Route("Boat")]
        public async Task<IActionResult> UpdateBoatAsync([FromBody] BoatRequestModel value)
        {
            var response = await BoatService.UpdateBoatAsync(value.GetBoat(), value.GetCrew().ToArray());

            return response.ToHttpResponse();
        }

        [HttpDelete]
        [Route("Boat")]
        public async Task<IActionResult> RemoveBoatAsync(Guid? boatId)
        {
            var response = await BoatService.DeleteBoatAsync(boatId);

            return response.ToHttpResponse();
        }
    }
}
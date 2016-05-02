using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using eFocus.Amar2000.API.Filters;
using eFocus.Amar2000.API.Hubs;
using eFocus.Amar2000.Core.Models.Climate;
using eFocus.Amar2000.Infrastructure.Services;
using Microsoft.AspNet.SignalR;

namespace eFocus.Amar2000.API.Controllers
{
    public class UpdateController : ApiController
    {
        private readonly ClimateService _climateService;
        public UpdateController(ClimateService climateService)
        {
            _climateService = climateService;
        }

        [HttpGet]
        [System.Web.Http.Authorize]
        [IdentityBasicAuthentication]
        public async Task<IHttpActionResult> Update()
        {
            var zones = await _climateService.GetClimateData();

            var climateHubContext = GlobalHost.ConnectionManager.GetHubContext<ClimateHub>();
            climateHubContext.Clients.All.updateZones(zones);

            return Ok();
        }
    }
}
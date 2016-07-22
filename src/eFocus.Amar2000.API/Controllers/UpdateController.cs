using System.Threading.Tasks;
using System.Web.Http;
using eFocus.Amar2000.API.Filters;
using eFocus.Amar2000.API.Hubs;
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

        [HttpPost]
        public async Task<IHttpActionResult> Post()
        {
            var zones = await _climateService.GetClimateData();

            var climateHubContext = GlobalHost.ConnectionManager.GetHubContext<ClimateHub>();
            climateHubContext.Clients.All.updateZones(zones);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put()
        {
            var climateHubContext = GlobalHost.ConnectionManager.GetHubContext<ClimateHub>();
            climateHubContext.Clients.All.refreshBrowser();

            return Ok();
        }
    }
}
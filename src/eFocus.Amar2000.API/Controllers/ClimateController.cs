using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using eFocus.Amar2000.API.Filters;
using eFocus.Amar2000.Core.Models.Climate;
using eFocus.Amar2000.Infrastructure.Services;

namespace eFocus.Amar2000.API.Controllers
{
    public class ClimateController : ApiController
    {
        private readonly ClimateService _climateService;

        public ClimateController(ClimateService climateService)
        {
            _climateService = climateService;
        }

        // GET api/climate

        public async Task<IEnumerable<Zone>> Get()
        {
            return await _climateService.GetClimateData();
        }

    }
}

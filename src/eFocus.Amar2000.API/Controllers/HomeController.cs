using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using eFocus.Amar2000.API.Hubs;
//using eFocus.Amar2000.API.Hubs;
using eFocus.Amar2000.Core.Models.Climate;
using eFocus.Amar2000.Infrastructure.Services;
using Microsoft.AspNet.SignalR;

//using Microsoft.AspNet.SignalR;

namespace eFocus.Amar2000.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClimateService _climateService;

        public HomeController(ClimateService climateService)
        {
            _climateService = climateService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> ForceUpdate()
        {
            var zones = await _climateService.GetClimateData();

            var climateHubContext = GlobalHost.ConnectionManager.GetHubContext<ClimateHub>();
            climateHubContext.Clients.All.updateZones(zones);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> FakeIt()
        {
            var zones = new List<Zone>
            {
                new Zone
                {
                    Name = "Zone A",
                    Sensors = new List<Sensor>
                    {
                        new Sensor
                        {
                            SensorId = "",
                            Timestamp = DateTime.UtcNow,
                            CO2 = 1900,
                            Humidity = 20,
                            MaximumTemperatureDate = DateTime.UtcNow.AddHours(-5),
                            MaximumTemperature = 27,
                            MinimumTemperature = 8,
                            MinimumTemperatureDate = DateTime.UtcNow.AddHours(-11),
                            Noise = 85,
                            Temperature = 22,
                        }
                    }
                }
            };

            var climateHubContext = GlobalHost.ConnectionManager.GetHubContext<ClimateHub>();
            climateHubContext.Clients.All.updateZones(zones);

            return RedirectToAction("Index");
        }
    }
}

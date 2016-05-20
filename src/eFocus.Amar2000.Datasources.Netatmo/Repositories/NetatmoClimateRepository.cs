using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eFocus.Amar2000.Core;
using eFocus.Amar2000.Core.Models.Climate;
using eFocus.Amar2000.Datasources.Netatmo.Models;
using eFocus.Amar2000.Datasources.Netatmo.Session;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

namespace eFocus.Amar2000.Datasources.Netatmo.Repositories
{
    public class NetatmoClimateRepository : IClimateRepository
    {
        private readonly NetatmoSessionProvider _sessionProvider;

        public NetatmoClimateRepository(NetatmoSessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public async Task<IEnumerable<Sensor>> GetStationsData() => await GetStationsData(null);

        public async Task<IEnumerable<Sensor>> GetStationsData(string deviceId)
        {
            var client = new RestClient("https://api.netatmo.com");

            var session = await _sessionProvider.GetSession();

            var request = new RestRequest("api/getstationsdata", Method.GET);
            request.AddParameter("access_token", session.AccessToken);

            if (deviceId != null)
                request.AddParameter("device_id", deviceId);

            var response = await client.ExecuteTaskAsync(request);

            return MapResponse(JsonConvert.DeserializeObject<NetatmoResponse>(response.Content));
        }

        protected virtual IEnumerable<Sensor> MapResponse(NetatmoResponse response)
        {
            var devices = new List<NetatmoDevice>();

            foreach (var station in response.Body.Stations)
            {
                devices.Add(station);
                devices.AddRange(station.Modules);
            }

            foreach (var device in devices)
            {
                var batteryPoweredDevice = device as INetatmoBatteryPoweredModule;

                yield return new Sensor
                {
                    SensorId = device.Id,
                    Timestamp = device.DashboardData.TimeUtc,
                    CO2 = device.DashboardData.CO2,
                    Humidity = device.DashboardData.Humidity,
                    Noise = device.DashboardData.Noise,
                    Temperature = device.DashboardData.Temperature,
                    MaximumTemperature = device.DashboardData.MaximumTemperature,
                    MaximumTemperatureDate = device.DashboardData.MaximumTemperatureDate,
                    MinimumTemperature = device.DashboardData.MinimumTemperature,
                    MinimumTemperatureDate = device.DashboardData.MinimumTemperatureDate,
                    BatteryLow = batteryPoweredDevice?.BatteryPercentage == null ? (bool?) null : batteryPoweredDevice.BatteryPercentage.Value < 10M
                };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using eFocus.Amar2000.Core;
using eFocus.Amar2000.Core.Models.Climate;
using eFocus.Amar2000.Persistance.Elastic.Extensions;
using eFocus.Amar2000.Persistance.Elastic.Model;
using Elasticsearch.Net;
using Nest;

namespace eFocus.Amar2000.Persistance.Elastic.Repositories
{
    public class ElasticSearchPersistanceRepository : IPersistanceRepository
    {
        private readonly IElasticClient _elasticClient;

        public ElasticSearchPersistanceRepository()
        {
            var uri = new Uri(ConfigurationManager.AppSettings["ElasticSearch.EndpointUrl"]);
            var settings = new ConnectionSettings(uri).DefaultIndex("climate");
            _elasticClient = new ElasticClient(settings);
        }

        public async Task SaveZones(IEnumerable<Zone> zones)
        {
            if (!await PrepareIndex())
                throw new ElasticsearchClientException("Cannot prepare client index");

            var mappedSensors = zones.SelectMany(zone => zone.Sensors.Select(sensor => MapSensor(sensor, zone)));

            //var indexTasks = new List<Task>();

            foreach (var sensor in mappedSensors)
            {
                //var task = Task.Factory.StartNew(async () =>
                //{
                    var exists = await _elasticClient.SensorExists(sensor);
                    //if (exists) return;
                    if (exists) continue;

                    await _elasticClient.IndexAsync(sensor);
                //});

                //indexTasks.Add(task);
            }

            //await Task.WhenAll(indexTasks);
        }

        protected virtual ElasticSearchSensor MapSensor(Sensor sensor, Zone zone)
        {
            return new ElasticSearchSensor
            {
                SensorId = sensor.SensorId,
                Timestamp = sensor.Timestamp.ToUniversalTime(),
                CO2 = sensor.CO2,
                Temperature = sensor.Temperature,
                Humidity = sensor.Humidity,
                Noise = sensor.Noise,
                MaximumTemperatureDate = sensor.MaximumTemperatureDate?.ToUniversalTime(),
                MaximumTemperature = sensor.MaximumTemperature,
                MinimumTemperatureDate = sensor.MinimumTemperatureDate?.ToUniversalTime(),
                MinimumTemperature = sensor.MinimumTemperature,
                Zone = MapZone(zone)
            };
        }

        protected virtual ElasticSearchZone MapZone(Zone zone)
        {
            return new ElasticSearchZone
            {
                Name = zone.Name
            };
        }

        protected virtual async Task<bool> PrepareIndex()
        {
            var result = await _elasticClient.IndexExistsAsync(new IndexExistsRequest("climate"));

            if (result.Exists && result.IsValid)
                return true;

            var response = await _elasticClient.CreateIndexAsync("climate");
            return response.IsValid;
        }
    }
}

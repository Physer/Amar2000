using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eFocus.Amar2000.Core;
using eFocus.Amar2000.Core.Models.Climate;
using eFocus.Amar2000.Infrastructure.Configuration.ZoneSensorMapping;

namespace eFocus.Amar2000.Infrastructure.Services
{
    public class ClimateService
    {
        private readonly IClimateRepository _climateRepository;
        private readonly IPersistanceRepository _persistanceRepository;
        private readonly IZoneSensorMapping<IEnumerable<IZoneMap<IEnumerable<ISensorMap>>>> _zoneSensorMapping;

        public ClimateService(IClimateRepository climateRepository, IPersistanceRepository persistanceRepository, IZoneSensorMapping<IEnumerable<IZoneMap<IEnumerable<ISensorMap>>>> zoneSensorMapping)
        {
            _climateRepository = climateRepository;
            _persistanceRepository = persistanceRepository;
            _zoneSensorMapping = zoneSensorMapping;
        }

        public async Task<IEnumerable<Zone>> GetClimateData()
        {
            var sensors = await _climateRepository.GetStationsData();

            var zones = MapSensorsToZones(sensors);

            // Fire and forget
            Task.Run(() => _persistanceRepository.SaveZones(zones));

            return zones;
        }

        protected virtual IEnumerable<Zone> MapSensorsToZones(IEnumerable<Sensor> sensors)
        {
            var enumeratedSensors = sensors as IList<Sensor> ?? sensors.ToList();

            return _zoneSensorMapping.Zones.Select(zone => new Zone
            {
                Name = zone.Name,
                Sensors =
                    enumeratedSensors.Where(
                        sensor =>
                            zone.Sensors
                                .Select(configSensor => configSensor.Id)
                                .Any(id => id == sensor.SensorId))
            });
        }
    }
}

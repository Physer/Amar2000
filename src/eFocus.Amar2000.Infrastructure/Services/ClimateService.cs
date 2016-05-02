using System.Collections.Generic;
using System.Threading.Tasks;
using eFocus.Amar2000.Core;
using eFocus.Amar2000.Core.Models.Climate;

namespace eFocus.Amar2000.Infrastructure.Services
{
    public class ClimateService
    {
        private readonly IClimateRepository _climateRepository;
        private readonly IPersistanceRepository _persistanceRepository;

        public ClimateService(IClimateRepository climateRepository, IPersistanceRepository persistanceRepository)
        {
            _climateRepository = climateRepository;
            _persistanceRepository = persistanceRepository;
        }

        public async Task<IEnumerable<Zone>> GetClimateData()
        {
            var zones = new List<Zone> { new Zone
            {
                Name = "Zone A",
                Sensors = await _climateRepository.GetStationsData()
            } };

            // Fire and forget
            Task.Run(() => _persistanceRepository.SaveZones(zones));

            return zones;
        }
    }
}

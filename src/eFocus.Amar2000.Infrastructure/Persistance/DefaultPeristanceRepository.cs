using System.Collections.Generic;
using System.Threading.Tasks;
using eFocus.Amar2000.Core;
using eFocus.Amar2000.Core.Models.Climate;

namespace eFocus.Amar2000.Infrastructure.Persistance
{
    public class DefaultPeristanceRepository : IPersistanceRepository
    {
        public async Task SaveZones(IEnumerable<Zone> zones) // Not really async, just needed to return a task instad a void.
        {
            // Empty by design, we might implement this later.
            return;
        }
    }
}

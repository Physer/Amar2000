using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eFocus.Amar2000.Core.Models.Climate;

namespace eFocus.Amar2000.Core
{
    public interface IClimateRepository
    {
        Task<IEnumerable<Sensor>> GetStationsData();
        Task<IEnumerable<Sensor>> GetStationsData(string deviceId);

    }
}

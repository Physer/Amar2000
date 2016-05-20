using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFocus.Amar2000.Datasources.Netatmo.Models
{
    public interface INetatmoBatteryPoweredModule
    {
        decimal? BatteryPercentage { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFocus.Amar2000.Core.Models.Climate
{
    public class Sensor
    {
        public string SensorId { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal? CO2 { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
        public decimal? Noise { get; set; }
        public DateTime? MaximumTemperatureDate { get; set; }
        public decimal? MaximumTemperature { get; set; }
        public DateTime? MinimumTemperatureDate { get; set; }
        public decimal? MinimumTemperature { get; set; }
    }
}

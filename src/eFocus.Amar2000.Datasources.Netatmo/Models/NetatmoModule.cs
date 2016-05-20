using Newtonsoft.Json;

namespace eFocus.Amar2000.Datasources.Netatmo.Models
{
    public class NetatmoModule : NetatmoDevice, INetatmoBatteryPoweredModule
    {
        [JsonProperty("module_name")]
        public string ModuleName { get; set; }

        [JsonProperty("battery_percent")]
        public decimal? BatteryPercentage { get; set; }
    }
}

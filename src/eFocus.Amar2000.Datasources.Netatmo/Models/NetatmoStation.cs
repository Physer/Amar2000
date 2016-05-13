using System.Collections.Generic;
using Newtonsoft.Json;

namespace eFocus.Amar2000.Datasources.Netatmo.Models
{
    public class NetatmoStation : NetatmoDevice
    {
        [JsonProperty("station_name")]
        public string StationName { get; set; }

        [JsonProperty("modules")]
        public IEnumerable<NetatmoModule> Modules { get; set; }
    }
}

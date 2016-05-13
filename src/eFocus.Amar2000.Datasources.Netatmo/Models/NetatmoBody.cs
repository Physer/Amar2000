using System.Collections.Generic;
using Newtonsoft.Json;

namespace eFocus.Amar2000.Datasources.Netatmo.Models
{
    public class NetatmoBody
    {
        [JsonProperty("devices")]
        public IEnumerable<NetatmoStation> Stations { get; set; }
    }
}

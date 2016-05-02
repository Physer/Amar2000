using Newtonsoft.Json;

namespace eFocus.Amar2000.Datasources.Netatmo.Models
{
    public class NetatmoResponse
    {
        [JsonProperty("body")]
        public NetatmoBody Body { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}

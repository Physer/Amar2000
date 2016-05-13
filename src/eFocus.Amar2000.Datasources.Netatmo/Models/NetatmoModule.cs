using Newtonsoft.Json;

namespace eFocus.Amar2000.Datasources.Netatmo.Models
{
    public class NetatmoModule : NetatmoDevice
    {
        [JsonProperty("module_name")]
        public string ModuleName { get; set; }
    }
}

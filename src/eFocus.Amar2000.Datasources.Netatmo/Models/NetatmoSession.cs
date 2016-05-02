using System;
using Newtonsoft.Json;

namespace eFocus.Amar2000.Datasources.Netatmo.Models
{
    public class NetatmoSession
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonIgnore]
        public DateTime SessionStartedUtc { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace eFocus.Amar2000.Datasources.Netatmo.Models
{
    public class NetatmoDevice
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("co2_calibrating")]
        public bool CO2Calibrating { get; set; }

        [JsonProperty("dashboard_data")]
        public NetatmoDashoardData DashboardData { get; set; }

        [JsonProperty("battery_vp")]

        public int BatteryPercentage { get; set; }
    }
}

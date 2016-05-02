using System;
using eFocus.Amar2000.Datasources.Netatmo.Serialization;
using Newtonsoft.Json;

namespace eFocus.Amar2000.Datasources.Netatmo.Models
{
    public class NetatmoDashoardData
    {
        [JsonProperty("time_utc"), JsonConverter(typeof(UnixTimeStampConverter))]
        public DateTime TimeUtc { get; set; }

        [JsonProperty("Temperature")]
        public decimal? Temperature { get; set; }

        [JsonProperty("CO2")]
        public decimal? CO2 { get; set; }

        [JsonProperty("Humidity")]
        public decimal? Humidity { get; set; }

        [JsonProperty("Noise")]
        public decimal? Noise { get; set; }

        [JsonProperty("date_max_temp"), JsonConverter(typeof(UnixTimeStampConverter))]
        public DateTime? MaximumTemperatureDate { get; set; }

        [JsonProperty("max_temp")]
        public decimal? MaximumTemperature { get; set; }

        [JsonProperty("date_min_temp"), JsonConverter(typeof(UnixTimeStampConverter))]
        public DateTime? MinimumTemperatureDate { get; set; }

        [JsonProperty("min_temp")]
        public decimal? MinimumTemperature { get; set; }

    }
}

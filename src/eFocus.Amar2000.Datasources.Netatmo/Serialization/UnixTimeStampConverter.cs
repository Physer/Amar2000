using System;
using Newtonsoft.Json;

namespace eFocus.Amar2000.Datasources.Netatmo.Serialization
{
    public class UnixTimeStampConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                writer.WriteNull();

            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var timespan = (DateTime) value - epoch;
            writer.WriteValue(timespan.Seconds);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) return null;

            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds((long)reader.Value).ToLocalTime();
            return dtDateTime;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }
    }
}

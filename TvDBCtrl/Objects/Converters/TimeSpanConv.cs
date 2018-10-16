using Newtonsoft.Json;
using System;

namespace TvDBCtrl.Objects.Converters
{
    /// <summary>
    /// Converts a TimeSpan to DateTime.
    /// </summary>
    internal class TimeSpanConv : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value    = reader.Value.ToString();
            if (!string.IsNullOrEmpty(value) && DateTime.TryParse(value, out DateTime result))
            {
                return result.TimeOfDay;
            }
            else return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}

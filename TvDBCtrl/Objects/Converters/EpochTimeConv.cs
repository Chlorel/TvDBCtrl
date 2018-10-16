using Newtonsoft.Json;
using System;

namespace TvDBCtrl.Objects.Converters
{
    /// <summary>
    /// Converts Epoch Time in Json to DateTime.
    /// </summary>
    internal class EpochTimeConv : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (long)reader.Value;
            return DateTimeExtensions.ToDateTime(value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}

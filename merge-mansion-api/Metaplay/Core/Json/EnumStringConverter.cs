using System;
using Newtonsoft.Json;

namespace Metaplay.Core.Json
{
    public class EnumStringConverter<TEnum> : JsonConverter
    {
        public EnumStringConverter()
        {
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
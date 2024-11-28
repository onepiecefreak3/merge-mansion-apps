using System;
using System.Linq;
using GameLogic.Config;
using merge_mansion_dumper.Dumper.Json.Metaplay;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;

namespace merge_mansion_dumper.Dumper.Json
{
    class MergeMansionJsonConverter : JsonConverter
    {
        private readonly BaseMetaJsonSerializer[] _serializers;

        public MergeMansionJsonConverter(SharedGameConfig resolver, ILogger output, bool dropsAsPercent)
        {
            _serializers = new BaseMetaJsonSerializer[]
            {
                new MetaJsonSerializer(resolver, output),
                new MetaMathJsonSerializer(),
                new MetaMergeChainSerializer(resolver, dropsAsPercent, output),
                new MetaAreaSerializer(resolver, output),
                new MetaEventSerializer(resolver),
            };
        }

        public override bool CanConvert(Type objectType)
        {
            return _serializers.Any(s => s.CanConvert(objectType));
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null && serializer.NullValueHandling == NullValueHandling.Include)
            {
                JValue.CreateNull().WriteTo(writer);
                return;
            }

            var customSerializer = _serializers.FirstOrDefault(s => s.CanConvert(value.GetType()));
            if (customSerializer != null)
                customSerializer.WriteJson(writer, value, serializer);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using Metaplay.Core.Math;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace merge_mansion_dumper.Dumper.Json.Metaplay
{
    class MetaMathJsonSerializer : BaseMetaJsonSerializer
    {
        private readonly Type[] _supportedTypes =
        {
            typeof(F32),
            typeof(F64),
            typeof(MetaUInt128)
        };

        protected override Type[] GetTypes() => _supportedTypes;

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is F32 f32)
                new JValue(Math.Ceiling(f32.Float)).WriteTo(writer);
            else if (value is F64 f64)
                new JValue(Math.Ceiling(f64.Double)).WriteTo(writer);
            else if (value is MetaUInt128 uint128)
                new JValue(uint128.ToString()).WriteTo(writer);
        }
    }
}

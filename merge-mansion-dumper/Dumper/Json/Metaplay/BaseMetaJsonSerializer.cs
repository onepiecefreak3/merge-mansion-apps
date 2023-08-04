using Newtonsoft.Json;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using GameLogic.Player.Director.Config;
using Metaplay.Core;
using System.Reflection;
using Metaplay.Core.Model;
using Metaplay.Core.IO;

namespace merge_mansion_dumper.Dumper.Json.Metaplay
{
    public abstract class BaseMetaJsonSerializer : JsonConverter
    {
        protected abstract Type[] GetTypes();

        public override bool CanConvert(Type objectType)
        {
            var types = GetTypes();
            return types.Contains(objectType) || types.Any(objectType.IsAssignableTo);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected void WriteEmptyObject(JsonWriter writer)
        {
            new JObject().WriteTo(writer);
        }

        protected void WriteObject(JsonWriter writer, Type type, object @object, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            WriteCustomObjectMembers(writer, @object, serializer);

            var flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            var values = type.GetProperties(flags).Select(p => new ObjectValue(p.GetValue(@object), p.Name.Trim('_'), p.GetCustomAttribute<MetaMemberAttribute>()?.TagId ?? -1));
            values = values.Concat(type.GetFields(flags).Select(f => new ObjectValue(f.GetValue(@object), f.Name.Trim('_'), f.GetCustomAttribute<MetaMemberAttribute>()?.TagId ?? -1)));

            foreach (var value in values.Where(x => x.Order > 0).OrderBy(x => x.Order))
            {
                if (value.Value == null && serializer.NullValueHandling == NullValueHandling.Ignore)
                    continue;

                WriteObjectMember(writer, value.Name, type, value.Value, serializer);
            }

            writer.WriteEndObject();
        }

        protected virtual void WriteCustomObjectMembers(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }

        protected virtual void WriteObjectMember(JsonWriter writer, string name, Type type, object value, JsonSerializer serializer)
        {
            if (value is IMetaRef { IsResolved: false })
                return;

            WriteProperty(writer, name, value, serializer);
        }

        protected void WriteProperty(JsonWriter writer, string name, object value, JsonSerializer serializer)
        {
            writer.WritePropertyName(name);
            WriteValue(writer, value, serializer);
        }

        protected void WriteValue(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        record ObjectValue(object Value, string Name, int Order);
    }
}

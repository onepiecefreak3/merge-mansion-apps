using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Metaplay.Core;
using Metaplay.Core.Math;
using Metaplay.Core.Model;
using Newtonsoft.Json;

namespace merge_mansion_api
{
    // CUSTOM: Static class for debug methods
    static class DebugTools
    {
        public static void WriteIndex(string type, int index)
        {
#if DEBUG
            Console.Write($"\r{type}: {index:00000}\t\t\t\t");
#endif
        }

        public static void WriteSendMessage(MetaMessage message)
        {
#if DEBUG
            Console.WriteLine("Send: " + message.GetType().Name);
            Console.WriteLine(SerializeObject(message));
#endif
        }

        public static void WriteReceivedMessage(MetaMessage message)
        {
#if DEBUG
            Console.WriteLine("Receive: " + message.GetType().Name);
            Console.WriteLine(SerializeObject(message));
#endif
        }

        private static string SerializeObject(object value)
        {
            var sb = new StringBuilder();
            using var writer = new JsonTextWriter(new StringWriter(sb));
            writer.Formatting = Formatting.Indented;

            var serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented
            };

            SerializeTaggedObject(value, writer, serializer);

            return sb.ToString();
        }

        private static void SerializeTaggedObject(object value, JsonWriter writer, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            var members = GetTaggedMembers(value.GetType());
            foreach (var member in members.OrderBy(x => x.tagId))
            {
                writer.WritePropertyName(member.member.Name);

                object memberValue;
                Type memberType;

                if (member.member is PropertyInfo property)
                {
                    memberValue = property.GetValue(value);
                    memberType = property.PropertyType;
                }
                else if (member.member is FieldInfo field)
                {
                    memberValue = field.GetValue(value);
                    memberType = field.FieldType;
                }
                else
                    throw new InvalidOperationException("Unsupported member type.");

                if (memberType.IsEnum)
                    writer.WriteValue((int)memberValue);
                else if (memberType.IsPrimitive || memberValue is string)
                    writer.WriteValue(memberValue);
                else if (memberValue is null)
                    writer.WriteNull();
                else if (memberValue is IStringId stringId)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("Value");
                    writer.WriteValue(stringId.Value);
                    writer.WriteEndObject();
                }
                else if (memberValue is UInt128 i128)
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("High");
                    writer.WriteValue(i128.High);
                    writer.WritePropertyName("Low");
                    writer.WriteValue(i128.Low);
                    writer.WriteEndObject();
                }
                else
                    SerializeTaggedObject(memberValue, writer, serializer);
            }

            writer.WriteEndObject();
        }

        private static IList<(int tagId, MemberInfo member)> GetTaggedMembers(Type type)
        {
            var result = new List<(int tagId, MemberInfo member)>();
            var flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

            foreach (var property in type.GetProperties(flags))
            {
                var customAttribute = property.GetCustomAttribute<MetaMemberAttribute>();
                if (customAttribute == null)
                    continue;

                result.Add((customAttribute.TagId, property));
            }

            foreach (var field in type.GetFields(flags))
            {
                var customAttribute = field.GetCustomAttribute<MetaMemberAttribute>();
                if (customAttribute == null)
                    continue;

                result.Add((customAttribute.TagId, field));
            }

            return result;
        }

        private static IDictionary<int, PropertyInfo> GetTaggedProperties(Type type)
        {
            var result = new Dictionary<int, PropertyInfo>();

            var flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            foreach (var property in type.GetProperties(flags))
            {
                var customAttribute = property.GetCustomAttribute<MetaMemberAttribute>();
                if (customAttribute == null)
                    continue;

                result[customAttribute.TagId] = property;
            }

            return result;
        }

        private static IDictionary<int, FieldInfo> GetTaggedFields(Type type)
        {
            var result = new Dictionary<int, FieldInfo>();

            var flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            foreach (var field in type.GetFields(flags))
            {
                var customAttribute = field.GetCustomAttribute<MetaMemberAttribute>();
                if (customAttribute == null)
                    continue;

                result[customAttribute.TagId] = field;
            }

            return result;
        }
    }
}
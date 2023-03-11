using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Metaplay.Metaplay.Core
{
    public class EntityKindRegistry
    {
        private static EntityKindRegistry _instance; // 0x0

        public readonly Dictionary<string, EntityKind> ByName; // 0x10
        public readonly Dictionary<EntityKind, string> ByValue; // 0x18

        public static EntityKindRegistry Instance => _instance;

        private EntityKindRegistry()
        {
            ByName = new Dictionary<string, EntityKind>();
            ByValue = new Dictionary<EntityKind, string>();

            var ci = new Dictionary<Type, EntityKindRegistryAttribute>();
            foreach (var c in TypeScanner.GetClassesWithAttribute<EntityKindRegistryAttribute>())
            {
                var attr = c.GetCustomAttribute<EntityKindRegistryAttribute>();
                foreach (var cie in ci)
                {
                    if (DoesRangeOverlap(attr, cie.Value))
                        throw new InvalidOperationException($"Ranges for EntityKind registries {c.Name} ({attr.StartIndex}..{attr.EndIndex}) and {cie.Key.Name} ({cie.Value.StartIndex}..{cie.Value.EndIndex}) overlap!");
                }

                ci[c] = attr;

                foreach (var f in c.GetFields().Where(x => x.FieldType == typeof(EntityKind)))
                {
                    if (!f.IsInitOnly)
                        throw new InvalidOperationException($"{c.FullName}.{f.Name}  must be 'static readonly'");

                    var fieldValue = (EntityKind)f.GetValue(null);
                    if (fieldValue.Value < attr.StartIndex || attr.EndIndex <= fieldValue.Value)
                        throw new InvalidOperationException($"{c.FullName}.{fieldValue.Name} value ({fieldValue.Value}) is out of range ({attr.StartIndex}..{attr.EndIndex})");

                    if (ByName.TryGetValue(f.Name, out var value))
                        throw new InvalidOperationException("Duplicate EntityKinds with name " + f.Name);

                    if (ByValue.TryGetValue(fieldValue, out var value1))
                        throw new InvalidOperationException($"EntityKinds {f.Name} and {value1} have the same value {fieldValue.Value}");

                    ByName[f.Name] = fieldValue;
                    ByValue[fieldValue] = f.Name;
                }
            }
        }

        public static void Initialize()
        {
            if (_instance != null)
                throw new InvalidOperationException("Duplicate initialization of EntityKindRegistry");

            _instance = new EntityKindRegistry();
        }

        // CUSTOM: Reset static instances for runtime re-initialization
        public static void Reset()
        {
            _instance = null;
        }

        public static bool IsValid(EntityKind kind)
        {
            return Instance.ByValue.ContainsKey(kind);
        }

        public static bool TryFromName(string str, out EntityKind kind)
        {
            return Instance.ByName.TryGetValue(str, out kind);
        }

        public static EntityKind FromName(string str)
        {
            if (!TryFromName(str, out var kind))
                throw new InvalidOperationException($"No such EntityKind '{str}'");

            return kind;
        }

        public static string GetName(EntityKind kind)
        {
            if (!Instance.ByValue.TryGetValue(kind, out var value))
                return $"Invalid#{kind.Value}";

            return value;
        }

        private static bool DoesRangeOverlap(EntityKindRegistryAttribute a, EntityKindRegistryAttribute b)
        {
            var minStart = System.Math.Min(a.StartIndex, b.StartIndex);
            var maxEnd = System.Math.Max(a.EndIndex, b.EndIndex);

            return maxEnd - minStart < a.EndIndex - a.StartIndex - b.StartIndex + b.EndIndex;
        }
    }
}

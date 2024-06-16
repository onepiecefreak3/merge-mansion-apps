using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameLogic.Config;
using Metaplay.Core.Serialization;
using Newtonsoft.Json.Linq;

namespace Metaplay.Core.Config
{
    internal static class GameConfigUtil
    {
        public static Dictionary<TKey, TValue> ConvertToOrderedDictionary<TKey, TValue>(IEnumerable<TValue> items)
            where TValue : IGameConfigData<TKey>
        {
            var result = new Dictionary<TKey, TValue>();

            foreach (var item in items)
            {
                if (item == null)
                    throw new InvalidOperationException("Imported a null item in GameConfigLibrary<" + typeof(TKey).Name + "," + typeof(TValue).Name + ">");

                var configKey = item.ConfigKey;
                if (configKey == null)
                    throw new InvalidOperationException("Imported an item with ConfigKey==null in GameConfigLibrary<" + typeof(TKey).Name + ", " + typeof(TValue).Name + ">");

                if (result.ContainsKey(configKey))
                    throw new InvalidOperationException($"Imported an item with non-unique key: {configKey} in GameConfigLibrary<{typeof(TKey).Name}, {typeof(TValue).Name}>");

                result[configKey] = item;
            }

            return result;
        }

        public static Dictionary<TKey, TValue> ImportBinaryLibraryItems<TKey, TValue>(IConfigArchive archive, string fileName)
            where TValue : IGameConfigData<TKey>
        {
            var entryData = archive.ReadEntry(fileName);

            try
            {
                var tableEntries = MetaSerialization.DeserializeTableTagged<TValue>(entryData, MetaSerializationFlags.IncludeAll, null, 0, null);
                return ConvertToOrderedDictionary<TKey, TValue>(tableEntries);
            }
            catch (Exception e)
            {
                Console.WriteLine($"[!] Error deserializing table of type {typeof(TValue).Name}: {e.Message}");
                return null;
            }
        }

        public static void ImportBinaryLibraryAliases<TKey, TValue>(GameConfigLibrary<TKey, TValue> library, ConfigArchive archive, string fileName)
            where TValue : IGameConfigData<TKey>
        {
        }

        public static T ImportBinaryKeyValueStructure<T>(IConfigArchive archive, string fileName)
        {
            var entryData = archive.ReadEntry(fileName);

            try
            {
                return (T)MetaSerialization.DeserializeTagged(entryData, typeof(T), MetaSerializationFlags.IncludeAll, null, 0, null);
            }
            catch (Exception e)
            {
                Console.WriteLine($"[!] Error deserializing type {typeof(T).Name}.");
                return default;
            }
        }
    }
}

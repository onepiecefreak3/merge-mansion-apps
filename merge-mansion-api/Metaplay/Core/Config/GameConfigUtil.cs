using System;
using System.Collections.Generic;
using Metaplay.Core.Serialization;

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
                {
                    //throw new InvalidOperationException("Imported an item with ConfigKey==null in GameConfigLibrary<" + typeof(TKey).Name + ", " + typeof(TValue).Name + ">");
                    continue;
                }

                if (result.ContainsKey(configKey))
                    throw new InvalidOperationException($"Imported an item with non-unique key: {configKey} in GameConfigLibrary<{typeof(TKey).Name}, {typeof(TValue).Name}>");

                result[configKey] = item;
            }

            return result;
        }

        public static Dictionary<TKey, TValue> ImportBinaryLibraryItems<TKey, TValue>(IGameConfigDataResolver resolver, ConfigArchive archive, string fileName)
            where TValue : IGameConfigData<TKey>
        {
            var entry = archive.GetEntryByName(fileName);
            var entryData = entry.Uncompress();

            try
            {
                var tableEntries = MetaSerialization.DeserializeTableTagged<TValue>(entryData, MetaSerializationFlags.IncludeAll, resolver, 0, null);
                return ConvertToOrderedDictionary<TKey, TValue>(tableEntries);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static void ImportBinaryLibraryAliases<TKey, TValue>(GameConfigLibrary<TKey, TValue> library, ConfigArchive archive, string fileName)
            where TValue : IGameConfigData<TKey>
        {
            // TODO: Set aliases in GameConfigLibrary
            //var entry = archive.GetEntryByName(fileName);
            //var entryData = entry.Uncompress();

            //var tableEntries = MetaSerialization.DeserializeTableTagged<TValue>(entryData, MetaSerializationFlags.IncludeAll, resolver, 0, null);
            //var dict=ConvertToOrderedDictionary<TKey, TValue>(tableEntries);
            //foreach (var pair in dict)
            //{

            //}
        }
    }
}

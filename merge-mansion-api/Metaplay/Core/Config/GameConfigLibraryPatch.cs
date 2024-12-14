using System;
using Metaplay.Core.Model;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    public class GameConfigLibraryPatch<TKey, TInfo> : GameConfigEntryPatch<GameConfigLibrary<TKey, TInfo>, Dictionary<TKey, TInfo>>, IGameConfigLibraryPatch
    {
        [JsonProperty("replacedItems")]
        private Dictionary<TKey, TInfo> _replacedItems;
        [JsonProperty("appendedItems")]
        private Dictionary<TKey, TInfo> _appendedItems;
        [JsonIgnore]
        [MaxCollectionSize(2147483647)]
        [MetaMember(1, (MetaMemberFlags)0)]
        private List<GameConfigDataContent<TInfo>> _replacedItemsForSerialization { get; set; }

        [JsonIgnore]
        [MetaMember(2, (MetaMemberFlags)0)]
        [MaxCollectionSize(2147483647)]
        private List<GameConfigDataContent<TInfo>> _appendedItemsForSerialization { get; set; }

        private GameConfigLibraryPatch()
        {
        }

        public GameConfigLibraryPatch(IEnumerable<TInfo> replacedItems, IEnumerable<TInfo> appendedItems)
        {
        }

        internal override void PatchContentDangerouslyInPlace(Dictionary<TKey, TInfo> libraryItems)
        {
            return;
            throw new NotImplementedException();
        }
    }
}
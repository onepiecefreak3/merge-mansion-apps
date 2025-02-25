using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class DigEventItemInfo : IGameConfigData<DigEventItemId>, IGameConfigData, IHasGameConfigKey<DigEventItemId>
    {
        public static string ShinyAppendix;
        [MetaMember(1, (MetaMemberFlags)0)]
        public DigEventItemId ItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string AssetId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public bool GoesMuseum { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int MuseumItemWidth { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int MuseumItemHeight { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public bool CanBeShiny { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        private DigEventItemId ShinyReplaces { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public List<ValueTuple<int, int>> Coordinates { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public int Weight { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public MuseumItemRotation MuseumItemRotation { get; set; }

        [IgnoreDataMember]
        public string ResolvedShinyAssetId { get; }

        public DigEventItemId ConfigKey => ItemId;

        public DigEventItemInfo()
        {
        }

        public DigEventItemInfo(DigEventItemId configKey, string assetId, bool goesMuseum, int museumItemWidth, int museumItemHeight, bool canBeShiny, DigEventItemId shinyReplaces, List<ValueTuple<int, int>> coordinates, int weight, MuseumItemRotation museumItemRotation)
        {
        }
    }
}
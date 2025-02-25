using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.Player;
using GameLogic.Player.Rewards;
using GameLogic.ConfigPrefabs;
using GameLogic.Player.Items;
using System.Runtime.Serialization;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class CardCollectionEvidenceBoxInfo : IGameConfigData<CardCollectionEvidenceBoxId>, IGameConfigData, IHasGameConfigKey<CardCollectionEvidenceBoxId>
    {
        public static string TableName;
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardCollectionEvidenceBoxId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int SlotIndex { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private List<CurrencyPricePair> CurrencyPricePairs { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public BoxQuality Quality { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MetaDuration RefreshTime { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        private List<CurrencyPricePair> SkipCurrencyPricePairs { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        private bool IsSkipPriceDynamic { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public int SegmentPriority { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public PlayerSegmentId Segment { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public ConfigAssetPackId AssetPackId { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> EvidenceBoxItemRef { get; set; }

        [IgnoreDataMember]
        public int AvailableDailyPurchaseCount { get; }

        public CardCollectionEvidenceBoxInfo()
        {
        }

        public CardCollectionEvidenceBoxInfo(CardCollectionEvidenceBoxId configKey, int slotIndex, List<CurrencyPricePair> currencyPricePairs, BoxQuality quality, MetaDuration refreshTime, List<CurrencyPricePair> skipCurrencyPricePairs, bool isSkipPriceDynamic, List<PlayerReward> rewards, PlayerSegmentId segment, int segmentPriority, ConfigAssetPackId assetPackId, MetaRef<ItemDefinition> evidenceBoxItemRef)
        {
        }

        [IgnoreDataMember]
        public List<PlayerReward> RewardsForConfigValidation { get; }
    }
}
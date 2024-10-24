using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;
using System.Collections.Generic;

namespace GameLogic.CardCollection
{
    public class CardCollectionEvidenceBoxSource : IConfigItemSource<CardCollectionEvidenceBoxInfo, CardCollectionEvidenceBoxId>, IGameConfigSourceItem<CardCollectionEvidenceBoxId, CardCollectionEvidenceBoxInfo>, IHasGameConfigKey<CardCollectionEvidenceBoxId>
    {
        public CardCollectionEvidenceBoxId ConfigKey { get; set; }
        private int SlotIndex { get; set; }
        private string PriceCurrency { get; set; }
        private string PriceAmount { get; set; }
        private BoxQuality Quality { get; set; }
        private MetaDuration RefreshTime { get; set; }
        private string SkipPriceCurrency { get; set; }
        private string SkipPriceAmount { get; set; }
        private bool IsSkipPriceDynamic { get; set; }
        private int SegmentPriority { get; set; }
        private string Segment { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        private string AssetPackId { get; set; }
        private string EvidenceBoxItem { get; set; }

        public CardCollectionEvidenceBoxSource()
        {
        }
    }
}
using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;
using GameLogic.Config;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    public class ProgressionEventV2Source : IConfigItemSource<ProgressionEventV2Info, ProgressionEventV2Id>, IGameConfigSourceItem<ProgressionEventV2Id, ProgressionEventV2Info>, IHasGameConfigKey<ProgressionEventV2Id>
    {
        public ProgressionEventV2Id ConfigKey { get; set; }
        public bool IsEnabled { get; set; }
        private MetaRef<InAppProductInfo> Track1IAP { get; set; }
        private List<MetaRef<ProgressionEventPerkInfo>> Track1IAPPerks { get; set; }
        private MetaRef<InAppProductInfo> Track2IAP { get; set; }
        private List<MetaRef<ProgressionEventPerkInfo>> Track2IAPPerks { get; set; }
        private MetaRef<InAppProductInfo> UpgradeIAP { get; set; }
        private List<MetaRef<EventLevelInfo>> FreeEventLevels { get; set; }
        private List<MetaRef<EventLevelInfo>> Track1EventLevels { get; set; }
        private List<MetaRef<EventLevelInfo>> Track2EventLevels { get; set; }
        private List<MetaRef<EventLevelInfo>> BonusLevels { get; set; }
        private bool IsBonusRewardSecret { get; set; }
        private string PriceValueLocIdTrack1 { get; set; }
        private string PriceValueLocIdTrack2 { get; set; }

        public ProgressionEventV2Source()
        {
        }
    }
}
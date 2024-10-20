using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;
using GameLogic.Config;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class ProgressionEventV2Info : IGameConfigData<ProgressionEventV2Id>, IGameConfigData, IHasGameConfigKey<ProgressionEventV2Id>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ProgressionEventV2Id ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool IsEnabled { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaRef<InAppProductInfo> Track1IAP { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<MetaRef<ProgressionEventPerkInfo>> Track1IAPPerkRefs { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MetaRef<InAppProductInfo> Track2IAP { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<MetaRef<ProgressionEventPerkInfo>> Track2IAPPerkRefs { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public MetaRef<InAppProductInfo> UpgradeIAP { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public List<MetaRef<EventLevelInfo>> FreeEventLevelRefs { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public List<MetaRef<EventLevelInfo>> Track1EventLevelRefs { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public List<MetaRef<EventLevelInfo>> Track2EventLevelRefs { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public List<MetaRef<EventLevelInfo>> BonusEventLevelRefs { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public bool IsBonusRewardSecret { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public string PriceValueLocIdTrack1 { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public string PriceValueLocIdTrack2 { get; set; }

        public ProgressionEventV2Info()
        {
        }

        public ProgressionEventV2Info(ProgressionEventV2Id configKey, bool isEnabled, MetaRef<InAppProductInfo> track1IAP, List<MetaRef<ProgressionEventPerkInfo>> track1IAPPerkRefs, MetaRef<InAppProductInfo> track2IAP, List<MetaRef<ProgressionEventPerkInfo>> track2IAPPerkRefs, MetaRef<InAppProductInfo> upgradeIAP, List<MetaRef<EventLevelInfo>> freeEventLevelRefs, List<MetaRef<EventLevelInfo>> track1EventLevelRefs, List<MetaRef<EventLevelInfo>> track2EventLevelRefs, List<MetaRef<EventLevelInfo>> bonusEventLevelRefs, bool isBonusRewardSecret, string priceValueLocIdTrack1, string priceValueLocIdTrack2)
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace GameLogic.Advertisement
{
    [MetaSerializable]
    public class AdvertisementPlacementsInfo : IGameConfigData<AdvertisementPlacementId>, IGameConfigData, IHasGameConfigKey<AdvertisementPlacementId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public AdvertisementPlacementId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string AdsProviderIds { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int CapPerCooldown { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int RewardAmount { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public AdsRewardType AdsRewardType { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<int> RewardIds { get; set; }

        public AdvertisementPlacementsInfo()
        {
        }

        public AdvertisementPlacementsInfo(AdvertisementPlacementId configKey, string adsProviderIds, int capPerCooldown, int rewardAmount, AdsRewardType adsRewardType, List<int> rewardIds)
        {
        }
    }
}
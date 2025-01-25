using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Merge;
using Metaplay.Core.Offers;
using GameLogic.Player.Rewards;

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

        [MetaMember(7, (MetaMemberFlags)0)]
        public int Threshold { get; set; }

        public AdvertisementPlacementsInfo(AdvertisementPlacementId configKey, string adsProviderIds, int capPerCooldown, int rewardAmount, AdsRewardType adsRewardType, List<int> rewardIds, int threshold)
        {
        }

        [MetaMember(8, (MetaMemberFlags)0)]
        public List<MergeBoardId> BoardIds { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public List<OfferPlacementId> OfferPlacementIds { get; set; }

        public AdvertisementPlacementsInfo(AdvertisementPlacementId configKey, string adsProviderIds, int capPerCooldown, int rewardAmount, AdsRewardType adsRewardType, List<int> rewardIds, int threshold, List<MergeBoardId> boardIds, List<OfferPlacementId> offerPlacementIds)
        {
        }

        [MetaMember(10, (MetaMemberFlags)0)]
        public List<ValueTuple<PlayerReward, int>> Rewards { get; set; }

        public AdvertisementPlacementsInfo(AdvertisementPlacementId configKey, string adsProviderIds, int capPerCooldown, int rewardAmount, AdsRewardType adsRewardType, List<int> rewardIds, int threshold, List<MergeBoardId> boardIds, List<OfferPlacementId> offerPlacementIds, List<ValueTuple<PlayerReward, int>> rewards)
        {
        }
    }
}
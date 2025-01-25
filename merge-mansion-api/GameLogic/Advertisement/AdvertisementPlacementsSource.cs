using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Merge;
using Metaplay.Core.Offers;

namespace GameLogic.Advertisement
{
    public class AdvertisementPlacementsSource : IConfigItemSource<AdvertisementPlacementsInfo, AdvertisementPlacementId>, IGameConfigSourceItem<AdvertisementPlacementId, AdvertisementPlacementsInfo>, IHasGameConfigKey<AdvertisementPlacementId>
    {
        public AdvertisementPlacementId ConfigKey { get; set; }
        public string AdsProviderIds { get; set; }
        public int CapPerCooldown { get; set; }
        public List<int> RewardAmount { get; set; }
        public List<string> RewardType { get; set; }
        public string WhiteListedItems { get; set; }

        public AdvertisementPlacementsSource()
        {
        }

        public int Threshold { get; set; }
        public List<MergeBoardId> BoardIds { get; set; }
        public List<OfferPlacementId> OfferPlacementIds { get; set; }
        public AdsRewardType AdRewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardWeight { get; set; }
    }
}
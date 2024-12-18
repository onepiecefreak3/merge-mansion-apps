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
        public int RewardAmount { get; set; }
        public AdsRewardType RewardType { get; set; }
        public string WhiteListedItems { get; set; }

        public AdvertisementPlacementsSource()
        {
        }

        public int Threshold { get; set; }
        public List<MergeBoardId> BoardIds { get; set; }
        public List<OfferPlacementId> OfferPlacementIds { get; set; }
    }
}
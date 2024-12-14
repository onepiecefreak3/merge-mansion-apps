using Metaplay.Core.Model;
using System;
using GameLogic.Advertisement;
using Merge;
using GameLogic.Player.Board;
using GameLogic.Player;
using Metaplay.Core.Offers;
using System.Runtime.Serialization;
using System.Collections.Generic;
using GameLogic.Merge;

namespace GameLogic
{
    [MetaSerializable]
    public class AdsRewardData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public string AdPlacement { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public AdvertisementPlacementId AdPlacementId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public string ItemName { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string AuctionId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public ShopItemId ShopItemId { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(6, (MetaMemberFlags)0)]
        public int ItemDiamondValue { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public AdsRewardType AdsRewardType { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public int ItemCostValue { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public Currencies ItemCostValueType { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(10, (MetaMemberFlags)0)]
        public string AdvertiserId { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(11, (MetaMemberFlags)0)]
        public string NetworkId { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(12, (MetaMemberFlags)0)]
        public MergeBoardId MergeBoardId { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public Coordinate BubbleCoordinates { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public AnalyticsContext AnalyticsContext { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(15, (MetaMemberFlags)0)]
        public OfferPlacementId OfferPlacementId { get; set; }

        [IgnoreDataMember]
        public ICollection<MergeBoardAct> ProductActs { get; set; }

        public AdsRewardData()
        {
        }

        public AdsRewardData(string adsProviderIds, AdvertisementPlacementId adPlacementId, string itemName, string auctionId, ShopItemId shopItemId, int itemDiamondValue, AdsRewardType adsRewardType, int itemCostValue, Currencies itemCostValueType, string advertiserId, string networkId, MergeBoardId mergeBoardId, Coordinate itemCoordinates, AnalyticsContext analyticsContext, OfferPlacementId offerPlacementId, ICollection<MergeBoardAct> productActs)
        {
        }
    }
}
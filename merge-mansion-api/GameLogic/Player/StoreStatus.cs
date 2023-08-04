using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using Merge;
using System.Runtime.Serialization;

namespace GameLogic.Player
{
    [MetaBlockedMembers(new int[] { 1, 2, 4, 5, 6, 7, 8, 10, 11, 12, 13, 14, 17, 18, 19, 21, 22 })]
    [MetaSerializable]
    public class StoreStatus
    {
        private static int PurchaseHistoryLength;
        [MetaMember(3, (MetaMemberFlags)0)]
        private Dictionary<ShopItemId, int> currentFlashSaleItemsAndAmounts;
        [MetaMember(9, (MetaMemberFlags)0)]
        private List<ShopItemId> CurrentShopItems { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        private long SeenShopOfferSet { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        private long LastShopOfferSet { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        private Dictionary<ShopItemId, StoreStatus.PurchaseHistory> RecordedPurchases { get; set; }

        [MetaMember(23, (MetaMemberFlags)0)]
        private StoreStatus.AutoOfferInfo ActiveAutoOfferInfo { get; set; }

        [MetaMember(24, (MetaMemberFlags)0)]
        public MetaTime? GarageShopLastOpened_DEPRECATED { get; set; }

        [MetaMember(25, (MetaMemberFlags)0)]
        public Dictionary<MergeBoardId, MetaTime> ShopLastOpenedTimes { get; set; }

        public StoreStatus()
        {
        }

        [MetaSerializable]
        public class PurchaseHistory
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public long AllTimeTotal { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public List<StoreStatus.PurchaseRecord> RecentRecords { get; set; }

            public PurchaseHistory()
            {
            }
        }

        [MetaSerializable]
        public class PurchaseRecord
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public MetaTime LastPurchase { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public long Quantity { get; set; }

            public PurchaseRecord()
            {
            }
        }

        [MetaSerializable]
        public class AutoOfferInfo
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public string OfferGroupId { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public MetaTime LastAutoOfferPopup { get; set; }

            [MetaMember(3, (MetaMemberFlags)0)]
            public int AutoOfferSeenCount { get; set; }

            [IgnoreDataMember]
            public bool AutoOfferSeenThisSession { get; set; }

            [IgnoreDataMember]
            public bool BlockAutoOfferThisSession { get; set; }

            public AutoOfferInfo()
            {
            }
        }
    }
}
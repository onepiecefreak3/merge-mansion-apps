using Metaplay.Core.Model;
using System;
using GameLogic.Advertisement;

namespace GameLogic
{
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 4 })]
    public class AdsData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public string placementId;
        [ExcludeFromGdprExport]
        [MetaMember(2, (MetaMemberFlags)0)]
        public bool canBeClaimed;
        [ExcludeFromGdprExport]
        [MetaMember(3, (MetaMemberFlags)0)]
        public AdsRewardType rewardType;
        [MetaMember(5, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public ShopItemId shopItemId;
        public AdsData()
        {
        }
    }
}
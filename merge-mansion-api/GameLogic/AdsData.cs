using Metaplay.Core.Model;
using System;
using GameLogic.Advertisement;

namespace GameLogic
{
    [MetaSerializable]
    public class AdsData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public string placementId;
        [MetaMember(2, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public bool canBeClaimed;
        [MetaMember(3, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public AdsRewardType rewardType;
        [ExcludeFromGdprExport]
        [MetaMember(4, (MetaMemberFlags)0)]
        public ShopItemId shopItemId;
        public AdsData()
        {
        }
    }
}
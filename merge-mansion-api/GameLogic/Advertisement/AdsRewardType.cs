using Metaplay.Core.Model;

namespace GameLogic.Advertisement
{
    [MetaSerializable]
    public enum AdsRewardType
    {
        None = 0,
        FlashSaleItem = 1,
        FlashSaleRefresh = 2,
        OutOfEnergy = 3,
        ClaimBubble = 4
    }
}
using Metaplay.Core.Model;

namespace GameLogic.Advertisement
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum AdsRewardType
    {
        None = 0,
        FlashSaleItem = 1,
        FlashSaleRefresh = 2,
        OutOfEnergy = 3,
        ClaimBubble = 4,
        ProducerCooldown = 5,
        DailyAdMainHud = 6,
        DailyEnergyChest = 7
    }
}
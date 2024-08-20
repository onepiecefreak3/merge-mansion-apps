using Metaplay.Core.Model;

namespace Code.GameLogic.StatsTracking
{
    [MetaSerializable]
    public enum StatsTrackingType
    {
        SpendResource = 0,
        UseProducer = 1,
        BurstBubbles = 2,
        Merge = 3,
        CollectResource = 4,
        ClaimFromShopWithCoins = 5,
        ClaimFromShopWithGems = 6,
        CompleteTasks = 7,
        OpenChests = 8
    }
}
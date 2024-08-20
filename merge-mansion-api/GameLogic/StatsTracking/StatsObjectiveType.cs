using Metaplay.Core.Model;

namespace GameLogic.StatsTracking
{
    [MetaSerializable]
    public enum StatsObjectiveType
    {
        Merge = 1,
        SpendResource = 2,
        UseProducer = 3,
        BurstBubbles = 4,
        CollectResource = 5,
        ClaimFromShop = 6,
        CompleteTasks = 7,
        OpenChests = 8
    }
}
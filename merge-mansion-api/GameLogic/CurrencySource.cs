using Metaplay.Core.Model;

namespace GameLogic
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum CurrencySource
    {
        Unknown = 0,
        TestCase = 1,
        DebugMenu = 2,
        Regeneration = 3,
        ForcedGameReset = 4,
        SupportGivenReward = 5,
        IAPPurchase = 6,
        ShopPurchase = 7,
        SimulationAction = 8,
        ItemCollected = 9,
        ItemSold = 10,
        HotspotCompleted = 11,
        SocialLoginReward = 13,
        SocialMediaReward = 14,
        IAPShopOfferPurchase = 15,
        BoardEventTaskClaim = 16,
        GameEventLevelUp = 17,
        GameEventEndedCurrencyConversion = 18,
        ShopEventOfferPurchase = 19,
        SurveyReward = 20,
        Migration = 21,
        DailyTaskReward = 22,
        DiscoveryReward = 23,
        CurrencyBank = 24,
        GarageCleanup = 25,
        AreaCompleted = 26,
        AutoCollected = 27,
        EventOfferSetCompleted = 28,
        ItemAttachment = 29,
        LeaderboardEventReward = 30,
        BubblePurchased = 31,
        ReEngagement = 32,
        FlashSalePurchase = 33,
        BotDailyGain = 34,
        StoryEvent = 35,
        EventExtended = 36,
        ThirdPartySurveyReward = 12,
        WorldRecordWeight = 37,
        ResetBetweenEvents = 38,
        WeightStar = 39,
        ProgressionEventStreak = 40,
        BonusTimerCompleted = 41,
        DecorationShopPurchase = 42,
        EventShopPurchase = 43,
        ItemInfoPopupShopPurchase = 44,
        SideBoardEventResourceItemSpawn = 45,
        AdReward = 46,
        InsertMachineCoin = 47,
        MysteryMachineMerge = 48,
        MachineTaskCompleted = 49,
        MysteryMachineContinue = 50,
        Tutorial = 51,
        DailyTaskV2Reward = 52,
        ItemActivation = 53,
        SoloMilestone = 54,
        DailyScoop = 55,
        WeeklyMilestone = 56,
        TaskGroupCompleted = 57,
        MysteryMachineLeaderboard = 58,
        BoultonLeagueEventReward = 59,
        BoultonLeagueEventDailyTaskV2Reward = 60,
        CardCollectionEventReward = 61,
        CardCollectionEventPrestigeReward = 62,
        CardCollectionCardSetReward = 63,
        CardCollectionDuplicateCardReward = 64,
        EventFallbackReward = 65,
        CardCollectionEvidenceBoxPurchase = 66,
        CardCollectionCraftCard = 67,
        FromChest = 68,
        SoloMilestoneEventDailyTaskV2Reward = 69,
        DifficultHotspotCompleted = 70,
        PrisonerLetter = 71,
        PrisonerBadge = 72,
        CombinedReward = 73,
        ShortLeaderboardEventStageCompleted = 74,
        ShortLeaderboardEventFinalReward = 75,
        ShortLeaderboardEventStageJoinRequested = 76,
        ProgressionPackss = 77
    }
}
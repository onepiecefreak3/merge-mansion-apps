using Metaplay.Core.Model;
using System;

namespace Analytics
{
    [MetaSerializable]
    public enum AnalyticsEventType
    {
        None = 0,
        TutorialStepCompleted = 1,
        MergeGoalCompleted = 2,
        OldPlayerReturned = 3,
        PlayerLeveledUp = 4,
        BubblePurchased = 5,
        BubbleExpired = 6,
        CurrencySinkEvent = 7,
        PurchaseEvent = 8,
        MergeGoalUnlocked = 9,
        RevenueEvent = 10,
        ErrorEvent = 11,
        CurrencyGainEvent = 12,
        WarningEvent = 13,
        InfoEvent = 14,
        OfferImpression = 15,
        DialogueSkip = 16,
        ItemDiscoveredEvent = 17,
        EventStateChanged = 18,
        EventProgressCollected = 19,
        EventRewardsCollected = 20,
        DialogueView = 21,
        AttachAuthMethod = 22,
        ItemMerge = 23,
        StoryStepCompleted = 24,
        DailyTaskCompleted = 25,
        [Obsolete("Not used since 23.06.01")]
        DailyTaskUIOpened = 26,
        AudioChanged = 27,
        FirstOpen = 28,
        SessionStart = 29,
        SessionEnd = 30,
        Snapshot = 31,
        SurveyReady = 32,
        SurveyStarted = 33,
        SurveySubmitted = 34,
        SurveyError = 35,
        WebviewError = 36,
        SurveyResults = 37,
        MergeBoardTransition = 38,
        PlayerRewardGained = 39,
        GameEventLevelUp = 40,
        BoardEventTaskChanged = 41,
        DecorationSlotChanged = 42,
        ToSAccepted = 43,
        WebViewMailOpened = 44,
        PlayerIncident = 45,
        BroadcastReceived = 46,
        MailImpression = 47,
        MailOpened = 48,
        GameEventStateChanged = 49,
        [Obsolete("Not used anymore, please see BoosterUsed", true)]
        TimeSkipBoosterUsed = 50,
        BoardStateSnapshot = 51,
        BoosterUsed = 52,
        ChainCompletionRewardClaimed = 53,
        ConnectionFailed = 54,
        PlayersSegments = 57,
        GarageCleanupSlotFilled = 58,
        GarageCleanupEventVisited = 59,
        GarageCleanupBuyLevel = 60,
        GarageCleanupSpawnerItemClaimed = 61,
        SlideChanged = 62,
        VideoPlaybackFinished = 63,
        BoardActivationsLeft = 64,
        FlashSaleImpression = 65,
        PlayerDeleted = 66,
        ProgressionEventItemCollected = 67,
        PlayerInitiatedReset = 68,
        SocialMediaPopupInteraction = 69,
        DeviceFreeRam = 70,
        DeviceTotalRam = 71,
        InAppPurchaseValidationComplete = 72,
        InAppPurchaseClientRefused = 73,
        AddressableEvent = 74,
        PlayerDeviceInformation = 75,
        GameLaunchingSteps = 76,
        GeneralOfferImpression = 77,
        CurrencyBankAction = 78,
        PlayerMapping = 79,
        CurrencyBankStateChanged = 80,
        LevelUpMergeChain = 81,
        LeaderboardEventScoreChanged = 82,
        LeaderboardSnapshot = 83,
        BoardImpression = 84,
        DailyTaskFirstImpression = 85,
        BotSessionStart = 86,
        BotSessionEnd = 87,
        ThirdPartySurveyCompleted = 55,
        ThirdPartySurveyStarted = 56,
        DailyTasksRefreshPurchase = 88,
        PlayerCreated = 89,
        FishCaught = 90,
        ItemSink = 91,
        ScreenChange = 92,
        AppsflyerConversion = 93,
        AppsflyerInitialization = 94,
        BotTestStart = 95,
        BotTestEnd = 96,
        DecorationShopImpression = 97,
        PetChanged = 98,
        CobwebCleared = 99,
        PortalPieceChain = 100,
        SetPlayerModeActive = 101,
        BroadcastCreated = 102,
        WebShopSignIn = 103,
        WebShopPurchase = 104,
        AdPlacementShown = 105,
        AdStarted = 106,
        AdFinished = 107,
        AdImpression = 108,
        MachineScore = 109,
        MachineTaskCompleted = 110,
        ActiveLogicVersionChanged = 111,
        SceneChange = 112,
        ShopItemIapImpression = 113,
        DailyTaskV2StateChanged = 114,
        DailyTasksV2StreakChanged = 115,
        CutsceneView = 116,
        ItemSpawnedByMerge = 117,
        HapticsChanged = 118,
        SoloMilestoneTokenReceived = 119,
        DailyScoopProgress = 120,
        DailyScoopTaskStatusChanged = 121,
        DailyScoopDayStarted = 122,
        ItemSinkTransform = 123,
        UiInteraction = 124
    }
}
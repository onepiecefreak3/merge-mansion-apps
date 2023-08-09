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
        Traits12SurveyCompleted = 55,
        Traits12SurveyStarted = 56,
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
        BotSessionEnd = 87
    }
}
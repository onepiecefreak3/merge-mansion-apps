using Metaplay.Core.Model;
using System;

namespace GameLogic.GameFeatures
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum GameFeatureId
    {
        None = 0,
        DailyTasksMenu = 1,
        ShopOffers = 2,
        Music = 3,
        [Obsolete]
        ServersideAnalytics = 4,
        [Obsolete("Use event specific preview & unlock instead")]
        GameEvents = 5,
        Surveys = 6,
        AnalyticsApiGateway = 7,
        HelpshiftFeedback = 8,
        [Obsolete("Use GameConfig.SocialAuthentication instead")]
        SupercellID = 9,
        AndroidNativeReviewFlow = 10,
        SpawnerCooldownTimerEnabled = 11,
        Inventory = 12,
        Shop = 13,
        TaskList = 14,
        Codex = 15,
        [Obsolete("Use event specific preview & unlock instead")]
        GarageCleanupEvents = 16,
        BubbleDismissButtonEnabled = 17,
        BubbleDiscountBadgeEnabled = 18,
        ShopDiscountBadgeEnabled = 19,
        BubblesEnabled = 20,
        ArtifactsEnabled = 21,
        Inbox = 22,
        MetaplaySDKIAPEnabled = 23,
        CurrencyBank = 24,
        ShopRealMoneyDiscountBadgeEnabled = 25,
        AnimatedDialogueText = 26,
        SCIDRewardingFlow = 27,
        PlayerName = 28,
        SCIDIncentivicedFlow = 29,
        TieredOffers = 30,
        ItemNeededBadgeEnabled = 31,
        SinkItemTooltipEnabled = 32,
        RentableInventory = 33,
        ProducerInventory = 34
    }
}
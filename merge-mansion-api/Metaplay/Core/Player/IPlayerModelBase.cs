using Metaplay.Core.Config;
using Metaplay.Core.Localization;
using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using System;
using Metaplay.Core.Session;
using System.Collections.Generic;
using Metaplay.Core.InAppPurchase;
using Metaplay.Core.Math;
using Metaplay.Core.InGameMail;
using Metaplay.Core.Offers;
using Metaplay.Core.Web3;
using Metaplay.Core.Client;
using Metaplay.Core.LiveOpsEvent;

namespace Metaplay.Core.Player
{
    public interface IPlayerModelBase : IModel<IPlayerModelBase>, IModel, ISchemaMigratable, IMetaIntegrationConstructible<IPlayerModelBase>, IMetaIntegration<IPlayerModelBase>, IMetaIntegration, IMetaIntegrationConstructible, IRequireSingleConcreteType
    {
        // STUB
        // RVA: -1 Offset: -1 Slot: 9
        // RVA: -1 Offset: -1 Slot: 10
        ISharedGameConfig GameConfig { get; set; }

        // RVA: -1 Offset: -1 Slot: 34
        // RVA: -1 Offset: -1 Slot: 35
        LanguageId Language { get; set; }

        // RVA: -1 Offset: -1 Slot: 36
        // RVA: -1 Offset: -1 Slot: 37
        LanguageSelectionSource LanguageSelectionSource { get; set; }

        LogChannel Log { get; set; }

        AnalyticsEventHandler<IPlayerModelBase, PlayerEventBase> AnalyticsEventHandler { get; set; }

        IPlayerModelServerListenerCore ServerListenerCore { get; set; }

        IPlayerModelClientListenerCore ClientListenerCore { get; set; }

        MetaTime CurrentTime { get; }

        MetaTime CurrentTimeWithoutDebugTimeOffset { get; }

        EntityId PlayerId { get; set; }

        string PlayerName { get; set; }

        int PlayerLevel { get; }

        MetaTime TimeAtFirstTick { get; }

        int CurrentTick { get; }

        int TicksPerSecond { get; }

        bool IsOnline { get; set; }

        string SessionDeviceGuid { get; set; }

        SessionToken SessionToken { get; set; }

        bool IsBanned { get; set; }

        PlayerTimeZoneInfo TimeZoneInfo { get; set; }

        PlayerLocation? LastKnownLocation { get; set; }

        PlayerStatisticsBase Stats { get; }

        List<string> FirebaseMessagingTokensLegacy { get; }

        PlayerPushNotifications PushNotifications { get; }

        List<InAppPurchaseEvent> InAppPurchaseHistory { get; }

        int NumDuplicateInAppPurchases { get; set; }

        List<InAppPurchaseEvent> DuplicateInAppPurchaseHistory { get; }

        int NumFailedInAppPurchases { get; set; }

        List<InAppPurchaseEvent> FailedInAppPurchaseHistory { get; }

        Dictionary<string, InAppPurchaseEvent> PendingInAppPurchases { get; }

        Dictionary<InAppProductId, PendingDynamicPurchaseContent> PendingDynamicPurchaseContents { get; }

        Dictionary<InAppProductId, PendingNonDynamicPurchaseContext> PendingNonDynamicPurchaseContexts { get; }

        PlayerSubscriptionsModel IAPSubscriptions { get; }

        F64 TotalIapSpend { get; set; }

        List<PlayerMailItem> MailInbox { get; }

        HashSet<int> ReceivedBroadcastIds { get; }

        List<PlayerLoginEvent> LoginHistory { get; }

        Dictionary<string, PlayerDeviceEntry> DeviceHistory { get; }

        Dictionary<AuthenticationKey, PlayerAuthEntryBase> AttachedAuthMethods { get; }

        PlayerDeletionStatus DeletionStatus { get; set; }

        MetaTime ScheduledForDeletionAt { get; set; }

        PlayerEventLog EventLog { get; }

        IPlayerGuildState GuildState { get; }

        int SearchVersion { get; set; }

        PlayerExperimentsState Experiments { get; set; }

        bool IsDeveloper { get; set; }

        bool IsClientConnected { get; set; }

        ClientAppPauseStatus ClientAppPauseStatus { get; set; }

        PlayerPendingSynchronizedServerActions PendingSynchronizedServerActions { get; set; }

        IPlayerMetaOfferGroups MetaOfferGroups { get; }

        PlayerNftSubModel Nft { get; }

        Dictionary<ClientSlot, PlayerSubClientStateBase> PlayerSubClientStates { get; }

        PlayerLiveOpsEventsModel LiveOpsEvents { get; }

        PlayerSessionDebugMode SessionDebugModeOverride { get; set; }
    }
}
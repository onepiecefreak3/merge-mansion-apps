using Metaplay.Core.Model;
using Metaplay.Core.Player;
using Game.Logic;
using GameLogic.Random;
using System;
using Merge;
using Metaplay.Core;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GameLogic.Merge;
using GameLogic.Config;
using GameLogic.Offers;
using Code.GameLogic.GameEvents;
using GameLogic.Banks;
using GameLogic.Player.Board;
using GameLogic.Player.DailyTasks;
using GameLogic.Player.Modifiers;
using GameLogic.Player.Director;
using GameLogic.GameFeatures;
using Analytics;
using GameLogic.Player.ScheduledActions;
using Metaplay.Core.Math;
using GameLogic.Player.Leaderboard;
using Game.Logic.Mail;
using GameLogic.Player.Director.Actions;
using GameLogic.Player.Director.Conditions;
using GameLogic.Inventory;
using GameLogic.Config.DecorationShop;
using GameLogic.Player.Modes;
using Code.GameLogic.DynamicEvents;
using Game.Cloud.Webshop;
using GameLogic.Player.DailyTasksV2;
using Metaplay.Core.Debugging;
using System.Runtime.CompilerServices;
using GameLogic.Config.EnergyModeEvent;
using GameLogic.MiniEvents;
using GameLogic.Player.Events;
using Code.GameLogic.Player.Events.DailyScoopEvent;
using GameLogic.Player.Items;
using GameLogic.Player.Leaderboard.BoultonLeague;

namespace GameLogic.Player
{
    [MetaReservedMembers(99, 300)]
    [MetaReservedMembers(11, 12)]
    [MetaBlockedMembers(new int[] { 6, 108, 110, 112, 114, 116, 117, 200, 205, 208, 220, 224, 239, 241, 251, 233, 274 })]
    [SupportedSchemaVersions(21, 42)]
    [MetaSerializableDerived(1)]
    public class PlayerModel : PlayerModelBase<PlayerModel, PlayerStatisticsCore, PlayerMergeMansionOffersGroupModel, PlayerGuildStateCore>, IPlayer, IGenerationContext
    {
        public static int MaxLoginCounts;
        public static int MaxEnergySpentDays;
        public static int MaxMoneySpentDays;
        public static int TicksPerSecond;
        [Transient]
        [MetaMember(211, (MetaMemberFlags)0)]
        [ServerOnly]
        public Dictionary<MergeBoardId, MetaTime> BoardActivationsLeftAnalyticsEvents;
        [IgnoreDataMember]
        private ICollection<MergeBoardAct> updateActs;
        [IgnoreDataMember]
        public SharedGameConfig GameConfig { get; }

        [IgnoreDataMember]
        public IPlayerModelServerListener ServerListener { get; set; }

        [IgnoreDataMember]
        public IPlayerModelClientListener ClientListener { get; set; }
        public sealed override int PlayerLevel { get; set; }

        [IgnoreDataMember]
        public PlayerLocalTime CurrentLocalTime { get; }

        [IgnoreDataMember]
        public IEnumerable<IActiveOfferGroup> ActiveOfferGroups { get; }

        [IgnoreDataMember]
        public SpawnFactoryState SpawnState { get; }

        [IgnoreDataMember]
        public GarageCleanupEventModel GarageCleanupEventModel { get; }

        [IgnoreDataMember]
        public CurrencyBankModel CurrencyBankModel { get; }

        [ExcludeFromGdprExport]
        [MetaMember(11, (MetaMemberFlags)0)]
        public RandomPCG Random { get; set; }

        [MetaMember(99, (MetaMemberFlags)0)]
        public sealed override EntityId PlayerId { get; set; }

        [MetaMember(100, (MetaMemberFlags)0)]
        public GameSettings GameSettings { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public Statistics Statistics { get; set; }

        [MetaMember(102, (MetaMemberFlags)0)]
        public PlayerIdentity PlayerIdentity { get; set; }

        [MetaMember(103, (MetaMemberFlags)0)]
        public Wallet Wallet { get; set; }

        [MetaMember(104, (MetaMemberFlags)0)]
        public ProgressState ProgressState { get; set; }

        [MetaMember(105, (MetaMemberFlags)0)]
        public StoreStatus StoreStatus { get; set; }

        [MetaMember(106, (MetaMemberFlags)0)]
        public SpawnFactoryState SpawnFactoryState { get; set; }

        [MetaMember(107, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        public BoardInventory GarageBoardInventory { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(109, (MetaMemberFlags)0)]
        public MergeBoard GarageMergeBoard { get; set; }

        [ExcludeFromGdprExport]
        [MetaMember(111, (MetaMemberFlags)0)]
        public MergeBoard EventMergeBoard { get; set; }

        [MetaMember(113, (MetaMemberFlags)0)]
        public WeightedDistributionStates DistributionStates { get; set; }

        [MetaMember(115, (MetaMemberFlags)0)]
        public DailyTaskStatus DailyTaskStatus { get; set; }

        [MetaMember(201, (MetaMemberFlags)0)]
        [Transient]
        public MergeBoardId ActiveMergeBoardId { get; set; }

        [MetaMember(202, (MetaMemberFlags)0)]
        public PlayerBoardEventsModel BoardEvents { get; set; }

        [MetaMember(203, (MetaMemberFlags)0)]
        public PlayerShopEventsModel ShopEvents { get; set; }

        [MetaMember(204, (MetaMemberFlags)0)]
        private List<IPlayerModifier> PlayerModifiers { get; set; }

        [MetaMember(206, (MetaMemberFlags)0)]
        private int ScriptedEventNextId { get; set; }

        [MetaMember(207, (MetaMemberFlags)0)]
        private List<ScriptedEvent> RegisteredScriptedEvents { get; set; }

        [MetaMember(210, (MetaMemberFlags)0)]
        public PlayerGarageCleanupEventsModel GarageCleanupEvents { get; set; }

        [MetaMember(212, (MetaMemberFlags)0)]
        public PlayerProgressionEventsModel ProgressionEvents { get; set; }

        [MetaMember(213, (MetaMemberFlags)0)]
        private bool HadArtifactsEnabled { get; set; }

        [MetaMember(214, (MetaMemberFlags)0)]
        public GameFeaturesStates UnlockedFeatures { get; set; }

        [MetaMember(215, (MetaMemberFlags)0)]
        public List<MetaTime> SessionsInTheLast240HoursStartAt { get; set; }

        [ServerOnly]
        [MetaMember(216, (MetaMemberFlags)0)]
        public SupercellIdBindingState SupercellIdBindingState { get; set; }

        [MetaMember(217, (MetaMemberFlags)0)]
        [Transient]
        public string AnalyticsApiKey { get; set; }

        [MetaMember(218, (MetaMemberFlags)0)]
        public SortedDictionary<int, int> LoginCountsPerDay { get; set; }

        [MetaMember(219, (MetaMemberFlags)0)]
        public HashSet<PlayerSegmentId> ForcedSegments { get; set; }

        [MetaMember(261, (MetaMemberFlags)0)]
        [ServerOnly]
        public Queue<PlayerAnalyticsEventDPL2> AnalyticsEvents { get; set; }

        [ServerOnly]
        [MetaMember(221, (MetaMemberFlags)0)]
        public int NumOfResets { get; set; }

        [MetaMember(222, (MetaMemberFlags)0)]
        public PlayerScheduledActions ScheduledActions { get; set; }

        [MetaMember(223, (MetaMemberFlags)0)]
        public CurrencyBanksModel CurrencyBanksModel { get; set; }

        [MetaMember(225, (MetaMemberFlags)0)]
        public ClientPlatform LastClientPlatform { get; set; }

        [MetaMember(226, (MetaMemberFlags)0)]
        public PlayerCollectibleBoardEventsModel CollectibleBoardEvents { get; set; }

        [NoChecksum]
        [MetaMember(227, (MetaMemberFlags)0)]
        public sealed override string PlayerName { get; set; }

        [MetaMember(228, (MetaMemberFlags)0)]
        public PlayerLeaderboardEventsModel LeaderboardEvents { get; set; }

        [MetaMember(229, (MetaMemberFlags)0)]
        public ulong Flags { get; set; }

        [MetaMember(230, (MetaMemberFlags)0)]
        public SortedDictionary<int, F64> MoneySpentPerDay { get; set; }

        [MetaMember(231, (MetaMemberFlags)0)]
        public SortedDictionary<int, long> EnergySpentPerDay { get; set; }

        [MetaMember(232, (MetaMemberFlags)0)]
        public ReEngagementSettingsId ReEngagementSettingsId { get; set; }

        [MetaMember(234, (MetaMemberFlags)0)]
        public MetaDuration DebugTimeOffsetValue { get; set; }
        public override MetaDuration DebugTimeOffset { get; }
        public bool HasPendingSupercellIdBinding { get; }
        public bool IsBoundToSCID { get; }

        [IgnoreDataMember]
        public IEnumerable<IBoard> Boards { get; }

        [IgnoreDataMember]
        public IEnumerable<ValueTuple<IBoard, MetaTime?>> BoardsWithExpirationTimes { get; }
        public IEnumerable<IMailMessage> MailMessages { get; }
        public IEnumerable<GarageCleanupEventModel> ActiveGarageCleanups { get; }
        public IEnumerable<BoardEventModel> ActiveBoardEvents { get; }
        public IEnumerable<CollectibleBoardEventModel> ActiveCollectibleBoardEvents { get; }
        public IEnumerable<LeaderboardEventModel> ActiveLeaderboardEvents { get; }
        public IEnumerable<ShopEventModel> ActiveShopEvents { get; }
        public IEnumerable<ProgressionEventModel> ActiveProgressionEvents { get; }
        public IEnumerable<IPlayerModifier> ActiveModifiers { get; }

        [IgnoreDataMember]
        public IReadOnlyList<ScriptedEvent> ScriptedEvents { get; }

        public PlayerModel()
        {
        }

        [MetaMember(209, (MetaMemberFlags)0)]
        public Dictionary<int, ThirdPartySurveyStatus> CompletedThirdPartySurveys { get; set; }

        [MetaMember(235, (MetaMemberFlags)0)]
        private List<ProgressionEventId> ProgressionEventIAPStreaks { get; set; }

        [MetaMember(236, (MetaMemberFlags)0)]
        public BoardInventory RentableBoardInventory { get; set; }

        [MetaMember(237, (MetaMemberFlags)0)]
        public MetaTime RentableInventoryExpirationTime { get; set; }

        [MetaMember(238, (MetaMemberFlags)0)]
        public int RentableInventoryBoughtBatchCount { get; set; }

        [IgnoreDataMember]
        public ValueTuple<BoardInventory, MetaTime?> RentableInventory { get; }

        [IgnoreDataMember]
        public bool IsRentableInventoryExpired { get; }

        [IgnoreDataMember]
        public int ProgressionEventIAPStreakLength { get; }

        [MetaMember(240, (MetaMemberFlags)0)]
        public BoardInventory GarageBoardProducerInventory { get; set; }

        [MetaMember(244, (MetaMemberFlags)0)]
        private MetaTime? previousIntervalCheckTime;
        [MetaMember(242, (MetaMemberFlags)0)]
        public RentableInventoryState RentableInventoryState { get; set; }

        [MetaMember(243, (MetaMemberFlags)0)]
        public List<string> UnlockedSongs { get; set; }

        [MetaMember(245, (MetaMemberFlags)0)]
        public PlayerDecorationShopsModel DecorationShops { get; set; }

        [MetaMember(246, (MetaMemberFlags)0)]
        public HashSet<PlayerModeId> ActiveModes { get; set; }

        [MetaMember(247, (MetaMemberFlags)0)]
        [Transient]
        public bool IsProductionEnvironment { get; set; }
        public DynamicEventTaskStatus DynamicEventTaskStatus { get; set; }
        public PlayerModifiersChangedEvent ModifiersChanged { get; set; }
        public PlayerModesChangedEvent ModesChanged { get; set; }

        [MetaMember(248, (MetaMemberFlags)0)]
        public BanInfo BanInfo { get; set; }

        [MetaMember(249, (MetaMemberFlags)0)]
        public Dictionary<LocationId, F64Vec2> CameraPositionPerLocation { get; set; }

        [MetaMember(250, (MetaMemberFlags)0)]
        public PlayerSideBoardEventsModel SideBoardEvents { get; set; }

        [MetaMember(252, (MetaMemberFlags)0)]
        public Dictionary<int, RandomPCG> RandomsByFishingRodType { get; set; }

        [MetaMember(253, (MetaMemberFlags)0)]
        public OverrideSpawnItemsStatus OverrideSpawnItemsStatus { get; set; }
        public IEnumerable<SideBoardEventModel> ActiveSideBoardEvents { get; }
        public IEnumerable<GarageCleanupEventModel> AllGarageCleanups { get; }
        public IEnumerable<SideBoardEventModel> AllSideBoardEvents { get; }
        public List<IPlayerModifier> ActiveModifiersNonAlloc { get; }

        [MetaMember(254, (MetaMemberFlags)0)]
        public WebshopState WebshopState { get; set; }

        [MetaMember(255, (MetaMemberFlags)0)]
        public PlayerMysteryMachineEventsModel MysteryMachineEvents { get; set; }

        [MetaMember(256, (MetaMemberFlags)0)]
        public RandomPCG MysteryMachineRandom { get; set; }

        [MetaMember(257, (MetaMemberFlags)0)]
        public int MysteryMachineEventsStarted { get; set; }
        public IEnumerable<MysteryMachineEventModel> ActiveMysteryMachineEvents { get; }

        [MetaMember(258, (MetaMemberFlags)0)]
        public bool MysteryMachineAllTasksCompletedRewardClaimed_DEPRECATED { get; set; }

        [MetaMember(259, (MetaMemberFlags)0)]
        public List<BoardInventory.ProducerInventorySlotState> ProducerInventoryEntries { get; set; }

        [MetaMember(260, (MetaMemberFlags)0)]
        public int MysteryMachineAllTasksCompletedRewardClaimedEventInstance { get; set; }

        [IgnoreDataMember]
        public string SessionConfigVersion { get; set; }

        [IgnoreDataMember]
        public string ServerBuildVersion { get; set; }

        [MetaMember(262, (MetaMemberFlags)0)]
        public Dictionary<MetaTime, MetaDuration> SessionData { get; set; }

        [MetaMember(263, (MetaMemberFlags)0)]
        public DailyTasksV2Status DailyTasksV2Status { get; set; }

        [MetaMember(264, (MetaMemberFlags)0)]
        public bool HasAds { get; set; }

        [MetaMember(265, (MetaMemberFlags)0)]
        public UnitySystemInfo UnitySystemInfo { get; set; }

        [MetaMember(266, (MetaMemberFlags)0)]
        public PlayerEnergyModeEventsModel EnergyModeEvents { get; set; }

        [MetaMember(267, (MetaMemberFlags)0)]
        public PlayerMiniEventsModel MiniEvents { get; set; }

        [MetaMember(268, (MetaMemberFlags)0)]
        public PlayerMiniEventOverrides MiniEventOverrides { get; set; }

        [MetaMember(269, (MetaMemberFlags)0)]
        public PlayerSoloMilestoneEventModel SoloMilestoneEvents { get; set; }

        [MetaMember(270, (MetaMemberFlags)0)]
        public int SoloMilestoneEventsStarted { get; set; }

        [MetaMember(271, (MetaMemberFlags)0)]
        public RandomPCG SoloMilestoneRandom { get; set; }

        [MetaMember(272, (MetaMemberFlags)0)]
        public PlayerDailyScoopEventModel DailyScoopEvents { get; set; }

        [ServerOnly]
        [MetaMember(273, (MetaMemberFlags)0)]
        public List<int> MassMailsReceived { get; set; }

        [IgnoreDataMember]
        public LeaderboardClientState LeaderboardClientState { get; }
        public IEnumerable<DailyScoopEventModel> ActiveDailyScoopEvents { get; }
        public IEnumerable<SoloMilestoneEventModel> ActiveSoloMilestoneEvents { get; }
        public IEnumerable<MiniEventModel> ActiveMiniEvents { get; }

        [IgnoreDataMember]
        public Dictionary<string, Coordinate> BubblesWithAds { get; }

        [MetaMember(275, (MetaMemberFlags)0)]
        public RandomPCG RewardContainerRandom { get; set; }

        [MetaMember(276, (MetaMemberFlags)0)]
        public PlayerMysteryMachineLeaderboardRewardsState MysteryMachineLeaderboardRewardsState { get; set; }

        [MetaMember(277, (MetaMemberFlags)0)]
        public PlayerBoultonLeagueEventsModel BoultonLeagueEvents { get; set; }

        [MetaMember(278, (MetaMemberFlags)0)]
        public BoultonLeagueStatus BoultonLeagueStatus { get; set; }

        [MetaMember(279, (MetaMemberFlags)0)]
        public PlayerTemporaryCardCollectionEventsModel TemporaryCardCollectionEvents { get; set; }

        [MetaMember(280, (MetaMemberFlags)0)]
        public Dictionary<string, Coordinate> bubbleAdsDictionary { get; set; }

        [IgnoreDataMember]
        public BoultonLeagueDivisionClientState BoultonLeagueDivisionClientState { get; }
        public IEnumerable<TemporaryCardCollectionEventModel> ActiveTemporaryCardCollectionEvents { get; }

        [MetaMember(281, (MetaMemberFlags)0)]
        public RandomPCG StackMiniGameRandom { get; set; }
    }
}
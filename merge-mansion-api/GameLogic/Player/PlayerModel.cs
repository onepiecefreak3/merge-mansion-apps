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

namespace GameLogic.Player
{
    [MetaSerializableDerived(1)]
    [MetaReservedMembers(99, 300)]
    [MetaReservedMembers(11, 12)]
    [MetaBlockedMembers(new int[] { 6, 108, 110, 112, 114, 116, 200, 205, 208, 220, 224 })]
    [SupportedSchemaVersions(21, 27)]
    public class PlayerModel : PlayerModelBase<PlayerModel, PlayerStatisticsCore, PlayerMergeMansionOffersGroupModel, PlayerGuildStateCore>, IPlayer, IGenerationContext
    {
        public static int MaxLoginCounts;
        public static int MaxEnergySpentDays;
        public static int MaxMoneySpentDays;
        public static int TicksPerSecond;
        [Transient]
        [ServerOnly]
        [MetaMember(211, (MetaMemberFlags)0)]
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

        [MetaMember(11, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
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

        [ExcludeFromGdprExport]
        [MetaMember(107, (MetaMemberFlags)0)]
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

        [MetaMember(117, (MetaMemberFlags)0)]
        public Surveys Surveys { get; set; }

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

        [MetaMember(233, (MetaMemberFlags)0)]
        [ServerOnly]
        public Queue<PlayerAnalyticsEventDPL2> AnalyticsEvents { get; set; }

        [MetaMember(221, (MetaMemberFlags)0)]
        [ServerOnly]
        public int NumOfResets { get; set; }

        [MetaMember(222, (MetaMemberFlags)0)]
        public PlayerScheduledActions ScheduledActions { get; set; }

        [MetaMember(223, (MetaMemberFlags)0)]
        public CurrencyBanksModel CurrencyBanksModel { get; set; }

        [MetaMember(225, (MetaMemberFlags)0)]
        public ClientPlatform LastClientPlatform { get; set; }

        [MetaMember(226, (MetaMemberFlags)0)]
        public PlayerCollectibleBoardEventsModel CollectibleBoardEvents { get; set; }

        [MetaMember(227, (MetaMemberFlags)0)]
        [NoChecksum]
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
        public DivisionClientState DivisionClientState { get; }

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

        [IgnoreDataMember]
        public bool ShouldUpdateRentableInventoryExpiration;
        [MetaMember(240, (MetaMemberFlags)0)]
        public BoardInventory GarageBoardProducerInventory { get; set; }

        [MetaMember(241, (MetaMemberFlags)0)]
        public F64Vec2 CameraPosition { get; set; }
    }
}
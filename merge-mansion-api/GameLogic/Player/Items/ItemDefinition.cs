using System.Collections.Generic;
using GameLogic.MergeChains;
using GameLogic.Player.Director.Config;
using GameLogic.Player.Items.Activation;
using GameLogic.Player.Items.Boosting;
using GameLogic.Player.Items.Bubble;
using GameLogic.Player.Items.Charges;
using GameLogic.Player.Items.Chest;
using GameLogic.Player.Items.Collectable;
using GameLogic.Player.Items.Consumption;
using GameLogic.Player.Items.Decay;
using GameLogic.Player.Items.Merging;
using GameLogic.Player.Items.Sink;
using GameLogic.Player.Items.Spawning;
using GameLogic.Player.Items.TimeContainer;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Math;
using Metaplay.Core.Model;
using System;
using Code.GameLogic.Config;
using GameLogic.Player.Items.Leaderboard;
using GameLogic.Player.Rewards;
using System.Runtime.Serialization;
using GameLogic.Config;
using GameLogic.Player.Items.Fishing;
using GameLogic.Player.Items.Sinkable;
using GameLogic.Player.Items.Persistent;
using GameLogic.Player.Requirements;
using GameLogic.Player.Items.OverrideSpawnChance;
using GameLogic.ConfigPrefabs;
using GameLogic.Player.Items.MiniEvents;
using GameLogic.Player.Items.Order;
using GameLogic.Player.Items.GemMining;
using GameLogic.Player.Items.TheGreatEscape;

namespace GameLogic.Player.Items
{
    [MetaSerializable]
    public class ItemDefinition : IGameConfigData<int>, IGameConfigData, IHasGameConfigKey<int>, IValidatable
    {
        [MetaMember(12, (MetaMemberFlags)0)]
        private MergeFeatures _MergeFeatures;
        [MetaMember(13, (MetaMemberFlags)0)]
        private ActivationFeatures _ActivationFeatures;
        [MetaMember(14, (MetaMemberFlags)0)]
        private SpawnFeatures _SpawnFeatures;
        [MetaMember(15, (MetaMemberFlags)0)]
        private DecayFeatures _DecayFeatures;
        [MetaMember(16, (MetaMemberFlags)0)]
        private ChestFeatures _ChestFeatures;
        [MetaMember(17, (MetaMemberFlags)0)]
        private CollectableFeatures _CollectableFeatures;
        [MetaMember(18, (MetaMemberFlags)0)]
        private BoosterFeatures _BoosterFeatures;
        [MetaMember(19, (MetaMemberFlags)0)]
        private BubbleFeatures _BubbleFeatures;
        [MetaMember(20, (MetaMemberFlags)0)]
        private SinkFeatures _SinkFeatures;
        [MetaMember(21, (MetaMemberFlags)0)]
        private ConsumableFeatures _ConsumableFeatures;
        [MetaMember(22, (MetaMemberFlags)0)]
        private PortalFeatures _PortalFeatures;
        [MetaMember(23, (MetaMemberFlags)0)]
        private ChargesFeatures _ChargesFeatures;
        [MetaMember(24, (MetaMemberFlags)0)]
        private TimeContainerFeatures _TimeContainer;
        [MetaMember(34, (MetaMemberFlags)0)]
        private LeaderboardFeatures _LeaderboardFeatures;
        [MetaMember(1, (MetaMemberFlags)0)]
        public int ConfigKey { get; set; } // 0x10

        [MetaMember(2, (MetaMemberFlags)0)]
        public string PoolTag { get; set; } // 0x18

        [MetaMember(3, (MetaMemberFlags)0)]
        public string SkinName { get; set; } // 0x20

        [MetaMember(4, (MetaMemberFlags)0)]
        public int LevelNumber { get; set; } // 0x28

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool Movable { get; set; } // 0x2C

        [MetaMember(6, (MetaMemberFlags)0)]
        public F64 CostInDiamonds { get; set; } // 0x30

        [MetaMember(7, (MetaMemberFlags)0)]
        private F64 AnchorPriceGems { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        private F64 AnchorPriceCoins { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public F64 TimeSkipPriceGems { get; set; } // 0x48

        [MetaMember(10, (MetaMemberFlags)0)]
        public F64 UnlockOnBoardPriceGems { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public int ExperienceValue { get; set; }

        [IgnoreDataMember]
        public MergeFeatures MergeFeatures => _MergeFeatures;

        [IgnoreDataMember]
        public ActivationFeatures ActivationFeatures => _ActivationFeatures;

        [IgnoreDataMember]
        public SpawnFeatures SpawnFeatures => _SpawnFeatures;

        [IgnoreDataMember]
        public DecayFeatures DecayFeatures => _DecayFeatures;

        [IgnoreDataMember]
        public ChestFeatures ChestFeatures => _ChestFeatures;

        [IgnoreDataMember]
        public CollectableFeatures CollectableFeatures => _CollectableFeatures;

        [IgnoreDataMember]
        public BoosterFeatures BoosterFeatures => _BoosterFeatures;

        [IgnoreDataMember]
        public BubbleFeatures BubbleFeatures => _BubbleFeatures;

        [IgnoreDataMember]
        public SinkFeatures SinkFeatures => _SinkFeatures;

        [IgnoreDataMember]
        public ConsumableFeatures ConsumableFeatures => _ConsumableFeatures;

        [IgnoreDataMember]
        public PortalFeatures PortalFeatures => _PortalFeatures;

        [IgnoreDataMember]
        public ChargesFeatures ChargesFeatures => _ChargesFeatures;

        [IgnoreDataMember]
        public TimeContainerFeatures TimeContainer => _TimeContainer;

        [MetaMember(25, (MetaMemberFlags)0)]
        public List<string> Tags { get; set; }

        [MetaMember(26, (MetaMemberFlags)0)]
        public MetaRef<MergeChainDefinition> MergeChainRef { get; set; }

        [MetaMember(27, (MetaMemberFlags)0)]
        public List<string> ConfirmableMergeResults { get; set; }

        [MetaMember(28, (MetaMemberFlags)0)]
        private List<IDirectorAction> OnDiscoveredActions { get; set; }

        [MetaMember(29, (MetaMemberFlags)0)]
        public bool ShowTutorialFingerOnDiscovery { get; set; }

        [MetaMember(30, (MetaMemberFlags)0)]
        public List<string> AnalyticsMetaData { get; set; }

        [MetaMember(31, (MetaMemberFlags)0)]
        public List<int> CombineInfoWithItem { get; set; }

        [MetaMember(32, (MetaMemberFlags)0)]
        public ItemRarity Rarity { get; set; }

        [MetaMember(33, (MetaMemberFlags)0)]
        public bool Unsellable { get; set; }

        [MetaMember(35, (MetaMemberFlags)0)]
        public string ItemType { get; set; }

        [MetaMember(36, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        [IgnoreDataMember]
        public LeaderboardFeatures LeaderboardFeatures => _LeaderboardFeatures;

        [IgnoreDataMember]
        public MergeChainDefinition MergeChain => MergeChainRef.Ref;

        [IgnoreDataMember]
        public IEnumerable<IDirectorAction> OnDiscovered => OnDiscoveredActions;
        public bool IsMaxLevel => MergeChain.IsLastItem(ConfigKey);

        public ItemDefinition()
        {
        }

        public ItemDefinition(int configKey, string itemType, string poolTag, string skinName, int levelNumber, bool movable, F64 costInDiamonds, F64 anchorPriceGems, F64 anchorPriceCoins, F64 timeSkipPriceGems, F64 unlockOnBoardPriceGems, int experienceValue, MergeFeatures mergeFeatures, ActivationFeatures activationFeatures, SpawnFeatures spawnFeatures, DecayFeatures decayFeatures, ChestFeatures chestFeatures, CollectableFeatures collectableFeatures, BoosterFeatures boosterFeatures, BubbleFeatures bubbleFeatures, SinkFeatures sinkFeatures, ConsumableFeatures consumableFeatures, PortalFeatures portalFeatures, ChargesFeatures chargesFeatures, TimeContainerFeatures timeContainer, LeaderboardFeatures leaderboardFeatures, List<string> tags, List<string> confirmableMergeResults, List<IDirectorAction> onDiscoveredActions, bool showTutorialFingerOnDiscovery, List<string> analyticsMetadata, List<int> combineInfoWithItem, ItemRarity rarity, bool unsellable, IEnumerable<PlayerReward> rewards)
        {
        }

        public Currencies SellCurrency() => Currencies.Coins;
        public int GetItemSellPrice(SharedGlobals sharedGlobals)
        {
            var sellIndex = Math.Clamp(LevelNumber - 1, 0, sharedGlobals.ItemSellPrices.Count - 1);
            return sharedGlobals.ItemSellPrices[sellIndex];
        }

        public (Currencies, long) SellPrice(SharedGlobals sharedGlobals)
        {
            var sellPrice = GetItemSellPrice(sharedGlobals);
            return (SellCurrency(), sellPrice);
        }

        public F64 AnchorPrice(Currencies currency)
        {
            if (currency == Currencies.Diamonds)
                return AnchorPriceGems;
            if (currency == Currencies.Coins)
                return AnchorPriceCoins;
            throw new InvalidOperationException($"Anchor price is not defined for [currency={currency}]");
        }

        public F64 BubbleDiscount()
        {
            var price = AnchorPrice(BubbleFeatures.OpenCost.Item1);
            if (price > 0)
                return (price - BubbleFeatures.OpenCost.Item2) / price;
            return F64.Zero;
        }

        [MetaMember(37, (MetaMemberFlags)0)]
        private FishingRodFeatures _FishingRodFeatures;
        [MetaMember(38, (MetaMemberFlags)0)]
        private WeightFeatures _WeightFeatures;
        [MetaMember(39, (MetaMemberFlags)0)]
        private CameraFeatures _CameraFeatures;
        [MetaMember(40, (MetaMemberFlags)0)]
        private SinkableFeatures _SinkableFeatures;
        [MetaMember(41, (MetaMemberFlags)0)]
        private FramesFeatures _FramesFeatures;
        [IgnoreDataMember]
        public FishingRodFeatures FishingRodFeatures { get; }

        [IgnoreDataMember]
        public WeightFeatures WeightFeatures { get; }

        [IgnoreDataMember]
        public CameraFeatures CameraFeatures { get; }

        [IgnoreDataMember]
        public SinkableFeatures SinkableFeatures { get; }

        [IgnoreDataMember]
        public FramesFeatures FramesFeatures { get; }

        public ItemDefinition(int configKey, string itemType, string poolTag, string skinName, int levelNumber, bool movable, F64 costInDiamonds, F64 anchorPriceGems, F64 anchorPriceCoins, F64 timeSkipPriceGems, F64 unlockOnBoardPriceGems, int experienceValue, MergeFeatures mergeFeatures, ActivationFeatures activationFeatures, SpawnFeatures spawnFeatures, DecayFeatures decayFeatures, ChestFeatures chestFeatures, CollectableFeatures collectableFeatures, BoosterFeatures boosterFeatures, BubbleFeatures bubbleFeatures, SinkFeatures sinkFeatures, ConsumableFeatures consumableFeatures, PortalFeatures portalFeatures, ChargesFeatures chargesFeatures, TimeContainerFeatures timeContainer, LeaderboardFeatures leaderboardFeatures, FishingRodFeatures fishingRodFeatures, WeightFeatures weightFeatures, CameraFeatures cameraFeatures, SinkableFeatures sinkableFeatures, FramesFeatures framesFeatures, List<string> tags, List<string> confirmableMergeResults, List<IDirectorAction> onDiscoveredActions, bool showTutorialFingerOnDiscovery, List<string> analyticsMetadata, List<int> combineInfoWithItem, ItemRarity rarity, bool unsellable, IEnumerable<PlayerReward> rewards)
        {
        }

        [MetaMember(43, (MetaMemberFlags)0)]
        private PersistentFeatures _PersistentFeatures;
        [MetaMember(42, (MetaMemberFlags)0)]
        public List<PlayerRequirement> UnlockRequirements { get; set; }

        [IgnoreDataMember]
        public PersistentFeatures PersistentFeatures { get; }
        public bool HasUnlockRequirements { get; }

        public ItemDefinition(int configKey, string itemType, string poolTag, string skinName, int levelNumber, bool movable, F64 costInDiamonds, F64 anchorPriceGems, F64 anchorPriceCoins, F64 timeSkipPriceGems, F64 unlockOnBoardPriceGems, int experienceValue, MergeFeatures mergeFeatures, ActivationFeatures activationFeatures, SpawnFeatures spawnFeatures, DecayFeatures decayFeatures, ChestFeatures chestFeatures, CollectableFeatures collectableFeatures, BoosterFeatures boosterFeatures, BubbleFeatures bubbleFeatures, SinkFeatures sinkFeatures, ConsumableFeatures consumableFeatures, PortalFeatures portalFeatures, ChargesFeatures chargesFeatures, TimeContainerFeatures timeContainer, LeaderboardFeatures leaderboardFeatures, FishingRodFeatures fishingRodFeatures, WeightFeatures weightFeatures, CameraFeatures cameraFeatures, SinkableFeatures sinkableFeatures, FramesFeatures framesFeatures, PersistentFeatures persistentFeatures, List<string> tags, List<string> confirmableMergeResults, List<IDirectorAction> onDiscoveredActions, bool showTutorialFingerOnDiscovery, List<string> analyticsMetadata, List<int> combineInfoWithItem, ItemRarity rarity, bool unsellable, IEnumerable<PlayerReward> rewards, IEnumerable<PlayerRequirement> unlockRequirements)
        {
        }

        [MetaMember(44, (MetaMemberFlags)0)]
        public List<string> SpawnEffects { get; set; }

        public ItemDefinition(int configKey, string itemType, string poolTag, string skinName, int levelNumber, bool movable, F64 costInDiamonds, F64 anchorPriceGems, F64 anchorPriceCoins, F64 timeSkipPriceGems, F64 unlockOnBoardPriceGems, int experienceValue, MergeFeatures mergeFeatures, ActivationFeatures activationFeatures, SpawnFeatures spawnFeatures, DecayFeatures decayFeatures, ChestFeatures chestFeatures, CollectableFeatures collectableFeatures, BoosterFeatures boosterFeatures, BubbleFeatures bubbleFeatures, SinkFeatures sinkFeatures, ConsumableFeatures consumableFeatures, PortalFeatures portalFeatures, ChargesFeatures chargesFeatures, TimeContainerFeatures timeContainer, LeaderboardFeatures leaderboardFeatures, FishingRodFeatures fishingRodFeatures, WeightFeatures weightFeatures, CameraFeatures cameraFeatures, SinkableFeatures sinkableFeatures, FramesFeatures framesFeatures, PersistentFeatures persistentFeatures, List<string> tags, List<string> confirmableMergeResults, List<IDirectorAction> onDiscoveredActions, bool showTutorialFingerOnDiscovery, List<string> analyticsMetadata, List<int> combineInfoWithItem, ItemRarity rarity, bool unsellable, IEnumerable<PlayerReward> rewards, IEnumerable<PlayerRequirement> unlockRequirements, List<string> spawnEffects)
        {
        }

        [MetaMember(45, (MetaMemberFlags)0)]
        private OverrideSpawnChanceFeatures _OverrideSpawnChanceFeatures;
        [MetaMember(46, (MetaMemberFlags)0)]
        public ConfigPrefabId CustomItemInfoPopupId;
        [MetaMember(48, (MetaMemberFlags)0)]
        private AudioFeatures _AudioFeatures;
        [MetaMember(47, (MetaMemberFlags)0)]
        public bool ShowCustomItemInfoPopupOnDiscovery { get; set; }

        [IgnoreDataMember]
        public OverrideSpawnChanceFeatures OverrideSpawnChanceFeatures { get; }

        [IgnoreDataMember]
        public AudioFeatures AudioFeatures { get; }

        public ItemDefinition(int configKey, string itemType, string poolTag, string skinName, int levelNumber, bool movable, F64 costInDiamonds, F64 anchorPriceGems, F64 anchorPriceCoins, F64 timeSkipPriceGems, F64 unlockOnBoardPriceGems, int experienceValue, MergeFeatures mergeFeatures, ActivationFeatures activationFeatures, SpawnFeatures spawnFeatures, DecayFeatures decayFeatures, ChestFeatures chestFeatures, CollectableFeatures collectableFeatures, BoosterFeatures boosterFeatures, BubbleFeatures bubbleFeatures, SinkFeatures sinkFeatures, ConsumableFeatures consumableFeatures, PortalFeatures portalFeatures, ChargesFeatures chargesFeatures, TimeContainerFeatures timeContainer, LeaderboardFeatures leaderboardFeatures, FishingRodFeatures fishingRodFeatures, WeightFeatures weightFeatures, CameraFeatures cameraFeatures, SinkableFeatures sinkableFeatures, FramesFeatures framesFeatures, PersistentFeatures persistentFeatures, OverrideSpawnChanceFeatures overrideSpawnChanceFeatures, AudioFeatures audioFeatures, List<string> tags, List<string> confirmableMergeResults, List<IDirectorAction> onDiscoveredActions, bool showTutorialFingerOnDiscovery, List<string> analyticsMetadata, List<int> combineInfoWithItem, ItemRarity rarity, bool unsellable, IEnumerable<PlayerReward> rewards, IEnumerable<PlayerRequirement> unlockRequirements, List<string> spawnEffects, ConfigPrefabId customItemInfoPopupId, bool showCustomItemInfoPopupOnDiscovery)
        {
        }

        [MetaMember(49, (MetaMemberFlags)0)]
        private string OverrideLocalizationItemKey { get; set; }

        [IgnoreDataMember]
        public string LocalizationItemKey { get; }

        public ItemDefinition(int configKey, string itemType, string poolTag, string skinName, int levelNumber, bool movable, F64 costInDiamonds, F64 anchorPriceGems, F64 anchorPriceCoins, F64 timeSkipPriceGems, F64 unlockOnBoardPriceGems, int experienceValue, MergeFeatures mergeFeatures, ActivationFeatures activationFeatures, SpawnFeatures spawnFeatures, DecayFeatures decayFeatures, ChestFeatures chestFeatures, CollectableFeatures collectableFeatures, BoosterFeatures boosterFeatures, BubbleFeatures bubbleFeatures, SinkFeatures sinkFeatures, ConsumableFeatures consumableFeatures, PortalFeatures portalFeatures, ChargesFeatures chargesFeatures, TimeContainerFeatures timeContainer, LeaderboardFeatures leaderboardFeatures, FishingRodFeatures fishingRodFeatures, WeightFeatures weightFeatures, CameraFeatures cameraFeatures, SinkableFeatures sinkableFeatures, FramesFeatures framesFeatures, PersistentFeatures persistentFeatures, OverrideSpawnChanceFeatures overrideSpawnChanceFeatures, AudioFeatures audioFeatures, List<string> tags, List<string> confirmableMergeResults, List<IDirectorAction> onDiscoveredActions, bool showTutorialFingerOnDiscovery, List<string> analyticsMetadata, List<int> combineInfoWithItem, ItemRarity rarity, bool unsellable, IEnumerable<PlayerReward> rewards, IEnumerable<PlayerRequirement> unlockRequirements, List<string> spawnEffects, ConfigPrefabId customItemInfoPopupId, bool showCustomItemInfoPopupOnDiscovery, string overrideLocalizationItemKey)
        {
        }

        [MetaMember(50, (MetaMemberFlags)0)]
        private MiniEventFeatures _MiniEventFeatures;
        [MetaMember(54, (MetaMemberFlags)0)]
        private OrderFeatures _OrderFeatures;
        [MetaMember(51, (MetaMemberFlags)0)]
        public string FullOverrideLocalizationItemKey { get; set; }

        [MetaMember(52, (MetaMemberFlags)0)]
        public string SinkTag { get; set; }

        [MetaMember(53, (MetaMemberFlags)0)]
        public int SinkPoints { get; set; }

        [MetaMember(55, (MetaMemberFlags)0)]
        public List<int> OverrideProductionSource { get; set; }

        [IgnoreDataMember]
        public OrderFeatures OrderFeatures => _OrderFeatures;

        [IgnoreDataMember]
        public MiniEventFeatures MiniEventFeatures { get; }

        public ItemDefinition(int configKey, string itemType, string poolTag, string skinName, int levelNumber, bool movable, F64 costInDiamonds, F64 anchorPriceGems, F64 anchorPriceCoins, F64 timeSkipPriceGems, F64 unlockOnBoardPriceGems, int experienceValue, MergeFeatures mergeFeatures, ActivationFeatures activationFeatures, SpawnFeatures spawnFeatures, DecayFeatures decayFeatures, ChestFeatures chestFeatures, CollectableFeatures collectableFeatures, BoosterFeatures boosterFeatures, BubbleFeatures bubbleFeatures, SinkFeatures sinkFeatures, ConsumableFeatures consumableFeatures, PortalFeatures portalFeatures, ChargesFeatures chargesFeatures, TimeContainerFeatures timeContainer, LeaderboardFeatures leaderboardFeatures, FishingRodFeatures fishingRodFeatures, WeightFeatures weightFeatures, CameraFeatures cameraFeatures, SinkableFeatures sinkableFeatures, FramesFeatures framesFeatures, PersistentFeatures persistentFeatures, OverrideSpawnChanceFeatures overrideSpawnChanceFeatures, AudioFeatures audioFeatures, OrderFeatures orderFeatures, List<string> tags, List<string> confirmableMergeResults, List<IDirectorAction> onDiscoveredActions, bool showTutorialFingerOnDiscovery, List<string> analyticsMetadata, List<int> combineInfoWithItem, ItemRarity rarity, bool unsellable, IEnumerable<PlayerReward> rewards, IEnumerable<PlayerRequirement> unlockRequirements, List<string> spawnEffects, ConfigPrefabId customItemInfoPopupId, bool showCustomItemInfoPopupOnDiscovery, string overrideLocalizationItemKey, MiniEventFeatures miniEventFeatures, string fullOverrideLocalizationItemKey, string sinkTag, int sinkPoints, List<string> overrideProductionSource)
        {
        }

        [MetaMember(56, (MetaMemberFlags)0)]
        private GemWeightFeatures _GemWeightFeatures;
        [MetaMember(57, (MetaMemberFlags)0)]
        private RockChunkFeatures _RockChunkFeatures;
        [IgnoreDataMember]
        public GemWeightFeatures GemWeightFeatures { get; }

        [IgnoreDataMember]
        public RockChunkFeatures RockChunkFeatures { get; }

        public ItemDefinition(int configKey, string itemType, string poolTag, string skinName, int levelNumber, bool movable, F64 costInDiamonds, F64 anchorPriceGems, F64 anchorPriceCoins, F64 timeSkipPriceGems, F64 unlockOnBoardPriceGems, int experienceValue, MergeFeatures mergeFeatures, ActivationFeatures activationFeatures, SpawnFeatures spawnFeatures, DecayFeatures decayFeatures, ChestFeatures chestFeatures, CollectableFeatures collectableFeatures, BoosterFeatures boosterFeatures, BubbleFeatures bubbleFeatures, SinkFeatures sinkFeatures, ConsumableFeatures consumableFeatures, PortalFeatures portalFeatures, ChargesFeatures chargesFeatures, TimeContainerFeatures timeContainer, LeaderboardFeatures leaderboardFeatures, FishingRodFeatures fishingRodFeatures, WeightFeatures weightFeatures, CameraFeatures cameraFeatures, SinkableFeatures sinkableFeatures, FramesFeatures framesFeatures, PersistentFeatures persistentFeatures, OverrideSpawnChanceFeatures overrideSpawnChanceFeatures, GemWeightFeatures gemWeightFeatures, RockChunkFeatures rockChunkFeatures, AudioFeatures audioFeatures, OrderFeatures orderFeatures, List<string> tags, List<string> confirmableMergeResults, List<IDirectorAction> onDiscoveredActions, bool showTutorialFingerOnDiscovery, List<string> analyticsMetadata, List<int> combineInfoWithItem, ItemRarity rarity, bool unsellable, IEnumerable<PlayerReward> rewards, IEnumerable<PlayerRequirement> unlockRequirements, List<string> spawnEffects, ConfigPrefabId customItemInfoPopupId, bool showCustomItemInfoPopupOnDiscovery, string overrideLocalizationItemKey, MiniEventFeatures miniEventFeatures, string fullOverrideLocalizationItemKey, string sinkTag, int sinkPoints, List<string> overrideProductionSource)
        {
        }

        [MetaMember(58, (MetaMemberFlags)0)]
        public string OverrideLocalizationItemCategory { get; set; }

        public ItemDefinition(int configKey, string itemType, string poolTag, string skinName, int levelNumber, bool movable, F64 costInDiamonds, F64 anchorPriceGems, F64 anchorPriceCoins, F64 timeSkipPriceGems, F64 unlockOnBoardPriceGems, int experienceValue, MergeFeatures mergeFeatures, ActivationFeatures activationFeatures, SpawnFeatures spawnFeatures, DecayFeatures decayFeatures, ChestFeatures chestFeatures, CollectableFeatures collectableFeatures, BoosterFeatures boosterFeatures, BubbleFeatures bubbleFeatures, SinkFeatures sinkFeatures, ConsumableFeatures consumableFeatures, PortalFeatures portalFeatures, ChargesFeatures chargesFeatures, TimeContainerFeatures timeContainer, LeaderboardFeatures leaderboardFeatures, FishingRodFeatures fishingRodFeatures, WeightFeatures weightFeatures, CameraFeatures cameraFeatures, SinkableFeatures sinkableFeatures, FramesFeatures framesFeatures, PersistentFeatures persistentFeatures, OverrideSpawnChanceFeatures overrideSpawnChanceFeatures, GemWeightFeatures gemWeightFeatures, RockChunkFeatures rockChunkFeatures, AudioFeatures audioFeatures, OrderFeatures orderFeatures, List<string> tags, List<string> confirmableMergeResults, List<IDirectorAction> onDiscoveredActions, bool showTutorialFingerOnDiscovery, List<string> analyticsMetadata, List<int> combineInfoWithItem, ItemRarity rarity, bool unsellable, IEnumerable<PlayerReward> rewards, IEnumerable<PlayerRequirement> unlockRequirements, List<string> spawnEffects, ConfigPrefabId customItemInfoPopupId, bool showCustomItemInfoPopupOnDiscovery, string overrideLocalizationItemKey, MiniEventFeatures miniEventFeatures, string fullOverrideLocalizationItemKey, string overrideLocalizationItemCategory, string sinkTag, int sinkPoints, List<string> overrideProductionSource)
        {
        }

        [MetaMember(59, (MetaMemberFlags)0)]
        private PrisonBadgeFeatures _PrisonBadgeFeatures;
        [MetaMember(60, (MetaMemberFlags)0)]
        private EscapeToolFeatures _EscapeToolFeatures;
        [MetaMember(61, (MetaMemberFlags)0)]
        private MinigameActivationFeatures _MinigameActivationFeatures;
        [MetaMember(62, (MetaMemberFlags)0)]
        private PostBoxFeatures _PostBoxFeatures;
        [MetaMember(63, (MetaMemberFlags)0)]
        private PrisonLetterFeatures _PrisonLetterFeatures;
        [IgnoreDataMember]
        public PrisonBadgeFeatures PrisonBadgeFeatures { get; }

        [IgnoreDataMember]
        public EscapeToolFeatures EscapeToolFeatures { get; }

        [IgnoreDataMember]
        public MinigameActivationFeatures MinigameActivationFeatures { get; }

        [IgnoreDataMember]
        public PostBoxFeatures PostBoxFeatures { get; }

        [IgnoreDataMember]
        public PrisonLetterFeatures PrisonLetterFeatures { get; }

        public ItemDefinition(int configKey, string itemType, string poolTag, string skinName, int levelNumber, bool movable, F64 costInDiamonds, F64 anchorPriceGems, F64 anchorPriceCoins, F64 timeSkipPriceGems, F64 unlockOnBoardPriceGems, int experienceValue, MergeFeatures mergeFeatures, ActivationFeatures activationFeatures, SpawnFeatures spawnFeatures, DecayFeatures decayFeatures, ChestFeatures chestFeatures, CollectableFeatures collectableFeatures, BoosterFeatures boosterFeatures, BubbleFeatures bubbleFeatures, SinkFeatures sinkFeatures, ConsumableFeatures consumableFeatures, PortalFeatures portalFeatures, ChargesFeatures chargesFeatures, TimeContainerFeatures timeContainer, LeaderboardFeatures leaderboardFeatures, FishingRodFeatures fishingRodFeatures, WeightFeatures weightFeatures, CameraFeatures cameraFeatures, SinkableFeatures sinkableFeatures, FramesFeatures framesFeatures, PersistentFeatures persistentFeatures, OverrideSpawnChanceFeatures overrideSpawnChanceFeatures, GemWeightFeatures gemWeightFeatures, RockChunkFeatures rockChunkFeatures, AudioFeatures audioFeatures, OrderFeatures orderFeatures, List<string> tags, List<string> confirmableMergeResults, List<IDirectorAction> onDiscoveredActions, bool showTutorialFingerOnDiscovery, List<string> analyticsMetadata, List<int> combineInfoWithItem, ItemRarity rarity, bool unsellable, IEnumerable<PlayerReward> rewards, IEnumerable<PlayerRequirement> unlockRequirements, List<string> spawnEffects, ConfigPrefabId customItemInfoPopupId, bool showCustomItemInfoPopupOnDiscovery, string overrideLocalizationItemKey, MiniEventFeatures miniEventFeatures, string fullOverrideLocalizationItemKey, string overrideLocalizationItemCategory, string sinkTag, int sinkPoints, List<string> overrideProductionSource, PrisonBadgeFeatures prisonBadgeFeatures, EscapeToolFeatures escapeToolFeatures, MinigameActivationFeatures minigameActivationFeatures, PostBoxFeatures postBoxFeatures, PrisonLetterFeatures prisonLetterFeatures)
        {
        }
    }
}
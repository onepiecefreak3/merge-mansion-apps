using System;
using System.Reflection;
using Code.GameLogic.GameEvents;
using GameLogic.Area;
using GameLogic.Codex;
using GameLogic.Config.Map.Characters;
using GameLogic.Decorations;
using GameLogic.Hotspots;
using GameLogic.MergeChains;
using GameLogic.Player.Items;
using GameLogic.Player.Items.Bubble;
using GameLogic.Player.Items.Merging;
using GameLogic.Story;
using Metaplay.Core.Config;
using TimedMergeBoards;
using Metaplay.Core;
using GameLogic.Social;
using GameLogic.GameFeatures;
using Player;
using GameLogic.Config.Shop;
using Code.GameLogic.FlashSales;
using GameLogic.DailyTasks;
using GameLogic.Story.Videos;
using GameLogic.Story.SlideShows;
using GameLogic.Banks;
using GameLogic.SocialMedia;
using GameLogic.Addressables;
using GameLogic.Player.ScheduledActions;
using GameLogic.Dialogue;
using Code.GameLogic.Social;
using GameLogic.Cutscenes;
using GameLogic.TieredOffers;
using System.Collections.Generic;
using System.Diagnostics;
using Metaplay.Core.Offers;
using Merge;
using Code.GameLogic.Config;
using GameLogic.Player.Items.Fishing;
using GameLogic.Seasonality;
using GameLogic.Inventory;
using Metaplay.Core.Math;
using GameLogic.Audio;
using GameLogic.Player.Rewards;
using GameLogic.Config.DecorationShop;
using Code.GameLogic.DynamicEvents;
using GameLogic.Player.Modes;
using Metaplay.Core.Player;
using Metaplay.Core.Localization;
using Metaplay.Core.InAppPurchase;
using GameLogic.EventCharacters;
using GameLogic.Player.Items.OverrideSpawnChance;
using GameLogic.Hotspots.CardStack;
using Game.Cloud.Webshop;
using GameLogic.Advertisement;
using Metaplay;
using GameLogic.DailyTasksV2;
using GameLogic.Config.EnergyModeEvent;
using GameLogic.MiniEvents;
using Code.GameLogic.GameEvents.SoloMilestone;
using Code.GameLogic.GameEvents.DailyScoop;
using GameLogic.Player.Items.Sink;
using GameLogic.Player.Items.Order;
using GameLogic.Player.Items.GemMining;
using GameLogic.ItemsInPocket;
using GameLogic.CardCollection;
using GameLogic.Fallbacks;
using GameLogic.Player;
using Code.GameLogic.Hotspots;
using GameLogic.ProgressivePacks;

namespace GameLogic.Config
{
    public class SharedGameConfig : SharedGameConfigBase
    {
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("Items", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ItemKey -> ItemKey #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "SequenceId -> SequenceId #key" }, new string[] { }, false)]
        public GameConfigLibrary<int, ItemDefinition> Items { get; set; }

        [GameConfigEntry("MergeChains", true, null)]
        [GameConfigEntryTransform(typeof(MergeChainSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MergeChainId, MergeChainDefinition> MergeChains { get; set; }

        [GameConfigEntry("CodexDiscoveryRewards", true, null)]
        [GameConfigEntryTransform(typeof(CodexDiscoveryRewardSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CodexDiscoveryRewardId, CodexDiscoveryRewardInfo> CodexDiscoveryRewards { get; set; }

        [GameConfigEntryTransform(typeof(CodexCategorySource))]
        [GameConfigEntry("CodexCategories", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CodexCategoryId, CodexCategoryInfo> CodexCategories { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(BubblesSetupSource))]
        [GameConfigEntry("BubbleSetups", true, null)]
        public GameConfigLibrary<BubblesSetupId, BubblesSetup> BubbleSetups { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MergeRewards", true, null)]
        [GameConfigEntryTransform(typeof(MergeRewardSource))]
        public GameConfigLibrary<MergeRewardId, MergeReward> XpMergeRewards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(TimedMergeBoardSource))]
        [GameConfigEntry("TimedMergeBoards", true, null)]
        public GameConfigLibrary<MergeBoardId, TimedMergeBoard> TimedMergeBoards { get; set; }

        [GameConfigEntry("Boards", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "BoardId -> BoardId #key" }, new string[] { }, false)]
        public GameConfigLibrary<MergeBoardId, BoardInfo> Boards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntry("BoardEvents", true, null)]
        [GameConfigEntryTransform(typeof(BoardEventSource))]
        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        public GameConfigLibrary<EventId, BoardEventInfo> BoardEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ShopEventId -> ShopEventId #key" }, new string[] { }, false)]
        [GameConfigEntry("ShopEvents", true, null)]
        [GameConfigEntryTransform(typeof(ShopEventConfigSourceItem))]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<EventId, ShopEventInfo> ShopEvents { get; set; }

        [GameConfigEntry("CollectibleBoardEvents", true, null)]
        [GameConfigEntryTransform(typeof(CollectibleBoardEventSource))]
        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<CollectibleBoardEventId, CollectibleBoardEventInfo> CollectibleBoardEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigEntry("LeaderboardEvents", true, null)]
        [GameConfigEntryTransform(typeof(LeaderboardEventSource))]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<LeaderboardEventId, LeaderboardEventInfo> LeaderboardEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(ProgressionEventSource))]
        [GameConfigEntry("ProgressionEvents", true, null)]
        public GameConfigLibrary<ProgressionEventId, ProgressionEventInfo> ProgressionEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "MapCharacterEventId -> MapCharacterEventId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MapCharacterEventDefinitionSource))]
        [GameConfigEntry("MapCharacterEvents", true, null)]
        public GameConfigLibrary<MapCharacterEventId, MapCharacterEventDefinition> MapCharacterEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "EventCurrencyId -> EventCurrencyId #key" }, new string[] { }, false)]
        [GameConfigEntry("EventCurrencies", true, null)]
        public GameConfigLibrary<EventCurrencyId, EventCurrencyInfo> EventCurrencies { get; set; }

        [GameConfigEntryTransform(typeof(EventLevelInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "EventLevelId -> EventLevelId #key" }, new string[] { }, false)]
        [GameConfigEntry("EventLevels", true, null)]
        public GameConfigLibrary<EventLevelId, EventLevelInfo> EventLevels { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "SetId -> SetId #key" }, new string[] { }, false)]
        [GameConfigEntry("EventLevelSets", true, null)]
        private GameConfigLibrary<EventLevelSetId, EventLevels> LevelSets { get; set; }

        [GameConfigEntryTransform(typeof(EventTaskConfigSourceItem))]
        [GameConfigSyntaxAdapter(new string[] { "EventTaskId -> EventTaskId #key" }, new string[] { }, false)]
        [GameConfigEntry("EventTasks", true, null)]
        public GameConfigLibrary<EventTaskId, EventTaskInfo> EventTasks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "EventOfferId -> EventOfferId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(EventShopOfferSourceConfigItem))]
        [GameConfigEntry("EventOffers", true, null)]
        public GameConfigLibrary<EventOfferId, EventOfferInfo> EventOffers { get; set; }

        [GameConfigEntryTransform(typeof(ProgressionEventPerkSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("ProgressionEventPerks", true, null)]
        public GameConfigLibrary<ProgressionEventPerkId, ProgressionEventPerkInfo> ProgressionEventPerks { get; set; }

        [GameConfigEntry("EventOfferSets", true, null)]
        [GameConfigEntryTransform(typeof(EventOfferSetSource))]
        [GameConfigSyntaxAdapter(new string[] { "EventOfferSetId -> EventOfferSetId #key" }, new string[] { }, false)]
        public GameConfigLibrary<EventOfferSetId, EventOfferSetInfo> EventOfferSets { get; set; }

        [GameConfigEntry("TieredOffers", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(TieredOfferSource))]
        public GameConfigLibrary<TieredOfferId, TieredOffer> TieredOffers { get; set; }

        [GameConfigEntry("DailyTasks", true, null)]
        [GameConfigEntryTransform(typeof(DailyTaskSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyTaskId, DailyTaskDefinition> DailyTasks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("Areas", true, null)]
        public GameConfigLibrary<AreaId, AreaInfo> Areas { get; set; }

        [GameConfigEntry("HotspotDefinitions", true, null)]
        [GameConfigEntryTransform(typeof(HotspotDefinitionSource))]
        [GameConfigSyntaxAdapter(new string[] { "HotspotId -> HotspotId #key" }, new string[] { }, false)]
        public GameConfigLibrary<HotspotId, HotspotDefinition> HotspotDefinitions { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "MapSpotId -> MapSpotId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MapSpotSource))]
        [GameConfigEntry("MapSpots", true, null)]
        public GameConfigLibrary<MapSpotId, MapSpotInfo> MapSpots { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "LevelKey -> LevelKey #key" }, new string[] { }, false)]
        [GameConfigEntry("PlayerLevels", true, null)]
        [GameConfigEntryTransform(typeof(PlayerLevelDataSource))]
        public GameConfigLibrary<int, PlayerLevelData> PlayerLevels { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("InventorySlots", true, null)]
        public GameConfigLibrary<InventorySlotId, InventorySlotsConfig> InventorySlots { get; set; }

        [GameConfigEntry("LevelUpTutorialConfig", true, null)]
        [GameConfigEntryTransform(typeof(LevelUpTutorialConfigSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigId -> ConfigId #key" }, new string[] { }, false)]
        public GameConfigLibrary<LevelUpTutorialConfigId, LevelUpTutorialConfig> LevelUpTutorialConfig { get; set; }

        [GameConfigEntryTransform(typeof(ShopItemInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ShopItemId -> ShopItemId #key" }, new string[] { }, false)]
        [GameConfigEntry("ShopItems", true, null)]
        public GameConfigLibrary<ShopItemId, ShopItemInfo> ShopItems { get; set; }
        public Dictionary<FlashSaleGroupId, FlashSaleGroupDefinition> FlashSaleGroups { get; set; }

        [GameConfigEntry("ShopLayouts", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ShopLayoutId, ShopLayout> ShopLayouts { get; set; }

        [GameConfigEntryTransform(typeof(DynamicPurchaseDefinitionSource))]
        [GameConfigSyntaxAdapter(new string[] { "ShopItemId -> ShopItemId #key" }, new string[] { }, false)]
        [GameConfigEntry("DynamicPurchaseProducts", true, null)]
        public GameConfigLibrary<ShopItemId, DynamicPurchaseDefinition> DynamicPurchaseProducts { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("CurrencyBank", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntryTransform(typeof(CurrencyBankSource))]
        public GameConfigLibrary<CurrencyBankId, CurrencyBankInfo> CurrencyBanks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "GameFeatureId -> GameFeatureId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(GameFeatureSettingSource))]
        [GameConfigEntry("GameFeatures", true, null)]
        public GameConfigLibrary<GameFeatureId, GameFeatureSetting> GameFeatures { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        [GameConfigEntry("SharedGlobals", true, null)]
        public SharedGlobals SharedGlobals { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "RuleId -> RuleId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(SuppressedWarningsSource))]
        [GameConfigEntry("SuppressedWarnings", true, null)]
        public GameConfigLibrary<int, SuppressedBuildLogsInfo> SuppressedWarnings { get; set; }

        [GameConfigEntry("AddressablesDownloadProcesses", true, null)]
        [GameConfigEntryTransform(typeof(AddressablesDownloadProcessSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<AddressablesDownloadProcessId, AddressablesDownloadProcess> AddressablesDownloadProcesses { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(ReEngagementSettingsSource))]
        [GameConfigEntry("ReEngagementSettings", true, null)]
        public GameConfigLibrary<ReEngagementSettingsId, ReEngagementSettings> ReEngagementSettings { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        [GameConfigEntry("FishingSettings", true, null)]
        public FishingSettings FishingSettings { get; set; }

        [GameConfigEntryTransform(typeof(ScheduledActionSource))]
        [GameConfigEntry("ScheduledActions", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ScheduledActionId, ScheduledActionInfo> ScheduledActions { get; set; }

        [GameConfigEntryTransform(typeof(StoryElementInfoSourceItem))]
        [GameConfigEntry("StoryDefinitions", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "StoryDefinitionId -> StoryDefinitionId #key" }, new string[] { }, false)]
        public GameConfigLibrary<StoryDefinitionId, StoryElementInfo> StoryElements { get; set; }

        [GameConfigEntry("DialogItems", true, null)]
        [GameConfigEntryTransform(typeof(DialogItemInfoSourceItem))]
        [GameConfigSyntaxAdapter(new string[] { "DialogItemId -> DialogItemId #key" }, new string[] { }, false)]
        public GameConfigLibrary<DialogItemId, DialogItemInfo> DialogItems { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("CollectibleDialoguesInfo", true, null)]
        [GameConfigEntryTransform(typeof(CollectibleDialoguesSource))]
        public GameConfigLibrary<CollectibleDialoguesInfoId, CollectibleDialoguesInfo> CollectibleDialoguesInfo { get; set; }

        [GameConfigEntry("DialogueCharacters", true, null)]
        [GameConfigEntryTransform(typeof(DialogueCharacterSource))]
        [GameConfigSyntaxAdapter(new string[] { "DialogCharacterType -> DialogCharacterType #key" }, new string[] { }, false)]
        public GameConfigLibrary<DialogCharacterType, DialogueCharacterInfo> DialogueCharacters { get; set; }

        [GameConfigEntry("GarageCleanupEvents", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntryTransform(typeof(GarageCleanupEventSourceConfigItem))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<GarageCleanupEventId, GarageCleanupEventInfo> GarageCleanupEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key", "RowNumber -> RowNumber #key" }, new string[] { }, false)]
        [GameConfigEntry("GarageCleanupBoardRows", true, null)]
        [GameConfigEntryTransform(typeof(GarageCleanupBoardRowSource))]
        public GameConfigLibrary<GarageCleanupBoardRowId, GarageCleanupBoardRowInfo> GarageCleanupBoardRows { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(GarageCleanupPatternSetSource))]
        [GameConfigEntry("GarageCleanupPatternSets", true, null)]
        public GameConfigLibrary<GarageCleanupPatternSetId, GarageCleanupPatternSetInfo> GarageCleanupPatternSets { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key", "RowNumber -> RowNumber #key" }, new string[] { }, false)]
        [GameConfigEntry("GarageCleanupPatternRows", true, null)]
        [GameConfigEntryTransform(typeof(GarageCleanupPatternRowSource))]
        public GameConfigLibrary<GarageCleanupPatternRowId, GarageCleanupPatternRowInfo> GarageCleanupPatternRows { get; set; }

        [GameConfigEntry("GarageCleanupRewards", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(GarageCleanupRewardSource))]
        public GameConfigLibrary<GarageCleanupRewardId, GarageCleanupRewardInfo> GarageCleanupRewards { get; set; }

        [GameConfigEntry("Decorations", true, null)]
        [GameConfigEntryTransform(typeof(DecorationInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "DecorationId -> DecorationId #key" }, new string[] { }, false)]
        public GameConfigLibrary<DecorationId, DecorationInfo> Decorations { get; set; }

        [GameConfigEntry("LayeredDecorations", true, null)]
        [GameConfigEntryTransform(typeof(LayeredDecorationSetSource))]
        [GameConfigSyntaxAdapter(new string[] { "SetId -> SetId #key" }, new string[] { }, false)]
        public GameConfigLibrary<LayeredDecorationSetId, LayeredDecorationSetInfo> LayeredDecorations { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "AuthenticationPlatformId -> AuthenticationPlatformId #key" }, new string[] { }, false)]
        [GameConfigEntry("SocialAuthentication", true, null)]
        public GameConfigLibrary<AuthenticationPlatform, SocialAuthenticationConfig> SocialAuthentication { get; set; }

        [GameConfigEntry("SocialMedia", true, null)]
        [GameConfigEntryTransform(typeof(SocialMediaSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<SocialMediaId, SocialMediaInfo> SocialMedia { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "SocialAuthRewardId -> SocialAuthRewardId #key" }, new string[] { }, false)]
        [GameConfigEntry("SocialAuthRewards", true, null)]
        [GameConfigEntryTransform(typeof(SocialAuthRewardSource))]
        public GameConfigLibrary<SocialAuthRewardId, SocialAuthRewardInfo> SocialAuthRewards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(VideoSource))]
        [GameConfigEntry("Videos", true, null)]
        public GameConfigLibrary<VideoId, Video> Videos { get; set; }

        [GameConfigEntry("SlideShows", true, null)]
        [GameConfigEntryTransform(typeof(SlideShowSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<SlideShowId, SlideShow> SlideShows { get; set; }

        [GameConfigEntry("Cutscenes", true, null)]
        [GameConfigEntryTransform(typeof(CutsceneInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "CutsceneId -> CutsceneId #key" }, new string[] { }, false)]
        public GameConfigLibrary<CutsceneId, CutsceneInfo> Cutscenes { get; set; }

        public override void Import(GameConfigImporter importer)
        {
            // CUSTOM: Re-implement by using reflection, instead of source generating from GameConfigEntryAttribute
            var properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var property in properties)
            {
                // Get game config attribute
                var gameConfigAttribute = property.GetCustomAttribute<GameConfigEntryAttribute>();
                if (gameConfigAttribute == null)
                    continue;
                // Create entry name
                var entryName = gameConfigAttribute.EntryName;
                if (gameConfigAttribute.MpcFormat)
                    entryName += ".mpc";
                // Check if entry exists
                if (!importer.Contains(entryName))
                {
                    if (gameConfigAttribute.RequireArchiveEntry)
                        throw new InvalidOperationException($"GameConfigEntry {entryName} does not exist.");
                    continue;
                }

                // Invoke ImportBinaryLibrary or ImportBinaryKeyValueStructure method
                if (property.PropertyType.GenericTypeArguments.Length == 2)
                {
                    var importMethod = typeof(GameConfigImporter).GetMethod(nameof(GameConfigImporter.ImportBinaryLibrary))?.MakeGenericMethod(property.PropertyType.GenericTypeArguments);
                    property.SetValue(this, importMethod?.Invoke(importer, new object[] { entryName }));
                }
                else
                {
                    var importMethod = typeof(GameConfigImporter).GetMethod(nameof(GameConfigImporter.ImportBinaryKeyValueStructure))?.MakeGenericMethod(property.PropertyType);
                    property.SetValue(this, importMethod?.Invoke(importer, new object[] { entryName, false }));
                }
            }

            // CUSTOM: Resolve MetaRef's, if toggled on
            foreach (var property in properties)
            {
                // Get game config attribute
                var gameConfigAttribute = property.GetCustomAttribute<GameConfigEntryAttribute>();
                if (gameConfigAttribute == null)
                    continue;
                // Invoke ResolveMetaRefs method
                if (gameConfigAttribute.ResolveContainedMetaRefs)
                {
                    var method = property.PropertyType.GetMethod("ResolveMetaRefs");
                    var propertyValue = property.GetValue(this);
                    if (propertyValue == null)
                        continue;
                    method?.Invoke(propertyValue, new object[] { this });
                }
            }
        }

        public Dictionary<OfferPlacementId, List<OfferPlacementId>> OfferPlacementIds { get; set; }
        public int MaxPlayerLevel { get; set; }
        public Dictionary<MergeBoardId, CollectibleBoardEventId> CollectibleBoardEventBoards { get; set; }
        public Dictionary<MergeBoardId, LeaderboardEventId> LeaderboardEventBoards { get; set; }
        public Dictionary<DialogCharacterType, HashSet<HotspotId>> HotspotIdsByDialogCharacterTypeToDiscover { get; set; }
        public Dictionary<LeaderboardEventId, HashSet<MergeChainDefinition>> MergeChainsByLeaderboardEventId { get; set; }
        public Dictionary<DialogItemId, List<DialogCharacterType>> CharactersToForceDiscoverByNonHotspotDialogItemId { get; set; }
        public Dictionary<OfferPlacementId, List<MetaOfferGroupId>> OfferGroupIdsByOfferPlacementId { get; set; }
        private IEnumerable<IValidatable> ValidatableEntries { get; }

        public SharedGameConfig()
        {
        }

        public HashSet<int> SecondaryEnergyMergeBoardPortalItems { get; set; }
        public Dictionary<MergeBoardId, CollectibleBoardEventId> FishingEventBoards { get; set; }

        [GameConfigEntry("ProgressionEventStreaks", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(ProgressionEventStreakRewardsSource))]
        public GameConfigLibrary<ProgressionEventStreakId, ProgressionEventStreakRewards> ProgressionEventStreaks { get; set; }

        [GameConfigEntry("Seasons", true, null)]
        [GameConfigEntryTransform(typeof(SeasonInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "SeasonId -> SeasonId #key" }, new string[] { }, false)]
        public GameConfigLibrary<SeasonId, SeasonInfo> Seasons { get; set; }

        [GameConfigEntry("RentableInventorySettings", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(RentableInventorySettingsSource))]
        public GameConfigLibrary<RentableInventorySettingsId, RentableInventorySettings> RentableInventorySettings { get; set; }

        [GameConfigEntry("PetInfos", true, null)]
        [GameConfigEntryTransform(typeof(PetInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<PetId, PetInfo> PetInfos { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DecorationShopSource))]
        [GameConfigEntry("DecorationShops", true, null)]
        public GameConfigLibrary<DecorationShopId, DecorationShopInfo> DecorationShops { get; set; }

        [GameConfigEntryTransform(typeof(DecorationShopSetSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("DecorationShopSets", true, null)]
        public GameConfigLibrary<DecorationShopSetId, DecorationShopSetInfo> DecorationShopSets { get; set; }

        [GameConfigEntryTransform(typeof(DecorationShopItemSource))]
        [GameConfigEntry("DecorationShopItems", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DecorationShopItemId, DecorationShopItemInfo> DecorationShopItems { get; set; }

        [GameConfigEntry("DynamicEventTasks", true, null)]
        [GameConfigEntryTransform(typeof(EventTaskConfigSourceItem))]
        [GameConfigSyntaxAdapter(new string[] { "EventTaskId -> EventTaskId #key" }, new string[] { }, false)]
        public GameConfigLibrary<EventTaskId, EventTaskInfo> DynamicEventTasks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DynamicEventRewardConfigSourceItem))]
        [GameConfigEntry("DynamicEventRewards", true, null)]
        public GameConfigLibrary<DynamicEventRewardId, DynamicEventRewardInfo> DynamicEventRewards { get; set; }

        [GameConfigEntryTransform(typeof(DynamicEventItemInfoSourceItem))]
        [GameConfigEntry("DynamicEventItems", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DynamicEventItemId, DynamicEventItemInfo> DynamicEventItems { get; set; }

        [GameConfigEntryTransform(typeof(DynamicEventHelperInfoSourceItem))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("DynamicEventHelpers", true, null)]
        public GameConfigLibrary<DynamicEventHelperId, DynamicEventHelperInfo> DynamicEventHelpers { get; set; }

        [GameConfigEntryTransform(typeof(EnergyModeSource))]
        [GameConfigEntry("EnergyModes", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<PlayerModeId, EnergyModeInfo> EnergyModes { get; set; }

        [GameConfigEntry("EnergyModeProgressionEventItems", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<int, EnergyModeProgressionEventItemInfo> EnergyModeProgressionEventItems { get; set; }
        public HashSet<MergeBoardId> AuxEnergyMergeBoards { get; set; }
        public List<ItemDefinition> FishItems { get; set; }
        public HashSet<int> ItemsAcceptedBySinks { get; set; }
        public Dictionary<int, IReadOnlyList<ValueTuple<ItemDefinition, F32>>> ItemProducingParents { get; set; }
        public Dictionary<HotspotId, IEnumerable<HotspotDefinition>> HotspotOpensAfterCompletion { get; set; }
        public Dictionary<MergeBoardId, EventId> BoardEventBoards { get; set; }
        public List<List<int>> ProducerVariants { get; set; }
        public Dictionary<MergeBoardId, List<IStringId>> EventsByMergeBoard { get; set; }
        public List<PortalPieceChainData> PortalPieceChains { get; set; }
        public Dictionary<DecorationShopItemId, List<PlayerSegmentId>> DecorationShopItemSegments { get; set; }

        [GameConfigEntry("Languages", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "LanguageId -> LanguageId #key" }, new string[] { }, false)]
        public GameConfigLibrary<LanguageId, LanguageInfo> Languages { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ProductId -> ProductId #key" }, new string[] { }, false)]
        [GameConfigEntry("InAppProducts", true, null)]
        [GameConfigEntryTransform(typeof(InAppProductConfigSource))]
        public GameConfigLibrary<InAppProductId, InAppProductInfo> InAppProducts { get; set; }

        [GameConfigEntry("PlayerSegments", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "SegmentId -> SegmentId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(PlayerSegmentInfoSourceItem))]
        public GameConfigLibrary<PlayerSegmentId, PlayerSegmentInfo> PlayerSegments { get; set; }

        [GameConfigEntryTransform(typeof(MergeMansionOfferSourceConfigItem))]
        [GameConfigEntry("Offers", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "OfferId -> OfferId #key" }, new string[] { }, false)]
        public GameConfigLibrary<MetaOfferId, MergeMansionOfferInfo> Offers { get; set; }

        [GameConfigEntry("TieredOfferItems", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "OfferId -> OfferId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MergeMansionOfferSourceConfigItem))]
        public GameConfigLibrary<MetaOfferId, MergeMansionOfferInfo> TieredOfferItems { get; set; }

        [GameConfigEntry("OfferGroups", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "GroupId -> GroupId #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntryTransform(typeof(MergeMansionOfferGroupSourceItem))]
        public GameConfigLibrary<MetaOfferGroupId, MergeMansionOfferGroupInfo> OfferGroups { get; set; }

        [GameConfigEntryTransform(typeof(SideBoardEventSource))]
        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntry("SideBoardEvents", true, null)]
        public GameConfigLibrary<SideBoardEventId, SideBoardEventInfo> SideBoardEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "EventCharacterId -> EventCharacterId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(EventCharacterInfoSource))]
        [GameConfigEntry("EventCharacters", true, null)]
        public GameConfigLibrary<EventCharacterId, EventCharacterInfo> EventCharacters { get; set; }
        public Dictionary<MergeBoardId, SideBoardEventId> SideBoardEventBoards { get; set; }
        public List<ItemDefinition> FishingRodItems { get; set; }
        public Dictionary<ItemDefinition, OverrideSpawnChanceFeatures> OverrideSpawnChanceByItemDefinition { get; set; }
        public List<HotspotId> AreaUnlockHotspots { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("Music_Tracks", true, null)]
        [GameConfigEntryTransform(typeof(MMTrackSource))]
        public GameConfigLibrary<string, MMTrack> Tracks { get; set; }

        [GameConfigEntryTransform(typeof(MMPlaylistSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("Music_Playlists", true, null)]
        public GameConfigLibrary<string, MMPlaylist> Playlists { get; set; }

        [GameConfigEntry("CardStacks", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardStackId, CardStackInfo> CardStacks { get; set; }

        [GameConfigEntry("WebShopSettings", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        public WebShopSettings WebShopSettings { get; set; }

        [GameConfigEntry("AdvertisementPlacements", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(AdvertisementPlacementsSource))]
        public GameConfigLibrary<AdvertisementPlacementId, AdvertisementPlacementsInfo> AdvertisementPlacements { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineEventSource))]
        [GameConfigEntry("MysteryMachineEvents", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineEventId, MysteryMachineEventInfo> MysteryMachineEvents { get; set; }

        [GameConfigEntry("MysteryMachineItemSets", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineItemSetSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineItemSetId, MysteryMachineItemSetInfo> MysteryMachineItemSets { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineItemSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MysteryMachineItems", true, null)]
        public GameConfigLibrary<MysteryMachineItemId, MysteryMachineItemInfo> MysteryMachineItems { get; set; }

        [GameConfigEntry("MysteryMachineItemScores", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineItemScoreSource))]
        public GameConfigLibrary<MysteryMachineItemScoreId, MysteryMachineItemScore> MysteryMachineItemScores { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineSpecialItemSource))]
        [GameConfigEntry("MysteryMachineSpecialItems", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineSpecialItemItemId, MysteryMachineSpecialItemInfo> MysteryMachineSpecialItems { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineChainMultiplierSource))]
        [GameConfigEntry("MysteryMachineItemChainMultipliers", true, null)]
        public GameConfigLibrary<MysteryMachineChainMultiplierId, MysteryMachineChainMultiplierInfo> MysteryMachineChainMultipliers { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineExtraItemGrantingSource))]
        [GameConfigEntry("MysteryMachineExtraItemGranting", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineExtraItemGrantingId, MysteryMachineExtraItemGrantingInfo> MysteryMachineExtraItemGranting { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineMultiplierSource))]
        [GameConfigEntry("MysteryMachineMultipliers", true, null)]
        public GameConfigLibrary<MysteryMachineMultiplierId, MysteryMachineMultiplierInfo> MysteryMachineMultipliers { get; set; }

        [GameConfigEntry("MergeMysteryMachines", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineSource))]
        public GameConfigLibrary<MysteryMachineId, MysteryMachineInfo> MysteryMachines { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineCurrencyItemSource))]
        [GameConfigEntry("MergeMysteryMachineCurrencyItems", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineCurrencyItemId, MysteryMachineCurrencyItemInfo> MysteryMachineCurrencyItems { get; set; }

        [GameConfigEntry("MergeMysteryMachineCurrencyItemChains", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineCurrencyItemChainSource))]
        public GameConfigLibrary<MysteryMachineCurrencyItemChainId, MysteryMachineCurrencyItemChainInfo> MysteryMachineCurrencyItemChains { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineProgressionEventProgressItemSource))]
        [GameConfigEntry("MergeMysteryMachineProgressionEventProgressItems", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineProgressionEventProgressItemId, MysteryMachineProgressionEventProgressItemInfo> MysteryMachineProgressionEventProgressItems { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MergeMysteryMachineProgressionEventProgressItemChains", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineProgressionEventProgressItemChainSource))]
        public GameConfigLibrary<MysteryMachineProgressionEventProgressItemChainId, MysteryMachineProgressionEventProgressItemChainInfo> MysteryMachineProgressionEventProgressItemChains { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineHeatLevelSource))]
        [GameConfigEntry("MysteryMachineHeatLevels", true, null)]
        public GameConfigLibrary<MysteryMachineHeatLevelId, MysteryMachineHeatLevelInfo> MysteryMachineHeatLevels { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachinePerkSource))]
        [GameConfigEntry("MysteryMachinePerks", true, null)]
        public GameConfigLibrary<MysteryMachinePerkId, MysteryMachinePerkInfo> MysteryMachinePerks { get; set; }

        [GameConfigEntry("MysteryMachineSpecialSales", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineSpecialSaleSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineSpecialSaleId, MysteryMachineSpecialSaleInfo> MysteryMachineSpecialSales { get; set; }

        [GameConfigEntry("MysteryMachineTasks", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineTaskSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineTaskId, MysteryMachineTaskInfo> MysteryMachineTasks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineTaskSetSource))]
        [GameConfigEntry("MysteryMachineTaskSets", true, null)]
        public GameConfigLibrary<MysteryMachineTaskSetId, MysteryMachineTaskSetInfo> MysteryMachineTaskSets { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineLevelSource))]
        [GameConfigEntry("MysteryMachineLevels", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineLevelId, MysteryMachineLevelInfo> MysteryMachineLevels { get; set; }
        public Dictionary<MergeBoardId, MysteryMachineEventId> MysteryMachineEventBoards { get; set; }

        [GameConfigEntryTransform(typeof(ProducerInventorySlotSource))]
        [GameConfigEntry("ProducerInventorySlots", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ProducerInventorySlotId, ProducerInventorySlotConfig> ProducerInventorySlots { get; set; }

        [GameConfigEntry("OfferPopupTriggers", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(OfferPopupTriggerSource))]
        public GameConfigLibrary<OfferPopupTriggerId, OfferPopupTrigger> OfferPopupTriggers { get; set; }

        [GameConfigEntry("LocationTravels", true, null)]
        [GameConfigEntryTransform(typeof(LocationTravelSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<LocationTravelId, LocationTravelInfo> LocationTravels { get; set; }

        private Dictionary<FlashSaleGroupId, FlashSaleGroupDefinition> combinedFlashSaleGroups;
        [GameConfigEntryTransform(typeof(FlashSaleSource))]
        [GameConfigEntry("FlashSales", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ShopItemId, FlashSaleDefinition> GarageFlashSales { get; set; }

        [GameConfigEntryTransform(typeof(FlashSaleSource))]
        [GameConfigEntry("EventFlashSales", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ShopItemId, FlashSaleDefinition> EventFlashSales { get; set; }

        [GameConfigEntry("FlashSaleGroups", true, null)]
        [GameConfigEntryTransform(typeof(FlashSalesGroupSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<FlashSaleGroupId, FlashSaleGroupDefinition> GarageFlashSaleGroups { get; set; }

        [GameConfigEntry("EventFlashSaleGroups", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(FlashSalesGroupSource))]
        public GameConfigLibrary<FlashSaleGroupId, FlashSaleGroupDefinition> EventFlashSaleGroups { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(FlashSaleShopSettingsSource))]
        [GameConfigEntry("FlashSaleShopSettings", true, null)]
        public GameConfigLibrary<FlashSaleShopSettingsId, FlashSaleShopSettings> FlashSaleShopSettings { get; set; }

        [GameConfigEntryTransform(typeof(DailyTaskV2Source))]
        [GameConfigEntry("DailyTasksV2", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyTaskV2Id, DailyTaskV2Info> DailyTasksV2 { get; set; }

        [GameConfigEntry("DailyTasksV2CompletionRewards", true, null)]
        [GameConfigEntryTransform(typeof(DailyTasksV2CompletionRewardSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyTasksV2CompletionRewardId, DailyTasksV2CompletionRewardInfo> DailyTasksV2CompletionRewards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("DailyTasksV2MergeChains", true, null)]
        [GameConfigEntryTransform(typeof(DailyTasksV2MergeChainSource))]
        public GameConfigLibrary<MergeChainId, DailyTasksV2MergeChainInfo> DailyTasksV2MergeChains { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        [GameConfigEntry("DailyTasksV2Settings", true, null)]
        public DailyTasksV2Settings DailyTasksV2Settings { get; set; }
        public List<int> MysteryMachineItemIds { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntryTransform(typeof(EnergyModeEventSource))]
        [GameConfigEntry("EnergyModeEvents", true, null)]
        public GameConfigLibrary<EnergyModeEventId, EnergyModeEventInfo> EnergyModeEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> MiniEventId #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntryTransform(typeof(MiniEventConfigSource))]
        [GameConfigEntry("MiniEvents", true, null)]
        public GameConfigLibrary<MiniEventId, MiniEventInfo> MiniEvents { get; set; }

        [GameConfigEntry("MakeYourOwnOffers", true, null)]
        [GameConfigEntryTransform(typeof(MakeYourOwnOfferSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MetaOfferId, MakeYourOwnOfferInfo> MakeYourOwnOffers { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("SoloMilestoneEvents", true, null)]
        [GameConfigEntryTransform(typeof(SoloMilestoneEventInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<SoloMilestoneEventId, SoloMilestoneEventInfo> SoloMilestoneEvents { get; set; }

        [GameConfigEntryTransform(typeof(SoloMilestoneMilestonesInfoSource))]
        [GameConfigEntry("SoloMilestoneMilestones", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<SoloMilestoneMilestonesId, SoloMilestoneMilestonesInfo> SoloMilestoneMilestones { get; set; }

        [GameConfigEntry("SoloMilestoneTokenSpawns", true, null)]
        [GameConfigEntryTransform(typeof(SoloMilestoneTokenSpawnsInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<SoloMilestoneTokenSpawnsId, SoloMilestoneTokenSpawnsInfo> SoloMilestoneTokenSpawns { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DailyScoopMilestoneDataSource))]
        [GameConfigEntry("DailyScoopMilestones", true, null)]
        public GameConfigLibrary<DailyScoopMilestoneId, DailyScoopMilestoneData> DailyScoopMilestones { get; set; }

        [GameConfigEntry("DailyScoopStandardObjectives", true, null)]
        [GameConfigEntryTransform(typeof(DailyScoopStandardObjectiveDataSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyScoopStandardObjectiveId, DailyScoopStandardObjectiveData> DailyScoopStandardObjectives { get; set; }

        [GameConfigEntryTransform(typeof(DailyScoopSpecialObjectiveDataSource))]
        [GameConfigEntry("DailyScoopSpecialObjectives", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyScoopSpecialObjectiveId, DailyScoopSpecialObjectiveData> DailyScoopSpecialObjectives { get; set; }

        [GameConfigEntryTransform(typeof(DailyScoopDayDataSource))]
        [GameConfigEntry("DailyScoopDays", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyScoopDayId, DailyScoopDayData> DailyScoopDays { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DailyScoopWeekDataSource))]
        [GameConfigEntry("DailyScoopWeeks", true, null)]
        public GameConfigLibrary<DailyScoopWeekId, DailyScoopWeekData> DailyScoopWeeks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntry("DailyScoopEvents", true, null)]
        [GameConfigEntryTransform(typeof(DailyScoopEventInfoSource))]
        public GameConfigLibrary<DailyScoopEventId, DailyScoopEventInfo> DailyScoopEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("TagRewards", true, null)]
        [GameConfigEntryTransform(typeof(TagRewardsSource))]
        public GameConfigLibrary<string, TagRewardsInfo> TagRewards { get; set; }

        [GameConfigEntryTransform(typeof(OrderRequirementsSource))]
        [GameConfigEntry("OrderRequirements", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<OrderRequirementsId, OrderRequirements> OrderRequirements { get; set; }

        [GameConfigEntry("GemSettings", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        public GemSettings GemSettings { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MapObjectGroups", true, null)]
        [GameConfigEntryTransform(typeof(MapObjectGroupInfoSource))]
        public GameConfigLibrary<MapObjectGroupId, MapObjectGroupInfo> MapObjectGroups { get; set; }
        public List<ItemDefinition> CutGemItems { get; set; }
        public HashSet<int> CardDeckItems { get; set; }
        public Dictionary<MergeBoardId, CollectibleBoardEventId> GemMineEventBoards { get; set; }
        public HashSet<int> CardItems { get; set; }

        [GameConfigEntry("DailyTasksV2BoultonLeague", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DailyTaskV2BoultonLeagueSource))]
        public GameConfigLibrary<DailyTaskV2Id, DailyTaskV2BoultonLeagueInfo> DailyTasksV2BoultonLeague { get; set; }

        [GameConfigEntryTransform(typeof(DailyTaskV2BoultonLeagueUnlimitedSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("DailyTasksV2BoultonLeagueUnlimited", true, null)]
        public GameConfigLibrary<DailyTaskV2Id, DailyTaskV2BoultonLeagueUnlimitedInfo> DailyTasksV2BoultonLeagueUnlimited { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DailyTasksV2ItemBoultonLeagueSource))]
        [GameConfigEntry("DailyTasksV2ItemsBoultonLeague", true, null)]
        public GameConfigLibrary<ItemTypeConstant, DailyTasksV2ItemBoultonLeagueInfo> DailyTasksV2ItemsBoultonLeague { get; set; }

        [GameConfigEntry("BoultonLeagueEvents", true, null)]
        [GameConfigEntryTransform(typeof(BoultonLeagueEventSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<BoultonLeagueEventId, BoultonLeagueEventInfo> BoultonLeagueEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(BoultonLeagueStageSource))]
        [GameConfigEntry("BoultonLeagueStages", true, null)]
        public GameConfigLibrary<BoultonLeagueStageId, BoultonLeagueStageInfo> BoultonLeagueStages { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(ItemInPocketInfoSource))]
        [GameConfigEntry("ItemsInPocket", true, null)]
        public GameConfigLibrary<ItemInPocketId, ItemInPocketInfo> ItemInPocketInfos { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(TemporaryCardCollectionEventSource))]
        [GameConfigEntry("TemporaryCardCollectionEvents", true, null)]
        public GameConfigLibrary<TemporaryCardCollectionEventId, TemporaryCardCollectionEventInfo> TemporaryCardCollectionEvents { get; set; }

        [GameConfigEntry("MysteryMachineLeaderboardConfigs", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineLeaderboardConfigSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineLeaderboardConfigId, MysteryMachineLeaderboardConfigInfo> MysteryMachineLeaderboardConfigs { get; set; }

        [GameConfigEntry("MysteryMachineLeaderboardRewards", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineLeaderboardRewardSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineLeaderboardRewardId, MysteryMachineLeaderboardRewardInfo> MysteryMachineLeaderboardRewards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineLeaderboardTopRankingRewardSource))]
        [GameConfigEntry("MysteryMachineLeaderboardTopRankingRewards", true, null)]
        public GameConfigLibrary<MysteryMachineLeaderboardTopRankingRewardId, MysteryMachineLeaderboardTopRankingRewardInfo> MysteryMachineLeaderboardTopRankingRewards { get; set; }

        [GameConfigEntry("MysteryMachineLeaderboardPercentileRankingRewards", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineLeaderboardPercentileRankingRewardSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineLeaderboardPercentileRankingRewardId, MysteryMachineLeaderboardPercentileRankingRewardInfo> MysteryMachineLeaderboardPercentileRankingRewards { get; set; }

        [GameConfigEntry("CardCollectionCardInfos", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionCardInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionCardId, CardCollectionCardInfo> CardCollectionCardInfos { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("CardCollectionCardSetInfos", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionCardSetInfoSource))]
        public GameConfigLibrary<CardCollectionCardSetId, CardCollectionCardSetInfo> CardCollectionCardSetInfos { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(CardCollectionPackInfoSource))]
        [GameConfigEntry("CardCollectionPackInfos", true, null)]
        public GameConfigLibrary<CardCollectionPackId, CardCollectionPackInfo> CardCollectionPackInfos { get; set; }

        [GameConfigEntryTransform(typeof(CardCollectionCardActivationInfoSource))]
        [GameConfigEntry("CardCollection_Card_Activation", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionCardActivationId, CardCollectionCardActivationInfo> CardCollectionCardActivationInfos { get; set; }

        [GameConfigEntry("CardCollection_Packs_Activation", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionPackActivationInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionPackActivationId, CardCollectionPackActivationInfo> CardCollectionPackActivationInfos { get; set; }

        [GameConfigEntryTransform(typeof(CardCollectionHiddenRarityActivationInfoSource))]
        [GameConfigEntry("CardCollection_HiddenRarity_Activation", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionHiddenRarityActivationId, CardCollectionHiddenRarityActivationInfo> CardCollectionHiddenRarityActivationInfos { get; set; }

        [GameConfigEntry("CardCollection_Set_Activation", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(CardCollectionSetActivationInfoSource))]
        public GameConfigLibrary<CardCollectionSetActivationId, CardCollectionSetActivationInfo> CardCollectionSetActivationInfos { get; set; }

        [GameConfigEntry("CardCollectionBalanceInfos", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(CardCollectionBalanceInfoSource))]
        public GameConfigLibrary<CardCollectionBalanceId, CardCollectionBalanceInfo> CardCollectionBalanceInfos { get; set; }

        [GameConfigEntry("CardCollection_EvidenceBoxes", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionEvidenceBoxSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionEvidenceBoxId, CardCollectionEvidenceBoxInfo> CardCollectionEvidenceBoxes { get; set; }

        [GameConfigEntryTransform(typeof(CardCollectionDuplicateRewardSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("CardCollection_DuplicateCardRewards", true, null)]
        public GameConfigLibrary<CardCollectionDuplicateRewardId, CardCollectionDuplicateRewardInfo> CardCollectionDuplicateCardRewards { get; set; }

        [GameConfigEntry("TaskGroups", true, null)]
        [GameConfigEntryTransform(typeof(TaskGroupDefinitionSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<TaskGroupId, TaskGroupDefinition> TaskGroups { get; set; }

        [GameConfigEntryTransform(typeof(RewardContainerSource))]
        [GameConfigEntry("RewardContainers", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<RewardContainerId, RewardContainerInfo> RewardContainers { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MysteryMachineScreens", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineScreenSource))]
        public GameConfigLibrary<MysteryMachineScreenId, MysteryMachineScreenInfo> MysteryMachineScreens { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MysteryMachineScreenMessagePacks", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineScreenMessagePackSource))]
        public GameConfigLibrary<MysteryMachineScreenMessagePackId, MysteryMachineScreenMessagePackInfo> MysteryMachineScreenMessagePacks { get; set; }

        [GameConfigEntry("MysteryMachineScreenMessages", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineScreenMessageSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineScreenMessageId, MysteryMachineScreenMessageInfo> MysteryMachineScreenMessages { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(FallbackItemInfoSource))]
        [GameConfigEntry("FallbackItems", true, null)]
        public GameConfigLibrary<FallbackItemId, FallbackItemInfo> FallbackItems { get; set; }

        [GameConfigEntryTransform(typeof(FallbackPlayerRewardInfoSource))]
        [GameConfigEntry("FallbackPlayerRewards", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<FallbackPlayerRewardId, FallbackPlayerRewardInfo> FallbackPlayerRewards { get; set; }
        public Dictionary<int, ItemInPocketInfo> ItemInPocketInfoByItemId { get; set; }
        public Dictionary<int, FallbackItemInfo> FallbackItemInfoByItemId { get; set; }
        public HashSet<ItemDefinition> ItemsAvailableOnlyDuringCardCollectionEvent { get; set; }
        public Dictionary<MysteryMachineLeaderboardConfigId, HashSet<PlayerSegmentId>> MysteryMachineLeaderboardRewardSegments { get; set; }

        [GameConfigEntry("CardCollectionSettings", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        public CardCollectionSettings CardCollectionSettings { get; set; }

        [GameConfigEntryTransform(typeof(EnergySettingsConfigSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("EnergySettings", true, null)]
        public GameConfigLibrary<EnergyType, EnergySettingsConfig> EnergySettings { get; set; }

        [GameConfigEntry("HotspotTables", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CustomHotspotTableId, CustomHotspotTablesInfo> CustomTables { get; set; }
        public Dictionary<int, CardCollectionPackId> CardPacksByItemId { get; set; }
        public List<TemporaryCardCollectionEventInfo> OrderedTemporaryCardCollectionEventInfos { get; set; }

        [GameConfigEntry("TheGreatEscapeMinigames", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(TheGreatEscapeMinigameInfoSource))]
        public GameConfigLibrary<TheGreatEscapeMinigameId, TheGreatEscapeMinigameInfo> TheGreatEscapeMinigames { get; set; }
        public List<ItemDefinition> PrisonBadgeItems { get; set; }
        public List<ItemDefinition> PrisonerLetterItems { get; set; }
        public Dictionary<MergeBoardId, CollectibleBoardEventId> TheGreatEscapeEventBoards { get; set; }

        [GameConfigEntry("OfferPurchaseRequirements", true, null)]
        [GameConfigEntryTransform(typeof(DelayedOfferPurchaseRequirementSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MetaOfferId, DelayedOfferPurchaseRequirement> DelayedOfferPurchaseRequirements { get; set; }

        [GameConfigEntry("ProgressionPacks", true, null)]
        [GameConfigEntryTransform(typeof(ProgressionPackSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ProgressionPackId, ProgressionPack> ProgressionPacks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntryTransform(typeof(ProgressionPackEventSource))]
        [GameConfigEntry("ProgressionPackEvents", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ProgressionPackEventId, ProgressionPackEventInfo> ProgressionPackEvents { get; set; }

        [GameConfigEntry("RewardUpgradables", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(RewardUpgradableSource))]
        public GameConfigLibrary<RewardUpgradableId, RewardUpgradableInfo> RewardUpgradables { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("ShortLeaderboardEvents", true, null)]
        [GameConfigEntryTransform(typeof(ShortLeaderboardEventSource))]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<ShortLeaderboardEventId, ShortLeaderboardEventInfo> ShortLeaderboardEvents { get; set; }

        [GameConfigEntryTransform(typeof(ShortLeaderboardEventStageSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("ShortLeaderboardEventStages", true, null)]
        public GameConfigLibrary<ShortLeaderboardEventStageId, ShortLeaderboardEventStageInfo> ShortLeaderboardEventStages { get; set; }

        [GameConfigEntry("SharedProducerSettings", true, null)]
        [GameConfigEntryTransform(typeof(SharedProducerSettingsSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<SharedProducerSettingsId, SharedProducerSettings> SharedProducerSettings { get; set; }
        public HashSet<MergeBoardId> ShortLeaderboardEventBoards { get; set; }
    }
}
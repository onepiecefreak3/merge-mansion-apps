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

namespace GameLogic.Config
{
    public class SharedGameConfig : SharedGameConfigBase
    {
        [GameConfigSyntaxAdapter(new string[] { "ItemKey -> ItemKey #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("Items", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "SequenceId -> SequenceId #key" }, new string[] { }, false)]
        public GameConfigLibrary<int, ItemDefinition> Items { get; set; }

        [GameConfigEntry("MergeChains", true, null)]
        [GameConfigEntryTransform(typeof(MergeChainSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MergeChainId, MergeChainDefinition> MergeChains { get; set; }

        [GameConfigEntryTransform(typeof(CodexDiscoveryRewardSource))]
        [GameConfigEntry("CodexDiscoveryRewards", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CodexDiscoveryRewardId, CodexDiscoveryRewardInfo> CodexDiscoveryRewards { get; set; }

        [GameConfigEntry("CodexCategories", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(CodexCategorySource))]
        public GameConfigLibrary<CodexCategoryId, CodexCategoryInfo> CodexCategories { get; set; }

        [GameConfigEntryTransform(typeof(BubblesSetupSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("BubbleSetups", true, null)]
        public GameConfigLibrary<BubblesSetupId, BubblesSetup> BubbleSetups { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MergeRewardSource))]
        [GameConfigEntry("MergeRewards", true, null)]
        public GameConfigLibrary<MergeRewardId, MergeReward> XpMergeRewards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(TimedMergeBoardSource))]
        [GameConfigEntry("TimedMergeBoards", true, null)]
        public GameConfigLibrary<MergeBoardId, TimedMergeBoard> TimedMergeBoards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "BoardId -> BoardId #key" }, new string[] { }, false)]
        [GameConfigEntry("Boards", true, null)]
        public GameConfigLibrary<MergeBoardId, BoardInfo> Boards { get; set; }

        [GameConfigEntry("BoardEvents", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntryTransform(typeof(BoardEventSource))]
        public GameConfigLibrary<EventId, BoardEventInfo> BoardEvents { get; set; }

        [GameConfigEntryTransform(typeof(ShopEventConfigSourceItem))]
        [GameConfigSyntaxAdapter(new string[] { "ShopEventId -> ShopEventId #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntry("ShopEvents", true, null)]
        public GameConfigLibrary<EventId, ShopEventInfo> ShopEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntry("CollectibleBoardEvents", true, null)]
        [GameConfigEntryTransform(typeof(CollectibleBoardEventSource))]
        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        public GameConfigLibrary<CollectibleBoardEventId, CollectibleBoardEventInfo> CollectibleBoardEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigEntry("LeaderboardEvents", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntryTransform(typeof(LeaderboardEventSource))]
        public GameConfigLibrary<LeaderboardEventId, LeaderboardEventInfo> LeaderboardEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigEntry("ProgressionEvents", true, null)]
        [GameConfigEntryTransform(typeof(ProgressionEventSource))]
        public GameConfigLibrary<ProgressionEventId, ProgressionEventInfo> ProgressionEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "MapCharacterEventId -> MapCharacterEventId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MapCharacterEventDefinitionSource))]
        [GameConfigEntry("MapCharacterEvents", true, null)]
        public GameConfigLibrary<MapCharacterEventId, MapCharacterEventDefinition> MapCharacterEvents { get; set; }

        [GameConfigEntry("EventCurrencies", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "EventCurrencyId -> EventCurrencyId #key" }, new string[] { }, false)]
        public GameConfigLibrary<EventCurrencyId, EventCurrencyInfo> EventCurrencies { get; set; }

        [GameConfigEntryTransform(typeof(EventLevelInfoSource))]
        [GameConfigEntry("EventLevels", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "EventLevelId -> EventLevelId #key" }, new string[] { }, false)]
        public GameConfigLibrary<EventLevelId, EventLevelInfo> EventLevels { get; set; }

        [GameConfigEntry("EventLevelSets", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "SetId -> SetId #key" }, new string[] { }, false)]
        private GameConfigLibrary<EventLevelSetId, EventLevels> LevelSets { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "EventTaskId -> EventTaskId #key" }, new string[] { }, false)]
        [GameConfigEntry("EventTasks", true, null)]
        [GameConfigEntryTransform(typeof(EventTaskConfigSourceItem))]
        public GameConfigLibrary<EventTaskId, EventTaskInfo> EventTasks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "EventOfferId -> EventOfferId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(EventShopOfferSourceConfigItem))]
        [GameConfigEntry("EventOffers", true, null)]
        public GameConfigLibrary<EventOfferId, EventOfferInfo> EventOffers { get; set; }

        [GameConfigEntryTransform(typeof(ProgressionEventPerkSource))]
        [GameConfigEntry("ProgressionEventPerks", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ProgressionEventPerkId, ProgressionEventPerkInfo> ProgressionEventPerks { get; set; }

        [GameConfigEntry("EventOfferSets", true, null)]
        [GameConfigEntryTransform(typeof(EventOfferSetSource))]
        [GameConfigSyntaxAdapter(new string[] { "EventOfferSetId -> EventOfferSetId #key" }, new string[] { }, false)]
        public GameConfigLibrary<EventOfferSetId, EventOfferSetInfo> EventOfferSets { get; set; }

        [GameConfigEntryTransform(typeof(TieredOfferSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("TieredOffers", true, null)]
        public GameConfigLibrary<TieredOfferId, TieredOffer> TieredOffers { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DailyTaskSource))]
        [GameConfigEntry("DailyTasks", true, null)]
        public GameConfigLibrary<DailyTaskId, DailyTaskDefinition> DailyTasks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("Areas", true, null)]
        public GameConfigLibrary<AreaId, AreaInfo> Areas { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "HotspotId -> HotspotId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(HotspotDefinitionSource))]
        [GameConfigEntry("HotspotDefinitions", true, null)]
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

        [GameConfigSyntaxAdapter(new string[] { "ConfigId -> ConfigId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(LevelUpTutorialConfigSource))]
        [GameConfigEntry("LevelUpTutorialConfig", true, null)]
        public GameConfigLibrary<LevelUpTutorialConfigId, LevelUpTutorialConfig> LevelUpTutorialConfig { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ShopItemId -> ShopItemId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(ShopItemInfoSource))]
        [GameConfigEntry("ShopItems", true, null)]
        public GameConfigLibrary<ShopItemId, ShopItemInfo> ShopItems { get; set; }
        public Dictionary<FlashSaleGroupId, FlashSaleGroupDefinition> FlashSaleGroups { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("ShopLayouts", true, null)]
        public GameConfigLibrary<ShopLayoutId, ShopLayout> ShopLayouts { get; set; }

        [GameConfigEntry("DynamicPurchaseProducts", true, null)]
        [GameConfigEntryTransform(typeof(DynamicPurchaseDefinitionSource))]
        [GameConfigSyntaxAdapter(new string[] { "ShopItemId -> ShopItemId #key" }, new string[] { }, false)]
        public GameConfigLibrary<ShopItemId, DynamicPurchaseDefinition> DynamicPurchaseProducts { get; set; }

        [GameConfigEntryTransform(typeof(CurrencyBankSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntry("CurrencyBank", true, null)]
        public GameConfigLibrary<CurrencyBankId, CurrencyBankInfo> CurrencyBanks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "GameFeatureId -> GameFeatureId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(GameFeatureSettingSource))]
        [GameConfigEntry("GameFeatures", true, null)]
        public GameConfigLibrary<GameFeatureId, GameFeatureSetting> GameFeatures { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        [GameConfigEntry("SharedGlobals", true, null)]
        public SharedGlobals SharedGlobals { get; set; }

        [GameConfigEntry("SuppressedWarnings", true, null)]
        [GameConfigEntryTransform(typeof(SuppressedWarningsSource))]
        [GameConfigSyntaxAdapter(new string[] { "RuleId -> RuleId #key" }, new string[] { }, false)]
        public GameConfigLibrary<int, SuppressedBuildLogsInfo> SuppressedWarnings { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("AddressablesDownloadProcesses", true, null)]
        [GameConfigEntryTransform(typeof(AddressablesDownloadProcessSource))]
        public GameConfigLibrary<AddressablesDownloadProcessId, AddressablesDownloadProcess> AddressablesDownloadProcesses { get; set; }

        [GameConfigEntry("ReEngagementSettings", true, null)]
        [GameConfigEntryTransform(typeof(ReEngagementSettingsSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ReEngagementSettingsId, ReEngagementSettings> ReEngagementSettings { get; set; }

        [GameConfigEntry("FishingSettings", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        public FishingSettings FishingSettings { get; set; }

        [GameConfigEntry("ScheduledActions", true, null)]
        [GameConfigEntryTransform(typeof(ScheduledActionSource))]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ScheduledActionId, ScheduledActionInfo> ScheduledActions { get; set; }

        [GameConfigEntryTransform(typeof(StoryElementInfoSourceItem))]
        [GameConfigSyntaxAdapter(new string[] { "StoryDefinitionId -> StoryDefinitionId #key" }, new string[] { }, false)]
        [GameConfigEntry("StoryDefinitions", true, null)]
        public GameConfigLibrary<StoryDefinitionId, StoryElementInfo> StoryElements { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "DialogItemId -> DialogItemId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DialogItemInfoSourceItem))]
        [GameConfigEntry("DialogItems", true, null)]
        public GameConfigLibrary<DialogItemId, DialogItemInfo> DialogItems { get; set; }

        [GameConfigEntryTransform(typeof(CollectibleDialoguesSource))]
        [GameConfigEntry("CollectibleDialoguesInfo", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CollectibleDialoguesInfoId, CollectibleDialoguesInfo> CollectibleDialoguesInfo { get; set; }

        [GameConfigEntry("DialogueCharacters", true, null)]
        [GameConfigEntryTransform(typeof(DialogueCharacterSource))]
        [GameConfigSyntaxAdapter(new string[] { "DialogCharacterType -> DialogCharacterType #key" }, new string[] { }, false)]
        public GameConfigLibrary<DialogCharacterType, DialogueCharacterInfo> DialogueCharacters { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("GarageCleanupEvents", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntryTransform(typeof(GarageCleanupEventSourceConfigItem))]
        public GameConfigLibrary<GarageCleanupEventId, GarageCleanupEventInfo> GarageCleanupEvents { get; set; }

        [GameConfigEntryTransform(typeof(GarageCleanupBoardRowSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key", "RowNumber -> RowNumber #key" }, new string[] { }, false)]
        [GameConfigEntry("GarageCleanupBoardRows", true, null)]
        public GameConfigLibrary<GarageCleanupBoardRowId, GarageCleanupBoardRowInfo> GarageCleanupBoardRows { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(GarageCleanupPatternSetSource))]
        [GameConfigEntry("GarageCleanupPatternSets", true, null)]
        public GameConfigLibrary<GarageCleanupPatternSetId, GarageCleanupPatternSetInfo> GarageCleanupPatternSets { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key", "RowNumber -> RowNumber #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(GarageCleanupPatternRowSource))]
        [GameConfigEntry("GarageCleanupPatternRows", true, null)]
        public GameConfigLibrary<GarageCleanupPatternRowId, GarageCleanupPatternRowInfo> GarageCleanupPatternRows { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(GarageCleanupRewardSource))]
        [GameConfigEntry("GarageCleanupRewards", true, null)]
        public GameConfigLibrary<GarageCleanupRewardId, GarageCleanupRewardInfo> GarageCleanupRewards { get; set; }

        [GameConfigEntryTransform(typeof(DecorationInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "DecorationId -> DecorationId #key" }, new string[] { }, false)]
        [GameConfigEntry("Decorations", true, null)]
        public GameConfigLibrary<DecorationId, DecorationInfo> Decorations { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "SetId -> SetId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(LayeredDecorationSetSource))]
        [GameConfigEntry("LayeredDecorations", true, null)]
        public GameConfigLibrary<LayeredDecorationSetId, LayeredDecorationSetInfo> LayeredDecorations { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "AuthenticationPlatformId -> AuthenticationPlatformId #key" }, new string[] { }, false)]
        [GameConfigEntry("SocialAuthentication", true, null)]
        public GameConfigLibrary<AuthenticationPlatform, SocialAuthenticationConfig> SocialAuthentication { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("SocialMedia", true, null)]
        [GameConfigEntryTransform(typeof(SocialMediaSource))]
        public GameConfigLibrary<SocialMediaId, SocialMediaInfo> SocialMedia { get; set; }

        [GameConfigEntry("SocialAuthRewards", true, null)]
        [GameConfigEntryTransform(typeof(SocialAuthRewardSource))]
        [GameConfigSyntaxAdapter(new string[] { "SocialAuthRewardId -> SocialAuthRewardId #key" }, new string[] { }, false)]
        public GameConfigLibrary<SocialAuthRewardId, SocialAuthRewardInfo> SocialAuthRewards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("Videos", true, null)]
        [GameConfigEntryTransform(typeof(VideoSource))]
        public GameConfigLibrary<VideoId, Video> Videos { get; set; }

        [GameConfigEntry("SlideShows", true, null)]
        [GameConfigEntryTransform(typeof(SlideShowSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<SlideShowId, SlideShow> SlideShows { get; set; }

        [GameConfigEntryTransform(typeof(CutsceneInfoSource))]
        [GameConfigEntry("Cutscenes", true, null)]
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

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("ProgressionEventStreaks", true, null)]
        [GameConfigEntryTransform(typeof(ProgressionEventStreakRewardsSource))]
        public GameConfigLibrary<ProgressionEventStreakId, ProgressionEventStreakRewards> ProgressionEventStreaks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "SeasonId -> SeasonId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(SeasonInfoSource))]
        [GameConfigEntry("Seasons", true, null)]
        public GameConfigLibrary<SeasonId, SeasonInfo> Seasons { get; set; }

        [GameConfigEntryTransform(typeof(RentableInventorySettingsSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("RentableInventorySettings", true, null)]
        public GameConfigLibrary<RentableInventorySettingsId, RentableInventorySettings> RentableInventorySettings { get; set; }

        [GameConfigEntry("PetInfos", true, null)]
        [GameConfigEntryTransform(typeof(PetInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<PetId, PetInfo> PetInfos { get; set; }

        [GameConfigEntryTransform(typeof(DecorationShopSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntry("DecorationShops", true, null)]
        public GameConfigLibrary<DecorationShopId, DecorationShopInfo> DecorationShops { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DecorationShopSetSource))]
        [GameConfigEntry("DecorationShopSets", true, null)]
        public GameConfigLibrary<DecorationShopSetId, DecorationShopSetInfo> DecorationShopSets { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DecorationShopItemSource))]
        [GameConfigEntry("DecorationShopItems", true, null)]
        public GameConfigLibrary<DecorationShopItemId, DecorationShopItemInfo> DecorationShopItems { get; set; }

        [GameConfigEntryTransform(typeof(EventTaskConfigSourceItem))]
        [GameConfigEntry("DynamicEventTasks", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "EventTaskId -> EventTaskId #key" }, new string[] { }, false)]
        public GameConfigLibrary<EventTaskId, EventTaskInfo> DynamicEventTasks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DynamicEventRewardConfigSourceItem))]
        [GameConfigEntry("DynamicEventRewards", true, null)]
        public GameConfigLibrary<DynamicEventRewardId, DynamicEventRewardInfo> DynamicEventRewards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DynamicEventItemInfoSourceItem))]
        [GameConfigEntry("DynamicEventItems", true, null)]
        public GameConfigLibrary<DynamicEventItemId, DynamicEventItemInfo> DynamicEventItems { get; set; }

        [GameConfigEntryTransform(typeof(DynamicEventHelperInfoSourceItem))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("DynamicEventHelpers", true, null)]
        public GameConfigLibrary<DynamicEventHelperId, DynamicEventHelperInfo> DynamicEventHelpers { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(EnergyModeSource))]
        [GameConfigEntry("EnergyModes", true, null)]
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

        [GameConfigEntry("InAppProducts", true, null)]
        [GameConfigEntryTransform(typeof(InAppProductConfigSource))]
        [GameConfigSyntaxAdapter(new string[] { "ProductId -> ProductId #key" }, new string[] { }, false)]
        public GameConfigLibrary<InAppProductId, InAppProductInfo> InAppProducts { get; set; }

        [GameConfigEntry("PlayerSegments", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "SegmentId -> SegmentId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(PlayerSegmentInfoSourceItem))]
        public GameConfigLibrary<PlayerSegmentId, PlayerSegmentInfo> PlayerSegments { get; set; }

        [GameConfigEntry("Offers", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "OfferId -> OfferId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MergeMansionOfferSourceConfigItem))]
        public GameConfigLibrary<MetaOfferId, MergeMansionOfferInfo> Offers { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "OfferId -> OfferId #key" }, new string[] { }, false)]
        [GameConfigEntry("TieredOfferItems", true, null)]
        [GameConfigEntryTransform(typeof(MergeMansionOfferSourceConfigItem))]
        public GameConfigLibrary<MetaOfferId, MergeMansionOfferInfo> TieredOfferItems { get; set; }

        [GameConfigEntryTransform(typeof(MergeMansionOfferGroupSourceItem))]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "GroupId -> GroupId #key" }, new string[] { }, false)]
        [GameConfigEntry("OfferGroups", true, null)]
        public GameConfigLibrary<MetaOfferGroupId, MergeMansionOfferGroupInfo> OfferGroups { get; set; }

        [GameConfigEntry("SideBoardEvents", true, null)]
        [GameConfigEntryTransform(typeof(SideBoardEventSource))]
        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<SideBoardEventId, SideBoardEventInfo> SideBoardEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "EventCharacterId -> EventCharacterId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(EventCharacterInfoSource))]
        [GameConfigEntry("EventCharacters", true, null)]
        public GameConfigLibrary<EventCharacterId, EventCharacterInfo> EventCharacters { get; set; }
        public Dictionary<MergeBoardId, SideBoardEventId> SideBoardEventBoards { get; set; }
        public List<ItemDefinition> FishingRodItems { get; set; }
        public Dictionary<ItemDefinition, OverrideSpawnChanceFeatures> OverrideSpawnChanceByItemDefinition { get; set; }
        public List<HotspotId> AreaUnlockHotspots { get; set; }

        [GameConfigEntry("Music_Tracks", true, null)]
        [GameConfigEntryTransform(typeof(MMTrackSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<string, MMTrack> Tracks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MMPlaylistSource))]
        [GameConfigEntry("Music_Playlists", true, null)]
        public GameConfigLibrary<string, MMPlaylist> Playlists { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("CardStacks", true, null)]
        public GameConfigLibrary<CardStackId, CardStackInfo> CardStacks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        [GameConfigEntry("WebShopSettings", true, null)]
        public WebShopSettings WebShopSettings { get; set; }

        [GameConfigEntry("AdvertisementPlacements", true, null)]
        [GameConfigEntryTransform(typeof(AdvertisementPlacementsSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<AdvertisementPlacementId, AdvertisementPlacementsInfo> AdvertisementPlacements { get; set; }

        [GameConfigEntry("MysteryMachineEvents", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineEventSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<MysteryMachineEventId, MysteryMachineEventInfo> MysteryMachineEvents { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineItemSetSource))]
        [GameConfigEntry("MysteryMachineItemSets", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineItemSetId, MysteryMachineItemSetInfo> MysteryMachineItemSets { get; set; }

        [GameConfigEntry("MysteryMachineItems", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineItemSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineItemId, MysteryMachineItemInfo> MysteryMachineItems { get; set; }

        [GameConfigEntry("MysteryMachineItemScores", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineItemScoreSource))]
        public GameConfigLibrary<MysteryMachineItemScoreId, MysteryMachineItemScore> MysteryMachineItemScores { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineSpecialItemSource))]
        [GameConfigEntry("MysteryMachineSpecialItems", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineSpecialItemItemId, MysteryMachineSpecialItemInfo> MysteryMachineSpecialItems { get; set; }

        [GameConfigEntry("MysteryMachineItemChainMultipliers", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineChainMultiplierSource))]
        public GameConfigLibrary<MysteryMachineChainMultiplierId, MysteryMachineChainMultiplierInfo> MysteryMachineChainMultipliers { get; set; }

        [GameConfigEntry("MysteryMachineExtraItemGranting", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineExtraItemGrantingSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineExtraItemGrantingId, MysteryMachineExtraItemGrantingInfo> MysteryMachineExtraItemGranting { get; set; }

        [GameConfigEntry("MysteryMachineMultipliers", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineMultiplierSource))]
        public GameConfigLibrary<MysteryMachineMultiplierId, MysteryMachineMultiplierInfo> MysteryMachineMultipliers { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineSource))]
        [GameConfigEntry("MergeMysteryMachines", true, null)]
        public GameConfigLibrary<MysteryMachineId, MysteryMachineInfo> MysteryMachines { get; set; }

        [GameConfigEntry("MergeMysteryMachineCurrencyItems", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineCurrencyItemSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineCurrencyItemId, MysteryMachineCurrencyItemInfo> MysteryMachineCurrencyItems { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineCurrencyItemChainSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MergeMysteryMachineCurrencyItemChains", true, null)]
        public GameConfigLibrary<MysteryMachineCurrencyItemChainId, MysteryMachineCurrencyItemChainInfo> MysteryMachineCurrencyItemChains { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineProgressionEventProgressItemSource))]
        [GameConfigEntry("MergeMysteryMachineProgressionEventProgressItems", true, null)]
        public GameConfigLibrary<MysteryMachineProgressionEventProgressItemId, MysteryMachineProgressionEventProgressItemInfo> MysteryMachineProgressionEventProgressItems { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineProgressionEventProgressItemChainSource))]
        [GameConfigEntry("MergeMysteryMachineProgressionEventProgressItemChains", true, null)]
        public GameConfigLibrary<MysteryMachineProgressionEventProgressItemChainId, MysteryMachineProgressionEventProgressItemChainInfo> MysteryMachineProgressionEventProgressItemChains { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineHeatLevelSource))]
        [GameConfigEntry("MysteryMachineHeatLevels", true, null)]
        public GameConfigLibrary<MysteryMachineHeatLevelId, MysteryMachineHeatLevelInfo> MysteryMachineHeatLevels { get; set; }

        [GameConfigEntry("MysteryMachinePerks", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachinePerkSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachinePerkId, MysteryMachinePerkInfo> MysteryMachinePerks { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineSpecialSaleSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MysteryMachineSpecialSales", true, null)]
        public GameConfigLibrary<MysteryMachineSpecialSaleId, MysteryMachineSpecialSaleInfo> MysteryMachineSpecialSales { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineTaskSource))]
        [GameConfigEntry("MysteryMachineTasks", true, null)]
        public GameConfigLibrary<MysteryMachineTaskId, MysteryMachineTaskInfo> MysteryMachineTasks { get; set; }

        [GameConfigEntry("MysteryMachineTaskSets", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineTaskSetSource))]
        public GameConfigLibrary<MysteryMachineTaskSetId, MysteryMachineTaskSetInfo> MysteryMachineTaskSets { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineLevelSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MysteryMachineLevels", true, null)]
        public GameConfigLibrary<MysteryMachineLevelId, MysteryMachineLevelInfo> MysteryMachineLevels { get; set; }
        public Dictionary<MergeBoardId, MysteryMachineEventId> MysteryMachineEventBoards { get; set; }

        [GameConfigEntry("ProducerInventorySlots", true, null)]
        [GameConfigEntryTransform(typeof(ProducerInventorySlotSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ProducerInventorySlotId, ProducerInventorySlotConfig> ProducerInventorySlots { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(OfferPopupTriggerSource))]
        [GameConfigEntry("OfferPopupTriggers", true, null)]
        public GameConfigLibrary<OfferPopupTriggerId, OfferPopupTrigger> OfferPopupTriggers { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("LocationTravels", true, null)]
        [GameConfigEntryTransform(typeof(LocationTravelSource))]
        public GameConfigLibrary<LocationTravelId, LocationTravelInfo> LocationTravels { get; set; }

        private Dictionary<FlashSaleGroupId, FlashSaleGroupDefinition> combinedFlashSaleGroups;
        [GameConfigEntryTransform(typeof(FlashSaleSource))]
        [GameConfigEntry("FlashSales", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ShopItemId, FlashSaleDefinition> GarageFlashSales { get; set; }

        [GameConfigEntryTransform(typeof(FlashSaleSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("EventFlashSales", true, null)]
        public GameConfigLibrary<ShopItemId, FlashSaleDefinition> EventFlashSales { get; set; }

        [GameConfigEntry("FlashSaleGroups", true, null)]
        [GameConfigEntryTransform(typeof(FlashSalesGroupSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<FlashSaleGroupId, FlashSaleGroupDefinition> GarageFlashSaleGroups { get; set; }

        [GameConfigEntry("EventFlashSaleGroups", true, null)]
        [GameConfigEntryTransform(typeof(FlashSalesGroupSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<FlashSaleGroupId, FlashSaleGroupDefinition> EventFlashSaleGroups { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("FlashSaleShopSettings", true, null)]
        [GameConfigEntryTransform(typeof(FlashSaleShopSettingsSource))]
        public GameConfigLibrary<FlashSaleShopSettingsId, FlashSaleShopSettings> FlashSaleShopSettings { get; set; }

        [GameConfigEntry("DailyTasksV2", true, null)]
        [GameConfigEntryTransform(typeof(DailyTaskV2Source))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyTaskV2Id, DailyTaskV2Info> DailyTasksV2 { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DailyTasksV2CompletionRewardSource))]
        [GameConfigEntry("DailyTasksV2CompletionRewards", true, null)]
        public GameConfigLibrary<DailyTasksV2CompletionRewardId, DailyTasksV2CompletionRewardInfo> DailyTasksV2CompletionRewards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DailyTasksV2MergeChainSource))]
        [GameConfigEntry("DailyTasksV2MergeChains", true, null)]
        public GameConfigLibrary<MergeChainId, DailyTasksV2MergeChainInfo> DailyTasksV2MergeChains { get; set; }

        [GameConfigEntry("DailyTasksV2Settings", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        public DailyTasksV2Settings DailyTasksV2Settings { get; set; }
        public List<int> MysteryMachineItemIds { get; set; }

        [GameConfigEntry("EnergyModeEvents", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(EnergyModeEventSource))]
        public GameConfigLibrary<EnergyModeEventId, EnergyModeEventInfo> EnergyModeEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> MiniEventId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MiniEventConfigSource))]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntry("MiniEvents", true, null)]
        public GameConfigLibrary<MiniEventId, MiniEventInfo> MiniEvents { get; set; }

        [GameConfigEntry("MakeYourOwnOffers", true, null)]
        [GameConfigEntryTransform(typeof(MakeYourOwnOfferSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MetaOfferId, MakeYourOwnOfferInfo> MakeYourOwnOffers { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(SoloMilestoneEventInfoSource))]
        [GameConfigEntry("SoloMilestoneEvents", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<SoloMilestoneEventId, SoloMilestoneEventInfo> SoloMilestoneEvents { get; set; }

        [GameConfigEntryTransform(typeof(SoloMilestoneMilestonesInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("SoloMilestoneMilestones", true, null)]
        public GameConfigLibrary<SoloMilestoneMilestonesId, SoloMilestoneMilestonesInfo> SoloMilestoneMilestones { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("SoloMilestoneTokenSpawns", true, null)]
        [GameConfigEntryTransform(typeof(SoloMilestoneTokenSpawnsInfoSource))]
        public GameConfigLibrary<SoloMilestoneTokenSpawnsId, SoloMilestoneTokenSpawnsInfo> SoloMilestoneTokenSpawns { get; set; }

        [GameConfigEntry("DailyScoopMilestones", true, null)]
        [GameConfigEntryTransform(typeof(DailyScoopMilestoneDataSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyScoopMilestoneId, DailyScoopMilestoneData> DailyScoopMilestones { get; set; }

        [GameConfigEntry("DailyScoopStandardObjectives", true, null)]
        [GameConfigEntryTransform(typeof(DailyScoopStandardObjectiveDataSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyScoopStandardObjectiveId, DailyScoopStandardObjectiveData> DailyScoopStandardObjectives { get; set; }

        [GameConfigEntry("DailyScoopSpecialObjectives", true, null)]
        [GameConfigEntryTransform(typeof(DailyScoopSpecialObjectiveDataSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyScoopSpecialObjectiveId, DailyScoopSpecialObjectiveData> DailyScoopSpecialObjectives { get; set; }

        [GameConfigEntry("DailyScoopDays", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DailyScoopDayDataSource))]
        public GameConfigLibrary<DailyScoopDayId, DailyScoopDayData> DailyScoopDays { get; set; }

        [GameConfigEntry("DailyScoopWeeks", true, null)]
        [GameConfigEntryTransform(typeof(DailyScoopWeekDataSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyScoopWeekId, DailyScoopWeekData> DailyScoopWeeks { get; set; }

        [GameConfigEntry("DailyScoopEvents", true, null)]
        [GameConfigEntryTransform(typeof(DailyScoopEventInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<DailyScoopEventId, DailyScoopEventInfo> DailyScoopEvents { get; set; }

        [GameConfigEntryTransform(typeof(TagRewardsSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("TagRewards", true, null)]
        public GameConfigLibrary<string, TagRewardsInfo> TagRewards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("OrderRequirements", true, null)]
        [GameConfigEntryTransform(typeof(OrderRequirementsSource))]
        public GameConfigLibrary<OrderRequirementsId, OrderRequirements> OrderRequirements { get; set; }

        [GameConfigEntry("GemSettings", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        public GemSettings GemSettings { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MapObjectGroupInfoSource))]
        [GameConfigEntry("MapObjectGroups", true, null)]
        public GameConfigLibrary<MapObjectGroupId, MapObjectGroupInfo> MapObjectGroups { get; set; }
        public List<ItemDefinition> CutGemItems { get; set; }
        public HashSet<int> CardDeckItems { get; set; }
        public Dictionary<MergeBoardId, CollectibleBoardEventId> GemMineEventBoards { get; set; }

        [GameConfigEntry("ProgressionEventsV2", true, null)]
        [GameConfigEntryTransform(typeof(ProgressionEventV2Source))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ProgressionEventV2Id, ProgressionEventV2Info> ProgressionEventsV2 { get; set; }
        public HashSet<int> CardItems { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DailyTaskV2BoultonLeagueSource))]
        [GameConfigEntry("DailyTasksV2BoultonLeague", true, null)]
        public GameConfigLibrary<DailyTaskV2Id, DailyTaskV2BoultonLeagueInfo> DailyTasksV2BoultonLeague { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DailyTaskV2BoultonLeagueUnlimitedSource))]
        [GameConfigEntry("DailyTasksV2BoultonLeagueUnlimited", true, null)]
        public GameConfigLibrary<DailyTaskV2Id, DailyTaskV2BoultonLeagueUnlimitedInfo> DailyTasksV2BoultonLeagueUnlimited { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("DailyTasksV2ItemsBoultonLeague", true, null)]
        [GameConfigEntryTransform(typeof(DailyTasksV2ItemBoultonLeagueSource))]
        public GameConfigLibrary<ItemTypeConstant, DailyTasksV2ItemBoultonLeagueInfo> DailyTasksV2ItemsBoultonLeague { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("BoultonLeagueEvents", true, null)]
        [GameConfigEntryTransform(typeof(BoultonLeagueEventSource))]
        public GameConfigLibrary<BoultonLeagueEventId, BoultonLeagueEventInfo> BoultonLeagueEvents { get; set; }

        [GameConfigEntry("BoultonLeagueStages", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(BoultonLeagueStageSource))]
        public GameConfigLibrary<BoultonLeagueStageId, BoultonLeagueStageInfo> BoultonLeagueStages { get; set; }

        [GameConfigEntry("ItemsInPocket", true, null)]
        [GameConfigEntryTransform(typeof(ItemInPocketInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ItemInPocketId, ItemInPocketInfo> ItemInPocketInfos { get; set; }

        [GameConfigEntry("TemporaryCardCollectionEvents", true, null)]
        [GameConfigEntryTransform(typeof(TemporaryCardCollectionEventSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<TemporaryCardCollectionEventId, TemporaryCardCollectionEventInfo> TemporaryCardCollectionEvents { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineLeaderboardConfigSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MysteryMachineLeaderboardConfigs", true, null)]
        public GameConfigLibrary<MysteryMachineLeaderboardConfigId, MysteryMachineLeaderboardConfigInfo> MysteryMachineLeaderboardConfigs { get; set; }

        [GameConfigEntry("MysteryMachineLeaderboardRewards", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineLeaderboardRewardSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineLeaderboardRewardId, MysteryMachineLeaderboardRewardInfo> MysteryMachineLeaderboardRewards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MysteryMachineLeaderboardTopRankingRewards", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineLeaderboardTopRankingRewardSource))]
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

        [GameConfigEntry("CardCollectionPackInfos", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionPackInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionPackId, CardCollectionPackInfo> CardCollectionPackInfos { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(CardCollectionCardActivationInfoSource))]
        [GameConfigEntry("CardCollection_Card_Activation", true, null)]
        public GameConfigLibrary<CardCollectionCardActivationId, CardCollectionCardActivationInfo> CardCollectionCardActivationInfos { get; set; }

        [GameConfigEntry("CardCollection_Packs_Activation", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionPackActivationInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionPackActivationId, CardCollectionPackActivationInfo> CardCollectionPackActivationInfos { get; set; }

        [GameConfigEntry("CardCollection_HiddenRarity_Activation", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionHiddenRarityActivationInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionHiddenRarityActivationId, CardCollectionHiddenRarityActivationInfo> CardCollectionHiddenRarityActivationInfos { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("CardCollection_Set_Activation", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionSetActivationInfoSource))]
        public GameConfigLibrary<CardCollectionSetActivationId, CardCollectionSetActivationInfo> CardCollectionSetActivationInfos { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("CardCollectionBalanceInfos", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionBalanceInfoSource))]
        public GameConfigLibrary<CardCollectionBalanceId, CardCollectionBalanceInfo> CardCollectionBalanceInfos { get; set; }

        [GameConfigEntry("CardCollection_EvidenceBoxes", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionEvidenceBoxSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionEvidenceBoxId, CardCollectionEvidenceBoxInfo> CardCollectionEvidenceBoxes { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("CardCollection_DuplicateCardRewards", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionDuplicateRewardSource))]
        public GameConfigLibrary<CardCollectionDuplicateRewardId, CardCollectionDuplicateRewardInfo> CardCollectionDuplicateCardRewards { get; set; }

        [GameConfigEntry("TaskGroups", true, null)]
        [GameConfigEntryTransform(typeof(TaskGroupDefinitionSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<TaskGroupId, TaskGroupDefinition> TaskGroups { get; set; }

        [GameConfigEntryTransform(typeof(RewardContainerSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("RewardContainers", true, null)]
        public GameConfigLibrary<RewardContainerId, RewardContainerInfo> RewardContainers { get; set; }

        [GameConfigEntry("MysteryMachineScreens", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineScreenSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineScreenId, MysteryMachineScreenInfo> MysteryMachineScreens { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MysteryMachineScreenMessagePacks", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineScreenMessagePackSource))]
        public GameConfigLibrary<MysteryMachineScreenMessagePackId, MysteryMachineScreenMessagePackInfo> MysteryMachineScreenMessagePacks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineScreenMessageSource))]
        [GameConfigEntry("MysteryMachineScreenMessages", true, null)]
        public GameConfigLibrary<MysteryMachineScreenMessageId, MysteryMachineScreenMessageInfo> MysteryMachineScreenMessages { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("FallbackItems", true, null)]
        [GameConfigEntryTransform(typeof(FallbackItemInfoSource))]
        public GameConfigLibrary<FallbackItemId, FallbackItemInfo> FallbackItems { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(FallbackPlayerRewardInfoSource))]
        [GameConfigEntry("FallbackPlayerRewards", true, null)]
        public GameConfigLibrary<FallbackPlayerRewardId, FallbackPlayerRewardInfo> FallbackPlayerRewards { get; set; }
        public Dictionary<int, ItemInPocketInfo> ItemInPocketInfoByItemId { get; set; }
        public Dictionary<int, FallbackItemInfo> FallbackItemInfoByItemId { get; set; }
        public HashSet<ItemDefinition> ItemsAvailableOnlyDuringCardCollectionEvent { get; set; }
        public Dictionary<MysteryMachineLeaderboardConfigId, HashSet<PlayerSegmentId>> MysteryMachineLeaderboardRewardSegments { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        [GameConfigEntry("CardCollectionSettings", true, null)]
        public CardCollectionSettings CardCollectionSettings { get; set; }

        [GameConfigEntry("EnergySettings", true, null)]
        [GameConfigEntryTransform(typeof(EnergySettingsConfigSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<EnergyType, EnergySettingsConfig> EnergySettings { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("HotspotTables", true, null)]
        public GameConfigLibrary<CustomHotspotTableId, CustomHotspotTablesInfo> CustomTables { get; set; }
        public Dictionary<int, CardCollectionPackId> CardPacksByItemId { get; set; }
        public List<TemporaryCardCollectionEventInfo> OrderedTemporaryCardCollectionEventInfos { get; set; }
    }
}
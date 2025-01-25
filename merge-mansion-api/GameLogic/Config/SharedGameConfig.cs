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
        [GameConfigSyntaxAdapter(new string[] { "ItemKey -> ItemKey #key" }, new string[] { }, false)]
        [GameConfigEntry("Items", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "SequenceId -> SequenceId #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<int, ItemDefinition> Items { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MergeChainSource))]
        [GameConfigEntry("MergeChains", true, null)]
        public GameConfigLibrary<MergeChainId, MergeChainDefinition> MergeChains { get; set; }

        [GameConfigEntryTransform(typeof(CodexDiscoveryRewardSource))]
        [GameConfigEntry("CodexDiscoveryRewards", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CodexDiscoveryRewardId, CodexDiscoveryRewardInfo> CodexDiscoveryRewards { get; set; }

        [GameConfigEntry("CodexCategories", true, null)]
        [GameConfigEntryTransform(typeof(CodexCategorySource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CodexCategoryId, CodexCategoryInfo> CodexCategories { get; set; }

        [GameConfigEntryTransform(typeof(BubblesSetupSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("BubbleSetups", true, null)]
        public GameConfigLibrary<BubblesSetupId, BubblesSetup> BubbleSetups { get; set; }

        [GameConfigEntry("MergeRewards", true, null)]
        [GameConfigEntryTransform(typeof(MergeRewardSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MergeRewardId, MergeReward> XpMergeRewards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigEntry("TimedMergeBoards", true, null)]
        [GameConfigEntryTransform(typeof(TimedMergeBoardSource))]
        public GameConfigLibrary<MergeBoardId, TimedMergeBoard> TimedMergeBoards { get; set; }

        [GameConfigEntry("Boards", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "BoardId -> BoardId #key" }, new string[] { }, false)]
        public GameConfigLibrary<MergeBoardId, BoardInfo> Boards { get; set; }

        [GameConfigEntry("BoardEvents", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntryTransform(typeof(BoardEventSource))]
        public GameConfigLibrary<EventId, BoardEventInfo> BoardEvents { get; set; }

        [GameConfigEntry("ShopEvents", true, null)]
        [GameConfigEntryTransform(typeof(ShopEventConfigSourceItem))]
        [GameConfigSyntaxAdapter(new string[] { "ShopEventId -> ShopEventId #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<EventId, ShopEventInfo> ShopEvents { get; set; }

        [GameConfigEntry("CollectibleBoardEvents", true, null)]
        [GameConfigEntryTransform(typeof(CollectibleBoardEventSource))]
        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<CollectibleBoardEventId, CollectibleBoardEventInfo> CollectibleBoardEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigEntry("LeaderboardEvents", true, null)]
        [GameConfigEntryTransform(typeof(LeaderboardEventSource))]
        public GameConfigLibrary<LeaderboardEventId, LeaderboardEventInfo> LeaderboardEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntry("ProgressionEvents", true, null)]
        [GameConfigEntryTransform(typeof(ProgressionEventSource))]
        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        public GameConfigLibrary<ProgressionEventId, ProgressionEventInfo> ProgressionEvents { get; set; }

        [GameConfigEntry("MapCharacterEvents", true, null)]
        [GameConfigEntryTransform(typeof(MapCharacterEventDefinitionSource))]
        [GameConfigSyntaxAdapter(new string[] { "MapCharacterEventId -> MapCharacterEventId #key" }, new string[] { }, false)]
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

        [GameConfigEntry("EventTasks", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "EventTaskId -> EventTaskId #key" }, new string[] { }, false)]
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

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("TieredOffers", true, null)]
        [GameConfigEntryTransform(typeof(TieredOfferSource))]
        public GameConfigLibrary<TieredOfferId, TieredOffer> TieredOffers { get; set; }

        [GameConfigEntry("DailyTasks", true, null)]
        [GameConfigEntryTransform(typeof(DailyTaskSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyTaskId, DailyTaskDefinition> DailyTasks { get; set; }

        [GameConfigEntry("Areas", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<AreaId, AreaInfo> Areas { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "HotspotId -> HotspotId #key" }, new string[] { }, false)]
        [GameConfigEntry("HotspotDefinitions", true, null)]
        [GameConfigEntryTransform(typeof(HotspotDefinitionSource))]
        public GameConfigLibrary<HotspotId, HotspotDefinition> HotspotDefinitions { get; set; }

        [GameConfigEntry("MapSpots", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "MapSpotId -> MapSpotId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MapSpotSource))]
        public GameConfigLibrary<MapSpotId, MapSpotInfo> MapSpots { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "LevelKey -> LevelKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(PlayerLevelDataSource))]
        [GameConfigEntry("PlayerLevels", true, null)]
        public GameConfigLibrary<int, PlayerLevelData> PlayerLevels { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("InventorySlots", true, null)]
        public GameConfigLibrary<InventorySlotId, InventorySlotsConfig> InventorySlots { get; set; }

        [GameConfigEntry("LevelUpTutorialConfig", true, null)]
        [GameConfigEntryTransform(typeof(LevelUpTutorialConfigSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigId -> ConfigId #key" }, new string[] { }, false)]
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
        [GameConfigSyntaxAdapter(new string[] { "ShopItemId -> ShopItemId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DynamicPurchaseDefinitionSource))]
        public GameConfigLibrary<ShopItemId, DynamicPurchaseDefinition> DynamicPurchaseProducts { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(CurrencyBankSource))]
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
        [GameConfigEntryTransform(typeof(AddressablesDownloadProcessSource))]
        [GameConfigEntry("AddressablesDownloadProcesses", true, null)]
        public GameConfigLibrary<AddressablesDownloadProcessId, AddressablesDownloadProcess> AddressablesDownloadProcesses { get; set; }

        [GameConfigEntryTransform(typeof(ReEngagementSettingsSource))]
        [GameConfigEntry("ReEngagementSettings", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ReEngagementSettingsId, ReEngagementSettings> ReEngagementSettings { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        [GameConfigEntry("FishingSettings", true, null)]
        public FishingSettings FishingSettings { get; set; }

        [GameConfigEntry("ScheduledActions", true, null)]
        [GameConfigEntryTransform(typeof(ScheduledActionSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<ScheduledActionId, ScheduledActionInfo> ScheduledActions { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "StoryDefinitionId -> StoryDefinitionId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(StoryElementInfoSourceItem))]
        [GameConfigEntry("StoryDefinitions", true, null)]
        public GameConfigLibrary<StoryDefinitionId, StoryElementInfo> StoryElements { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "DialogItemId -> DialogItemId #key" }, new string[] { }, false)]
        [GameConfigEntry("DialogItems", true, null)]
        [GameConfigEntryTransform(typeof(DialogItemInfoSourceItem))]
        public GameConfigLibrary<DialogItemId, DialogItemInfo> DialogItems { get; set; }

        [GameConfigEntryTransform(typeof(CollectibleDialoguesSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("CollectibleDialoguesInfo", true, null)]
        public GameConfigLibrary<CollectibleDialoguesInfoId, CollectibleDialoguesInfo> CollectibleDialoguesInfo { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "DialogCharacterType -> DialogCharacterType #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DialogueCharacterSource))]
        [GameConfigEntry("DialogueCharacters", true, null)]
        public GameConfigLibrary<DialogCharacterType, DialogueCharacterInfo> DialogueCharacters { get; set; }

        [GameConfigEntry("GarageCleanupEvents", true, null)]
        [GameConfigEntryTransform(typeof(GarageCleanupEventSourceConfigItem))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<GarageCleanupEventId, GarageCleanupEventInfo> GarageCleanupEvents { get; set; }

        [GameConfigEntry("GarageCleanupBoardRows", true, null)]
        [GameConfigEntryTransform(typeof(GarageCleanupBoardRowSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key", "RowNumber -> RowNumber #key" }, new string[] { }, false)]
        public GameConfigLibrary<GarageCleanupBoardRowId, GarageCleanupBoardRowInfo> GarageCleanupBoardRows { get; set; }

        [GameConfigEntry("GarageCleanupPatternSets", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(GarageCleanupPatternSetSource))]
        public GameConfigLibrary<GarageCleanupPatternSetId, GarageCleanupPatternSetInfo> GarageCleanupPatternSets { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key", "RowNumber -> RowNumber #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(GarageCleanupPatternRowSource))]
        [GameConfigEntry("GarageCleanupPatternRows", true, null)]
        public GameConfigLibrary<GarageCleanupPatternRowId, GarageCleanupPatternRowInfo> GarageCleanupPatternRows { get; set; }

        [GameConfigEntry("GarageCleanupRewards", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(GarageCleanupRewardSource))]
        public GameConfigLibrary<GarageCleanupRewardId, GarageCleanupRewardInfo> GarageCleanupRewards { get; set; }

        [GameConfigEntryTransform(typeof(DecorationInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "DecorationId -> DecorationId #key" }, new string[] { }, false)]
        [GameConfigEntry("Decorations", true, null)]
        public GameConfigLibrary<DecorationId, DecorationInfo> Decorations { get; set; }

        [GameConfigEntryTransform(typeof(LayeredDecorationSetSource))]
        [GameConfigEntry("LayeredDecorations", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "SetId -> SetId #key" }, new string[] { }, false)]
        public GameConfigLibrary<LayeredDecorationSetId, LayeredDecorationSetInfo> LayeredDecorations { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "AuthenticationPlatformId -> AuthenticationPlatformId #key" }, new string[] { }, false)]
        [GameConfigEntry("SocialAuthentication", true, null)]
        public GameConfigLibrary<AuthenticationPlatform, SocialAuthenticationConfig> SocialAuthentication { get; set; }

        [GameConfigEntry("SocialMedia", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(SocialMediaSource))]
        public GameConfigLibrary<SocialMediaId, SocialMediaInfo> SocialMedia { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "SocialAuthRewardId -> SocialAuthRewardId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(SocialAuthRewardSource))]
        [GameConfigEntry("SocialAuthRewards", true, null)]
        public GameConfigLibrary<SocialAuthRewardId, SocialAuthRewardInfo> SocialAuthRewards { get; set; }

        [GameConfigEntry("Videos", true, null)]
        [GameConfigEntryTransform(typeof(VideoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<VideoId, Video> Videos { get; set; }

        [GameConfigEntry("SlideShows", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(SlideShowSource))]
        public GameConfigLibrary<SlideShowId, SlideShow> SlideShows { get; set; }

        [GameConfigEntryTransform(typeof(CutsceneInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "CutsceneId -> CutsceneId #key" }, new string[] { }, false)]
        [GameConfigEntry("Cutscenes", true, null)]
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
        [GameConfigEntryTransform(typeof(ProgressionEventStreakRewardsSource))]
        [GameConfigEntry("ProgressionEventStreaks", true, null)]
        public GameConfigLibrary<ProgressionEventStreakId, ProgressionEventStreakRewards> ProgressionEventStreaks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "SeasonId -> SeasonId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(SeasonInfoSource))]
        [GameConfigEntry("Seasons", true, null)]
        public GameConfigLibrary<SeasonId, SeasonInfo> Seasons { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(RentableInventorySettingsSource))]
        [GameConfigEntry("RentableInventorySettings", true, null)]
        public GameConfigLibrary<RentableInventorySettingsId, RentableInventorySettings> RentableInventorySettings { get; set; }

        [GameConfigEntry("PetInfos", true, null)]
        [GameConfigEntryTransform(typeof(PetInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<PetId, PetInfo> PetInfos { get; set; }

        [GameConfigEntry("DecorationShops", true, null)]
        [GameConfigEntryTransform(typeof(DecorationShopSource))]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DecorationShopId, DecorationShopInfo> DecorationShops { get; set; }

        [GameConfigEntry("DecorationShopSets", true, null)]
        [GameConfigEntryTransform(typeof(DecorationShopSetSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DecorationShopSetId, DecorationShopSetInfo> DecorationShopSets { get; set; }

        [GameConfigEntryTransform(typeof(DecorationShopItemSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("DecorationShopItems", true, null)]
        public GameConfigLibrary<DecorationShopItemId, DecorationShopItemInfo> DecorationShopItems { get; set; }

        [GameConfigEntry("DynamicEventTasks", true, null)]
        [GameConfigEntryTransform(typeof(EventTaskConfigSourceItem))]
        [GameConfigSyntaxAdapter(new string[] { "EventTaskId -> EventTaskId #key" }, new string[] { }, false)]
        public GameConfigLibrary<EventTaskId, EventTaskInfo> DynamicEventTasks { get; set; }

        [GameConfigEntry("DynamicEventRewards", true, null)]
        [GameConfigEntryTransform(typeof(DynamicEventRewardConfigSourceItem))]
        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        public GameConfigLibrary<DynamicEventRewardId, DynamicEventRewardInfo> DynamicEventRewards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("DynamicEventItems", true, null)]
        [GameConfigEntryTransform(typeof(DynamicEventItemInfoSourceItem))]
        public GameConfigLibrary<DynamicEventItemId, DynamicEventItemInfo> DynamicEventItems { get; set; }

        [GameConfigEntry("DynamicEventHelpers", true, null)]
        [GameConfigEntryTransform(typeof(DynamicEventHelperInfoSourceItem))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
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
        [GameConfigSyntaxAdapter(new string[] { "ProductId -> ProductId #key" }, new string[] { }, false)]
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

        [GameConfigEntryTransform(typeof(MergeMansionOfferSourceConfigItem))]
        [GameConfigEntry("TieredOfferItems", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "OfferId -> OfferId #key" }, new string[] { }, false)]
        public GameConfigLibrary<MetaOfferId, MergeMansionOfferInfo> TieredOfferItems { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "GroupId -> GroupId #key" }, new string[] { }, false)]
        [GameConfigEntry("OfferGroups", true, null)]
        [GameConfigEntryTransform(typeof(MergeMansionOfferGroupSourceItem))]
        public GameConfigLibrary<MetaOfferGroupId, MergeMansionOfferGroupInfo> OfferGroups { get; set; }

        [GameConfigEntry("SideBoardEvents", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(SideBoardEventSource))]
        public GameConfigLibrary<SideBoardEventId, SideBoardEventInfo> SideBoardEvents { get; set; }

        [GameConfigEntry("EventCharacters", true, null)]
        [GameConfigEntryTransform(typeof(EventCharacterInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "EventCharacterId -> EventCharacterId #key" }, new string[] { }, false)]
        public GameConfigLibrary<EventCharacterId, EventCharacterInfo> EventCharacters { get; set; }
        public Dictionary<MergeBoardId, SideBoardEventId> SideBoardEventBoards { get; set; }
        public List<ItemDefinition> FishingRodItems { get; set; }
        public Dictionary<ItemDefinition, OverrideSpawnChanceFeatures> OverrideSpawnChanceByItemDefinition { get; set; }
        public List<HotspotId> AreaUnlockHotspots { get; set; }

        [GameConfigEntry("Music_Tracks", true, null)]
        [GameConfigEntryTransform(typeof(MMTrackSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<string, MMTrack> Tracks { get; set; }

        [GameConfigEntry("Music_Playlists", true, null)]
        [GameConfigEntryTransform(typeof(MMPlaylistSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<string, MMPlaylist> Playlists { get; set; }

        [GameConfigEntry("CardStacks", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardStackId, CardStackInfo> CardStacks { get; set; }

        [GameConfigEntry("WebShopSettings", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        public WebShopSettings WebShopSettings { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(AdvertisementPlacementsSource))]
        [GameConfigEntry("AdvertisementPlacements", true, null)]
        public GameConfigLibrary<AdvertisementPlacementId, AdvertisementPlacementsInfo> AdvertisementPlacements { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineEventSource))]
        [GameConfigEntry("MysteryMachineEvents", true, null)]
        public GameConfigLibrary<MysteryMachineEventId, MysteryMachineEventInfo> MysteryMachineEvents { get; set; }

        [GameConfigEntry("MysteryMachineItemSets", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineItemSetSource))]
        public GameConfigLibrary<MysteryMachineItemSetId, MysteryMachineItemSetInfo> MysteryMachineItemSets { get; set; }

        [GameConfigEntry("MysteryMachineItems", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineItemSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineItemId, MysteryMachineItemInfo> MysteryMachineItems { get; set; }

        [GameConfigEntry("MysteryMachineItemScores", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineItemScoreSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
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
        [GameConfigEntryTransform(typeof(MysteryMachineMultiplierSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineMultiplierId, MysteryMachineMultiplierInfo> MysteryMachineMultipliers { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineSource))]
        [GameConfigEntry("MergeMysteryMachines", true, null)]
        public GameConfigLibrary<MysteryMachineId, MysteryMachineInfo> MysteryMachines { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MergeMysteryMachineCurrencyItems", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineCurrencyItemSource))]
        public GameConfigLibrary<MysteryMachineCurrencyItemId, MysteryMachineCurrencyItemInfo> MysteryMachineCurrencyItems { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MergeMysteryMachineCurrencyItemChains", true, null)]
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

        [GameConfigEntry("MysteryMachineHeatLevels", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineHeatLevelSource))]
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

        [GameConfigEntryTransform(typeof(MysteryMachineTaskSetSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MysteryMachineTaskSets", true, null)]
        public GameConfigLibrary<MysteryMachineTaskSetId, MysteryMachineTaskSetInfo> MysteryMachineTaskSets { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineLevelSource))]
        [GameConfigEntry("MysteryMachineLevels", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MysteryMachineLevelId, MysteryMachineLevelInfo> MysteryMachineLevels { get; set; }
        public Dictionary<MergeBoardId, MysteryMachineEventId> MysteryMachineEventBoards { get; set; }

        [GameConfigEntry("ProducerInventorySlots", true, null)]
        [GameConfigEntryTransform(typeof(ProducerInventorySlotSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ProducerInventorySlotId, ProducerInventorySlotConfig> ProducerInventorySlots { get; set; }

        [GameConfigEntry("OfferPopupTriggers", true, null)]
        [GameConfigEntryTransform(typeof(OfferPopupTriggerSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<OfferPopupTriggerId, OfferPopupTrigger> OfferPopupTriggers { get; set; }

        [GameConfigEntry("LocationTravels", true, null)]
        [GameConfigEntryTransform(typeof(LocationTravelSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<LocationTravelId, LocationTravelInfo> LocationTravels { get; set; }

        private Dictionary<FlashSaleGroupId, FlashSaleGroupDefinition> combinedFlashSaleGroups;
        [GameConfigEntry("FlashSales", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(FlashSaleSource))]
        public GameConfigLibrary<ShopItemId, FlashSaleDefinition> GarageFlashSales { get; set; }

        [GameConfigEntry("EventFlashSales", true, null)]
        [GameConfigEntryTransform(typeof(FlashSaleSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ShopItemId, FlashSaleDefinition> EventFlashSales { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(FlashSalesGroupSource))]
        [GameConfigEntry("FlashSaleGroups", true, null)]
        public GameConfigLibrary<FlashSaleGroupId, FlashSaleGroupDefinition> GarageFlashSaleGroups { get; set; }

        [GameConfigEntryTransform(typeof(FlashSalesGroupSource))]
        [GameConfigEntry("EventFlashSaleGroups", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<FlashSaleGroupId, FlashSaleGroupDefinition> EventFlashSaleGroups { get; set; }

        [GameConfigEntry("FlashSaleShopSettings", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(FlashSaleShopSettingsSource))]
        public GameConfigLibrary<FlashSaleShopSettingsId, FlashSaleShopSettings> FlashSaleShopSettings { get; set; }

        [GameConfigEntryTransform(typeof(DailyTaskV2Source))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("DailyTasksV2", true, null)]
        public GameConfigLibrary<DailyTaskV2Id, DailyTaskV2Info> DailyTasksV2 { get; set; }

        [GameConfigEntryTransform(typeof(DailyTasksV2CompletionRewardSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("DailyTasksV2CompletionRewards", true, null)]
        public GameConfigLibrary<DailyTasksV2CompletionRewardId, DailyTasksV2CompletionRewardInfo> DailyTasksV2CompletionRewards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DailyTasksV2MergeChainSource))]
        [GameConfigEntry("DailyTasksV2MergeChains", true, null)]
        public GameConfigLibrary<MergeChainId, DailyTasksV2MergeChainInfo> DailyTasksV2MergeChains { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        [GameConfigEntry("DailyTasksV2Settings", true, null)]
        public DailyTasksV2Settings DailyTasksV2Settings { get; set; }
        public List<int> MysteryMachineItemIds { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("EnergyModeEvents", true, null)]
        [GameConfigEntryTransform(typeof(EnergyModeEventSource))]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<EnergyModeEventId, EnergyModeEventInfo> EnergyModeEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> MiniEventId #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MiniEventConfigSource))]
        [GameConfigEntry("MiniEvents", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<MiniEventId, MiniEventInfo> MiniEvents { get; set; }

        [GameConfigEntry("MakeYourOwnOffers", true, null)]
        [GameConfigEntryTransform(typeof(MakeYourOwnOfferSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MetaOfferId, MakeYourOwnOfferInfo> MakeYourOwnOffers { get; set; }

        [GameConfigEntry("SoloMilestoneEvents", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntryTransform(typeof(SoloMilestoneEventInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<SoloMilestoneEventId, SoloMilestoneEventInfo> SoloMilestoneEvents { get; set; }

        [GameConfigEntry("SoloMilestoneMilestones", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(SoloMilestoneMilestonesInfoSource))]
        public GameConfigLibrary<SoloMilestoneMilestonesId, SoloMilestoneMilestonesInfo> SoloMilestoneMilestones { get; set; }

        [GameConfigEntry("SoloMilestoneTokenSpawns", true, null)]
        [GameConfigEntryTransform(typeof(SoloMilestoneTokenSpawnsInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<SoloMilestoneTokenSpawnsId, SoloMilestoneTokenSpawnsInfo> SoloMilestoneTokenSpawns { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DailyScoopMilestoneDataSource))]
        [GameConfigEntry("DailyScoopMilestones", true, null)]
        public GameConfigLibrary<DailyScoopMilestoneId, DailyScoopMilestoneData> DailyScoopMilestones { get; set; }

        [GameConfigEntryTransform(typeof(DailyScoopStandardObjectiveDataSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("DailyScoopStandardObjectives", true, null)]
        public GameConfigLibrary<DailyScoopStandardObjectiveId, DailyScoopStandardObjectiveData> DailyScoopStandardObjectives { get; set; }

        [GameConfigEntryTransform(typeof(DailyScoopSpecialObjectiveDataSource))]
        [GameConfigEntry("DailyScoopSpecialObjectives", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyScoopSpecialObjectiveId, DailyScoopSpecialObjectiveData> DailyScoopSpecialObjectives { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(DailyScoopDayDataSource))]
        [GameConfigEntry("DailyScoopDays", true, null)]
        public GameConfigLibrary<DailyScoopDayId, DailyScoopDayData> DailyScoopDays { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("DailyScoopWeeks", true, null)]
        [GameConfigEntryTransform(typeof(DailyScoopWeekDataSource))]
        public GameConfigLibrary<DailyScoopWeekId, DailyScoopWeekData> DailyScoopWeeks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("DailyScoopEvents", true, null)]
        [GameConfigEntryTransform(typeof(DailyScoopEventInfoSource))]
        public GameConfigLibrary<DailyScoopEventId, DailyScoopEventInfo> DailyScoopEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(TagRewardsSource))]
        [GameConfigEntry("TagRewards", true, null)]
        public GameConfigLibrary<string, TagRewardsInfo> TagRewards { get; set; }

        [GameConfigEntry("OrderRequirements", true, null)]
        [GameConfigEntryTransform(typeof(OrderRequirementsSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
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
        public HashSet<int> CardItems { get; set; }

        [GameConfigEntry("DailyTasksV2BoultonLeague", true, null)]
        [GameConfigEntryTransform(typeof(DailyTaskV2BoultonLeagueSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyTaskV2Id, DailyTaskV2BoultonLeagueInfo> DailyTasksV2BoultonLeague { get; set; }

        [GameConfigEntry("DailyTasksV2BoultonLeagueUnlimited", true, null)]
        [GameConfigEntryTransform(typeof(DailyTaskV2BoultonLeagueUnlimitedSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyTaskV2Id, DailyTaskV2BoultonLeagueUnlimitedInfo> DailyTasksV2BoultonLeagueUnlimited { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("DailyTasksV2ItemsBoultonLeague", true, null)]
        [GameConfigEntryTransform(typeof(DailyTasksV2ItemBoultonLeagueSource))]
        public GameConfigLibrary<ItemTypeConstant, DailyTasksV2ItemBoultonLeagueInfo> DailyTasksV2ItemsBoultonLeague { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntryTransform(typeof(BoultonLeagueEventSource))]
        [GameConfigEntry("BoultonLeagueEvents", true, null)]
        public GameConfigLibrary<BoultonLeagueEventId, BoultonLeagueEventInfo> BoultonLeagueEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(BoultonLeagueStageSource))]
        [GameConfigEntry("BoultonLeagueStages", true, null)]
        public GameConfigLibrary<BoultonLeagueStageId, BoultonLeagueStageInfo> BoultonLeagueStages { get; set; }

        [GameConfigEntry("ItemsInPocket", true, null)]
        [GameConfigEntryTransform(typeof(ItemInPocketInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        public GameConfigLibrary<ItemInPocketId, ItemInPocketInfo> ItemInPocketInfos { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntryTransform(typeof(TemporaryCardCollectionEventSource))]
        [GameConfigEntry("TemporaryCardCollectionEvents", true, null)]
        public GameConfigLibrary<TemporaryCardCollectionEventId, TemporaryCardCollectionEventInfo> TemporaryCardCollectionEvents { get; set; }

        [GameConfigEntry("MysteryMachineLeaderboardConfigs", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineLeaderboardConfigSource))]
        public GameConfigLibrary<MysteryMachineLeaderboardConfigId, MysteryMachineLeaderboardConfigInfo> MysteryMachineLeaderboardConfigs { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineLeaderboardRewardSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MysteryMachineLeaderboardRewards", true, null)]
        public GameConfigLibrary<MysteryMachineLeaderboardRewardId, MysteryMachineLeaderboardRewardInfo> MysteryMachineLeaderboardRewards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineLeaderboardTopRankingRewardSource))]
        [GameConfigEntry("MysteryMachineLeaderboardTopRankingRewards", true, null)]
        public GameConfigLibrary<MysteryMachineLeaderboardTopRankingRewardId, MysteryMachineLeaderboardTopRankingRewardInfo> MysteryMachineLeaderboardTopRankingRewards { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineLeaderboardPercentileRankingRewardSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("MysteryMachineLeaderboardPercentileRankingRewards", true, null)]
        public GameConfigLibrary<MysteryMachineLeaderboardPercentileRankingRewardId, MysteryMachineLeaderboardPercentileRankingRewardInfo> MysteryMachineLeaderboardPercentileRankingRewards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("CardCollectionCardInfos", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionCardInfoSource))]
        public GameConfigLibrary<CardCollectionCardId, CardCollectionCardInfo> CardCollectionCardInfos { get; set; }

        [GameConfigEntryTransform(typeof(CardCollectionCardSetInfoSource))]
        [GameConfigEntry("CardCollectionCardSetInfos", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionCardSetId, CardCollectionCardSetInfo> CardCollectionCardSetInfos { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(CardCollectionPackInfoSource))]
        [GameConfigEntry("CardCollectionPackInfos", true, null)]
        public GameConfigLibrary<CardCollectionPackId, CardCollectionPackInfo> CardCollectionPackInfos { get; set; }

        [GameConfigEntryTransform(typeof(CardCollectionCardActivationInfoSource))]
        [GameConfigEntry("CardCollection_Card_Activation", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionCardActivationId, CardCollectionCardActivationInfo> CardCollectionCardActivationInfos { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(CardCollectionPackActivationInfoSource))]
        [GameConfigEntry("CardCollection_Packs_Activation", true, null)]
        public GameConfigLibrary<CardCollectionPackActivationId, CardCollectionPackActivationInfo> CardCollectionPackActivationInfos { get; set; }

        [GameConfigEntry("CardCollection_HiddenRarity_Activation", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionHiddenRarityActivationInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionHiddenRarityActivationId, CardCollectionHiddenRarityActivationInfo> CardCollectionHiddenRarityActivationInfos { get; set; }

        [GameConfigEntry("CardCollection_Set_Activation", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionSetActivationInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionSetActivationId, CardCollectionSetActivationInfo> CardCollectionSetActivationInfos { get; set; }

        [GameConfigEntryTransform(typeof(CardCollectionBalanceInfoSource))]
        [GameConfigEntry("CardCollectionBalanceInfos", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionBalanceId, CardCollectionBalanceInfo> CardCollectionBalanceInfos { get; set; }

        [GameConfigEntry("CardCollection_EvidenceBoxes", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionEvidenceBoxSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionEvidenceBoxId, CardCollectionEvidenceBoxInfo> CardCollectionEvidenceBoxes { get; set; }

        [GameConfigEntry("CardCollection_DuplicateCardRewards", true, null)]
        [GameConfigEntryTransform(typeof(CardCollectionDuplicateRewardSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<CardCollectionDuplicateRewardId, CardCollectionDuplicateRewardInfo> CardCollectionDuplicateCardRewards { get; set; }

        [GameConfigEntry("TaskGroups", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(TaskGroupDefinitionSource))]
        public GameConfigLibrary<TaskGroupId, TaskGroupDefinition> TaskGroups { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("RewardContainers", true, null)]
        [GameConfigEntryTransform(typeof(RewardContainerSource))]
        public GameConfigLibrary<RewardContainerId, RewardContainerInfo> RewardContainers { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineScreenSource))]
        [GameConfigEntry("MysteryMachineScreens", true, null)]
        public GameConfigLibrary<MysteryMachineScreenId, MysteryMachineScreenInfo> MysteryMachineScreens { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineScreenMessagePackSource))]
        [GameConfigEntry("MysteryMachineScreenMessagePacks", true, null)]
        public GameConfigLibrary<MysteryMachineScreenMessagePackId, MysteryMachineScreenMessagePackInfo> MysteryMachineScreenMessagePacks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(MysteryMachineScreenMessageSource))]
        [GameConfigEntry("MysteryMachineScreenMessages", true, null)]
        public GameConfigLibrary<MysteryMachineScreenMessageId, MysteryMachineScreenMessageInfo> MysteryMachineScreenMessages { get; set; }

        [GameConfigEntryTransform(typeof(FallbackItemInfoSource))]
        [GameConfigEntry("FallbackItems", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<FallbackItemId, FallbackItemInfo> FallbackItems { get; set; }

        [GameConfigEntry("FallbackPlayerRewards", true, null)]
        [GameConfigEntryTransform(typeof(FallbackPlayerRewardInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<FallbackPlayerRewardId, FallbackPlayerRewardInfo> FallbackPlayerRewards { get; set; }
        public Dictionary<int, ItemInPocketInfo> ItemInPocketInfoByItemId { get; set; }
        public Dictionary<int, FallbackItemInfo> FallbackItemInfoByItemId { get; set; }
        public HashSet<ItemDefinition> ItemsAvailableOnlyDuringCardCollectionEvent { get; set; }
        public Dictionary<MysteryMachineLeaderboardConfigId, HashSet<PlayerSegmentId>> MysteryMachineLeaderboardRewardSegments { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        [GameConfigEntry("CardCollectionSettings", true, null)]
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
        [GameConfigEntryTransform(typeof(TheGreatEscapeMinigameInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
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

        [GameConfigEntryTransform(typeof(RewardUpgradableSource))]
        [GameConfigEntry("RewardUpgradables", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<RewardUpgradableId, RewardUpgradableInfo> RewardUpgradables { get; set; }

        [GameConfigEntry("ShortLeaderboardEvents", true, null)]
        [GameConfigEntryTransform(typeof(ShortLeaderboardEventSource))]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ShortLeaderboardEventId, ShortLeaderboardEventInfo> ShortLeaderboardEvents { get; set; }

        [GameConfigEntry("ShortLeaderboardEventStages", true, null)]
        [GameConfigEntryTransform(typeof(ShortLeaderboardEventStageSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ShortLeaderboardEventStageId, ShortLeaderboardEventStageInfo> ShortLeaderboardEventStages { get; set; }

        [GameConfigEntryTransform(typeof(SharedProducerSettingsSource))]
        [GameConfigEntry("SharedProducerSettings", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<SharedProducerSettingsId, SharedProducerSettings> SharedProducerSettings { get; set; }
        public HashSet<MergeBoardId> ShortLeaderboardEventBoards { get; set; }
    }
}
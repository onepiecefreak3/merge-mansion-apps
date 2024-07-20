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

namespace GameLogic.Config
{
    public class SharedGameConfig : SharedGameConfigBase
    {
#region Items
        [GameConfigEntry("Items")]
        public GameConfigLibrary<int, ItemDefinition> Items { get; set; }

        [GameConfigEntry("MergeChains")]
        public GameConfigLibrary<MergeChainId, MergeChainDefinition> MergeChains { get; set; }

        [GameConfigEntry("CodexDiscoveryRewards")]
        public GameConfigLibrary<CodexDiscoveryRewardId, CodexDiscoveryRewardInfo> CodexDiscoveryRewards { get; set; }

        [GameConfigEntry("CodexCategories")]
        public GameConfigLibrary<CodexCategoryId, CodexCategoryInfo> CodexCategories { get; set; }

        [GameConfigEntry("BubbleSetups")]
        public GameConfigLibrary<BubblesSetupId, BubblesSetup> BubbleSetups { get; set; }

        [GameConfigEntry("MergeRewards")]
        public GameConfigLibrary<MergeRewardId, MergeReward> XpMergeRewards { get; set; }

#endregion
#region Boards
        [GameConfigEntry("TimedMergeBoards")]
        public GameConfigLibrary<MergeBoardId, TimedMergeBoard> TimedMergeBoards { get; set; }

        [GameConfigEntry("Boards")]
        public GameConfigLibrary<MergeBoardId, BoardInfo> Boards { get; set; }

#endregion
#region Events
        [GameConfigEntry("BoardEvents")]
        public GameConfigLibrary<EventId, BoardEventInfo> BoardEvents { get; set; }

        [GameConfigEntry("ShopEvents")]
        public GameConfigLibrary<EventId, ShopEventInfo> ShopEvents { get; set; }

        [GameConfigEntry("CollectibleBoardEvents")]
        public GameConfigLibrary<CollectibleBoardEventId, CollectibleBoardEventInfo> CollectibleBoardEvents { get; set; }

        [GameConfigEntry("LeaderboardEvents")]
        public GameConfigLibrary<LeaderboardEventId, LeaderboardEventInfo> LeaderboardEvents { get; set; }

        [GameConfigEntry("ProgressionEvents")]
        public GameConfigLibrary<ProgressionEventId, ProgressionEventInfo> ProgressionEvents { get; set; }

        [GameConfigEntry("MapCharacterEvents")]
        public GameConfigLibrary<MapCharacterEventId, MapCharacterEventDefinition> MapCharacterEvents { get; set; }

        [GameConfigEntry("EventCurrencies")]
        public GameConfigLibrary<EventCurrencyId, EventCurrencyInfo> EventCurrencies { get; set; }

        [GameConfigEntry("EventLevels")]
        public GameConfigLibrary<EventLevelId, EventLevelInfo> EventLevels { get; set; }

        [GameConfigEntry("EventLevelSets")]
        private GameConfigLibrary<EventLevelSetId, EventLevels> LevelSets { get; set; }

        [GameConfigEntry("EventTasks")]
        public GameConfigLibrary<EventTaskId, EventTaskInfo> EventTasks { get; set; }

        [GameConfigEntry("EventOffers")]
        public GameConfigLibrary<EventOfferId, EventOfferInfo> EventOffers { get; set; }

        [GameConfigEntry("ProgressionEventPerks")]
        public GameConfigLibrary<ProgressionEventPerkId, ProgressionEventPerkInfo> ProgressionEventPerks { get; set; }

        [GameConfigEntry("EventOfferSets", true, true, true)]
        public GameConfigLibrary<EventOfferSetId, EventOfferSetInfo> EventOfferSets { get; set; }

        [GameConfigEntry("AutoOfferSettings", true, true, true)]
        public GameConfigLibrary<AutoOfferSettingsId, AutoOfferSettingsInfo> AutoOfferSettings { get; set; }

        [GameConfigEntry("TieredOffers", true, true, true)]
        public GameConfigLibrary<TieredOfferId, TieredOffer> TieredOffers { get; set; }

        [GameConfigEntry("DailyTasks", true, true, true)]
        public GameConfigLibrary<DailyTaskId, DailyTaskDefinition> DailyTasks { get; set; }

#endregion
#region Areas
        [GameConfigEntry("Areas")]
        public GameConfigLibrary<AreaId, AreaInfo> Areas { get; set; }

        [GameConfigEntry("HotspotDefinitions")]
        public GameConfigLibrary<HotspotId, HotspotDefinition> HotspotDefinitions { get; set; }

        [GameConfigEntry("MapSpots", true, true, true)]
        public GameConfigLibrary<MapSpotId, MapSpotInfo> MapSpots { get; set; }

#endregion
#region Player
        [GameConfigEntry("PlayerLevels", true, true, true)]
        public GameConfigLibrary<int, PlayerLevelData> PlayerLevels { get; set; }

        [GameConfigEntry("InventorySlots", true, true, true)]
        public GameConfigLibrary<InventorySlotId, InventorySlotsConfig> InventorySlots { get; set; }

        [GameConfigEntry("LevelUpTutorialConfig", true, true, true)]
        public GameConfigLibrary<LevelUpTutorialConfigId, LevelUpTutorialConfig> LevelUpTutorialConfig { get; set; }

#endregion
#region Shops
        [GameConfigEntry("ShopItems", true, true, true)]
        public GameConfigLibrary<ShopItemId, ShopItemInfo> ShopItems { get; set; }

        [GameConfigEntry("FlashSaleGroups", true, true, true)]
        public GameConfigLibrary<FlashSaleGroupId, FlashSaleGroupDefinition> FlashSaleGroups { get; set; }

        [GameConfigEntry("ShopLayouts", true, true, true)]
        public GameConfigLibrary<ShopLayoutId, ShopLayout> ShopLayouts { get; set; }

        [GameConfigEntry("DynamicPurchaseProducts")]
        public GameConfigLibrary<ShopItemId, DynamicPurchaseDefinition> DynamicPurchaseProducts { get; set; }

        [GameConfigEntry("CurrencyBank", true, true, true)]
        public GameConfigLibrary<CurrencyBankId, CurrencyBankInfo> CurrencyBanks { get; set; }

#endregion
#region System
        [GameConfigEntry("GameFeatures", true, true, true)]
        public GameConfigLibrary<GameFeatureId, GameFeatureSetting> GameFeatures { get; set; }

        [GameConfigEntry("SharedGlobals", true, true, true)]
        public SharedGlobals SharedGlobals { get; set; }

        [GameConfigEntry("SuppressedWarnings", true, true, true)]
        public GameConfigLibrary<int, SuppressedBuildLogsInfo> SuppressedWarnings { get; set; }

        [GameConfigEntry("AddressablesDownloadProcesses", true, true, true)]
        public GameConfigLibrary<AddressablesDownloadProcessId, AddressablesDownloadProcess> AddressablesDownloadProcesses { get; set; }

        [GameConfigEntry("ReEngagementSettings", true, true, true)]
        public GameConfigLibrary<ReEngagementSettingsId, ReEngagementSettings> ReEngagementSettings { get; set; }

        [GameConfigEntry("FishingSettings", true, true, true)]
        public FishingSettings FishingSettings { get; set; }

        [GameConfigEntry("ScheduledActions", true, true, true)]
        public GameConfigLibrary<ScheduledActionId, ScheduledActionInfo> ScheduledActions { get; set; }

#endregion
#region Dialog
        [GameConfigEntry("StoryDefinitions")]
        public GameConfigLibrary<StoryDefinitionId, StoryElementInfo> StoryElements { get; set; }

        [GameConfigEntry("DialogItems")]
        public GameConfigLibrary<DialogItemId, DialogItemInfo> DialogItems { get; set; }

        [GameConfigEntry("CollectibleDialoguesInfo", true, true, true)]
        public GameConfigLibrary<CollectibleDialoguesInfoId, CollectibleDialoguesInfo> CollectibleDialoguesInfo { get; set; }

        [GameConfigEntry("DialogueCharacters", true, true, true)]
        public GameConfigLibrary<DialogCharacterType, DialogueCharacterInfo> DialogueCharacters { get; set; }

#endregion
#region GarageCleanup
        [GameConfigEntry("GarageCleanupEvents", true, true, true)]
        public GameConfigLibrary<GarageCleanupEventId, GarageCleanupEventInfo> GarageCleanupEvents { get; set; }

        [GameConfigEntry("GarageCleanupBoardRows", true, true, true)]
        public GameConfigLibrary<GarageCleanupBoardRowId, GarageCleanupBoardRowInfo> GarageCleanupBoardRows { get; set; }

        [GameConfigEntry("GarageCleanupPatternSets", true, true, true)]
        public GameConfigLibrary<GarageCleanupPatternSetId, GarageCleanupPatternSetInfo> GarageCleanupPatternSets { get; set; }

        [GameConfigEntry("GarageCleanupPatternRows", true, true, true)]
        public GameConfigLibrary<GarageCleanupPatternRowId, GarageCleanupPatternRowInfo> GarageCleanupPatternRows { get; set; }

        [GameConfigEntry("GarageCleanupRewards", true, true, true)]
        public GameConfigLibrary<GarageCleanupRewardId, GarageCleanupRewardInfo> GarageCleanupRewards { get; set; }

#endregion
#region Decorations
        [GameConfigEntry("Decorations")]
        public GameConfigLibrary<DecorationId, DecorationInfo> Decorations { get; set; }

        [GameConfigEntry("LayeredDecorations", true, true, true)]
        public GameConfigLibrary<LayeredDecorationSetId, LayeredDecorationSetInfo> LayeredDecorations { get; set; }

#endregion
#region Socials
        [GameConfigEntry("SocialAuthentication", true, true, true)]
        public GameConfigLibrary<AuthenticationPlatform, SocialAuthenticationConfig> SocialAuthentication { get; set; }

        [GameConfigEntry("SocialMedia", true, true, true)]
        public GameConfigLibrary<SocialMediaId, SocialMediaInfo> SocialMedia { get; set; }

        [GameConfigEntry("SocialAuthRewards", true, true, true)]
        public GameConfigLibrary<SocialAuthRewardId, SocialAuthRewardInfo> SocialAuthRewards { get; set; }

#endregion
#region Animations
        [GameConfigEntry("Videos", true, true, true)]
        public GameConfigLibrary<VideoId, Video> Videos { get; set; }

        [GameConfigEntry("SlideShows", true, true, true)]
        public GameConfigLibrary<SlideShowId, SlideShow> SlideShows { get; set; }

        [GameConfigEntry("Cutscenes", true, true, true)]
        public GameConfigLibrary<CutsceneId, CutsceneInfo> Cutscenes { get; set; }

#endregion
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

        [GameConfigEntry("ProgressionEventStreaks", true, true, true)]
        public GameConfigLibrary<ProgressionEventStreakId, ProgressionEventStreakRewards> ProgressionEventStreaks { get; set; }

        [GameConfigEntry("Seasons", true, true, true)]
        public GameConfigLibrary<SeasonId, SeasonInfo> Seasons { get; set; }

        [GameConfigEntry("RentableInventorySettings", true, true, true)]
        public GameConfigLibrary<RentableInventorySettingsId, RentableInventorySettings> RentableInventorySettings { get; set; }

        //[GameConfigEntry("Music.Tracks", true, true, true)]
        //public GameConfigLibrary<string, MMTrack> Tracks { get; set; }
        //[GameConfigEntry("Music.Playlists", true, true, true)]
        //public GameConfigLibrary<string, MMPlaylist> Playlists { get; set; }
        [GameConfigEntry("PetInfos", true, true, true)]
        public GameConfigLibrary<PetId, PetInfo> PetInfos { get; set; }

        [GameConfigEntry("DecorationShops", true, true, true)]
        public GameConfigLibrary<DecorationShopId, DecorationShopInfo> DecorationShops { get; set; }

        [GameConfigEntry("DecorationShopSets", true, true, true)]
        public GameConfigLibrary<DecorationShopSetId, DecorationShopSetInfo> DecorationShopSets { get; set; }

        [GameConfigEntry("DecorationShopItems", true, true, true)]
        public GameConfigLibrary<DecorationShopItemId, DecorationShopItemInfo> DecorationShopItems { get; set; }

        [GameConfigEntry("DynamicEventTasks", true, true, true)]
        public GameConfigLibrary<EventTaskId, EventTaskInfo> DynamicEventTasks { get; set; }

        [GameConfigEntry("DynamicEventRewards", true, true, true)]
        public GameConfigLibrary<DynamicEventRewardId, DynamicEventRewardInfo> DynamicEventRewards { get; set; }

        [GameConfigEntry("DynamicEventItems", true, true, true)]
        public GameConfigLibrary<DynamicEventItemId, DynamicEventItemInfo> DynamicEventItems { get; set; }

        [GameConfigEntry("DynamicEventHelpers", true, true, true)]
        public GameConfigLibrary<DynamicEventHelperId, DynamicEventHelperInfo> DynamicEventHelpers { get; set; }

        [GameConfigEntry("EnergyModes", true, true, true)]
        public GameConfigLibrary<PlayerModeId, EnergyModeInfo> EnergyModes { get; set; }

        [GameConfigEntry("EnergyModeProgressionEventItems", true, true, true)]
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

        [GameConfigSyntaxAdapter(new string[] { "LanguageId -> LanguageId #key" }, new string[] { }, false)]
        [GameConfigEntry("Languages", true, null)]
        public GameConfigLibrary<LanguageId, LanguageInfo> Languages { get; set; }

        [GameConfigEntry("InAppProducts", true, true, true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ProductId -> ProductId #key" }, new string[] { })]
        [GameConfigEntryTransform(typeof(InAppProductConfigSource))]
        public GameConfigLibrary<InAppProductId, InAppProductInfo> InAppProducts { get; set; }

        [GameConfigEntry("PlayerSegments", true, true, true, null)]
        [GameConfigEntryTransform(typeof(PlayerSegmentInfoSourceItem))]
        [GameConfigSyntaxAdapter(new string[] { "SegmentId -> SegmentId #key" }, new string[] { })]
        public GameConfigLibrary<PlayerSegmentId, PlayerSegmentInfo> PlayerSegments { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "OfferId -> OfferId #key" }, new string[] { })]
        [GameConfigEntry("Offers", true, true, true, null)]
        [GameConfigEntryTransform(typeof(MergeMansionOfferSourceConfigItem))]
        public GameConfigLibrary<MetaOfferId, MergeMansionOfferInfo> Offers { get; set; }

        [GameConfigEntryTransform(typeof(MergeMansionOfferSourceConfigItem))]
        [GameConfigSyntaxAdapter(new string[] { "OfferId -> OfferId #key" }, new string[] { })]
        [GameConfigEntry("TieredOfferItems", true, true, true, null)]
        public GameConfigLibrary<MetaOfferId, MergeMansionOfferInfo> TieredOfferItems { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." })]
        [GameConfigEntryTransform(typeof(MergeMansionOfferGroupSourceItem))]
        [GameConfigSyntaxAdapter(new string[] { "GroupId -> GroupId #key" }, new string[] { })]
        [GameConfigEntry("OfferGroups", true, true, true, null)]
        public GameConfigLibrary<MetaOfferGroupId, MergeMansionOfferGroupInfo> OfferGroups { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "EventId -> EventId #key" }, new string[] { })]
        [GameConfigEntry("SideBoardEvents", true, true, true, null)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." })]
        [GameConfigEntryTransform(typeof(SideBoardEventSource))]
        public GameConfigLibrary<SideBoardEventId, SideBoardEventInfo> SideBoardEvents { get; set; }

        [GameConfigEntry("EventCharacters", true, true, true, null)]
        [GameConfigEntryTransform(typeof(EventCharacterInfoSource))]
        [GameConfigSyntaxAdapter(new string[] { "EventCharacterId -> EventCharacterId #key" }, new string[] { })]
        public GameConfigLibrary<EventCharacterId, EventCharacterInfo> EventCharacters { get; set; }
        public Dictionary<MergeBoardId, SideBoardEventId> SideBoardEventBoards { get; set; }
        public List<ItemDefinition> FishingRodItems { get; set; }
        public Dictionary<ItemDefinition, OverrideSpawnChanceFeatures> OverrideSpawnChanceByItemDefinition { get; set; }
        public List<HotspotId> AreaUnlockHotspots { get; set; }

        [GameConfigEntry("Music_Tracks", true, true, true, null)]
        [GameConfigEntryTransform(typeof(MMTrackSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        public GameConfigLibrary<string, MMTrack> Tracks { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        [GameConfigEntryTransform(typeof(MMPlaylistSource))]
        [GameConfigEntry("Music_Playlists", true, true, true, null)]
        public GameConfigLibrary<string, MMPlaylist> Playlists { get; set; }

        [GameConfigEntryTransform(typeof(ManuallyActivatedOfferGroupSource))]
        [GameConfigEntry("ManuallyActivatedOfferGroupInfo", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        public GameConfigLibrary<ManuallyActivatedOfferGroupId, ManuallyActivatedOfferGroupInfo> ManuallyActivatedOfferGroupInfos { get; set; }

        [GameConfigEntry("CardStacks", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        public GameConfigLibrary<CardStackId, CardStackInfo> CardStacks { get; set; }

        [GameConfigEntry("WebShopSettings", true, null)]
        public WebShopSettings WebShopSettings { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        [GameConfigEntryTransform(typeof(AdvertisementPlacementsSource))]
        [GameConfigEntry("AdvertisementPlacements", true, null)]
        public GameConfigLibrary<AdvertisementPlacementId, AdvertisementPlacementsInfo> AdvertisementPlacements { get; set; }

        [GameConfigEntry("MysteryMachineEvents", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineEventSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." })]
        public GameConfigLibrary<MysteryMachineEventId, MysteryMachineEventInfo> MysteryMachineEvents { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        [GameConfigEntryTransform(typeof(MysteryMachineItemSetSource))]
        [GameConfigEntry("MysteryMachineItemSets", true, null)]
        public GameConfigLibrary<MysteryMachineItemSetId, MysteryMachineItemSetInfo> MysteryMachineItemSets { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        [GameConfigEntryTransform(typeof(MysteryMachineItemSource))]
        [GameConfigEntry("MysteryMachineItems", true, null)]
        public GameConfigLibrary<MysteryMachineItemId, MysteryMachineItemInfo> MysteryMachineItems { get; set; }

        [GameConfigEntry("MysteryMachineItemScores", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineItemScoreSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        public GameConfigLibrary<MysteryMachineItemScoreId, MysteryMachineItemScore> MysteryMachineItemScores { get; set; }

        [GameConfigEntry("MysteryMachineSpecialItems", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineSpecialItemSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        public GameConfigLibrary<MysteryMachineSpecialItemItemId, MysteryMachineSpecialItemInfo> MysteryMachineSpecialItems { get; set; }

        [GameConfigEntry("MysteryMachineItemChainMultipliers", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineChainMultiplierSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        public GameConfigLibrary<MysteryMachineChainMultiplierId, MysteryMachineChainMultiplierInfo> MysteryMachineChainMultipliers { get; set; }

        [GameConfigEntry("MysteryMachineExtraItemGranting", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        [GameConfigEntryTransform(typeof(MysteryMachineExtraItemGrantingSource))]
        public GameConfigLibrary<MysteryMachineExtraItemGrantingId, MysteryMachineExtraItemGrantingInfo> MysteryMachineExtraItemGranting { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineMultiplierSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        [GameConfigEntry("MysteryMachineMultipliers", true, null)]
        public GameConfigLibrary<MysteryMachineMultiplierId, MysteryMachineMultiplierInfo> MysteryMachineMultipliers { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        [GameConfigEntryTransform(typeof(MysteryMachineSource))]
        [GameConfigEntry("MergeMysteryMachines", true, null)]
        public GameConfigLibrary<MysteryMachineId, MysteryMachineInfo> MysteryMachines { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineCurrencyItemSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        [GameConfigEntry("MergeMysteryMachineCurrencyItems", true, null)]
        public GameConfigLibrary<MysteryMachineCurrencyItemId, MysteryMachineCurrencyItemInfo> MysteryMachineCurrencyItems { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        [GameConfigEntryTransform(typeof(MysteryMachineCurrencyItemChainSource))]
        [GameConfigEntry("MergeMysteryMachineCurrencyItemChains", true, null)]
        public GameConfigLibrary<MysteryMachineCurrencyItemChainId, MysteryMachineCurrencyItemChainInfo> MysteryMachineCurrencyItemChains { get; set; }

        [GameConfigEntry("MergeMysteryMachineProgressionEventProgressItems", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineProgressionEventProgressItemSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        public GameConfigLibrary<MysteryMachineProgressionEventProgressItemId, MysteryMachineProgressionEventProgressItemInfo> MysteryMachineProgressionEventProgressItems { get; set; }

        [GameConfigEntry("MergeMysteryMachineProgressionEventProgressItemChains", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineProgressionEventProgressItemChainSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        public GameConfigLibrary<MysteryMachineProgressionEventProgressItemChainId, MysteryMachineProgressionEventProgressItemChainInfo> MysteryMachineProgressionEventProgressItemChains { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        [GameConfigEntryTransform(typeof(MysteryMachineHeatLevelSource))]
        [GameConfigEntry("MysteryMachineHeatLevels", true, null)]
        public GameConfigLibrary<MysteryMachineHeatLevelId, MysteryMachineHeatLevelInfo> MysteryMachineHeatLevels { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        [GameConfigEntryTransform(typeof(MysteryMachinePerkSource))]
        [GameConfigEntry("MysteryMachinePerks", true, null)]
        public GameConfigLibrary<MysteryMachinePerkId, MysteryMachinePerkInfo> MysteryMachinePerks { get; set; }

        [GameConfigEntry("MysteryMachineSpecialSales", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineSpecialSaleSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        public GameConfigLibrary<MysteryMachineSpecialSaleId, MysteryMachineSpecialSaleInfo> MysteryMachineSpecialSales { get; set; }

        [GameConfigEntryTransform(typeof(MysteryMachineTaskSource))]
        [GameConfigEntry("MysteryMachineTasks", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        public GameConfigLibrary<MysteryMachineTaskId, MysteryMachineTaskInfo> MysteryMachineTasks { get; set; }

        [GameConfigEntry("MysteryMachineTaskSets", true, null)]
        [GameConfigEntryTransform(typeof(MysteryMachineTaskSetSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        public GameConfigLibrary<MysteryMachineTaskSetId, MysteryMachineTaskSetInfo> MysteryMachineTaskSets { get; set; }

        [GameConfigEntry("MysteryMachineLevels", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { })]
        [GameConfigEntryTransform(typeof(MysteryMachineLevelSource))]
        public GameConfigLibrary<MysteryMachineLevelId, MysteryMachineLevelInfo> MysteryMachineLevels { get; set; }
        public Dictionary<MergeBoardId, MysteryMachineEventId> MysteryMachineEventBoards { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(ProducerInventorySlotSource))]
        [GameConfigEntry("ProducerInventorySlots", true, null)]
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
        [GameConfigEntryTransform(typeof(FlashSaleSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ShopItemId, FlashSaleDefinition> GarageFlashSales { get; set; }

        [GameConfigEntry("EventFlashSales", true, null)]
        [GameConfigEntryTransform(typeof(FlashSaleSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<ShopItemId, FlashSaleDefinition> EventFlashSales { get; set; }

        [GameConfigEntry("FlashSaleGroups", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(FlashSalesGroupSource))]
        public GameConfigLibrary<FlashSaleGroupId, FlashSaleGroupDefinition> GarageFlashSaleGroups { get; set; }

        [GameConfigEntry("EventFlashSaleGroups", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntryTransform(typeof(FlashSalesGroupSource))]
        public GameConfigLibrary<FlashSaleGroupId, FlashSaleGroupDefinition> EventFlashSaleGroups { get; set; }

        [GameConfigEntryTransform(typeof(FlashSaleShopSettingsSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("FlashSaleShopSettings", true, null)]
        public GameConfigLibrary<FlashSaleShopSettingsId, FlashSaleShopSettings> FlashSaleShopSettings { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("DailyTasksV2", true, null)]
        [GameConfigEntryTransform(typeof(DailyTaskV2Source))]
        public GameConfigLibrary<DailyTaskV2Id, DailyTaskV2Info> DailyTasksV2 { get; set; }

        [GameConfigEntry("DailyTasksV2CompletionRewards", true, null)]
        [GameConfigEntryTransform(typeof(DailyTasksV2CompletionRewardSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<DailyTasksV2CompletionRewardId, DailyTasksV2CompletionRewardInfo> DailyTasksV2CompletionRewards { get; set; }

        [GameConfigEntry("DailyTasksV2MergeChains", true, null)]
        [GameConfigEntryTransform(typeof(DailyTasksV2MergeChainSource))]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        public GameConfigLibrary<MergeChainId, DailyTasksV2MergeChainInfo> DailyTasksV2MergeChains { get; set; }

        [GameConfigEntry("DailyTasksV2Settings", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> Member" }, new string[] { }, false)]
        public DailyTasksV2Settings DailyTasksV2Settings { get; set; }
        public List<int> MysteryMachineItemIds { get; set; }

        [GameConfigSyntaxAdapter(new string[] { "ConfigKey -> ConfigKey #key" }, new string[] { }, false)]
        [GameConfigEntry("EnergyModeEvents", true, null)]
        [GameConfigSyntaxAdapter(new string[] { "#StartDate -> Schedule.Start.Date", "#StartTime -> Schedule.Start.Time" }, new string[] { "# -> Schedule." }, false)]
        [GameConfigEntryTransform(typeof(EnergyModeEventSource))]
        public GameConfigLibrary<EnergyModeEventId, EnergyModeEventInfo> EnergyModeEvents { get; set; }
    }
}
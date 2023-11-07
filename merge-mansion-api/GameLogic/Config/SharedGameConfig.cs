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

namespace GameLogic.Config
{
    public class SharedGameConfig : SharedGameConfigTemplate<InAppProductInfo, PlayerSegmentInfo, MergeMansionOfferInfo, MergeMansionOfferGroupInfo>
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

        [GameConfigEntry("FlashSales", true, true, true)]
        public GameConfigLibrary<ShopItemId, FlashSaleDefinition> FlashSales { get; set; }

        [GameConfigEntry("FlashSaleGroups", true, true, true)]
        public GameConfigLibrary<FlashSaleGroupId, FlashSaleGroupDefinition> FlashSaleGroups { get; set; }

        [GameConfigEntry("ShopSettings", true, true, true)]
        public ShopSettings ShopSettings { get; set; }

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
                    method?.Invoke(property.GetValue(this), new object[] { this });
                }
            }
        }

        public Dictionary<OfferPlacementId, List<OfferPlacementId>> OfferPlacementIds { get; set; }
        public int MaxPlayerLevel { get; set; }
        public Dictionary<MergeBoardId, CollectibleBoardEventId> CollectibleBoardEventBoards { get; set; }
        public Dictionary<MergeBoardId, LeaderboardEventId> LeaderboardEventBoards { get; set; }
        public Dictionary<DecorationId, DirectorGroupId> DirectorGroupsByDecoration { get; set; }
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
        public HashSet<MergeBoardId> AuxEnergyMergeBoards { get; set; }
        public List<ItemDefinition> FishItems { get; set; }
        public HashSet<int> ItemsAcceptedBySinks { get; set; }
        public Dictionary<int, IReadOnlyList<ValueTuple<ItemDefinition, F32>>> ItemProducingParents { get; set; }
        public Dictionary<HotspotId, IEnumerable<HotspotDefinition>> HotspotOpensAfterCompletion { get; set; }
        public Dictionary<MergeBoardId, EventId> BoardEventBoards { get; set; }
        public List<List<int>> ProducerVariants { get; set; }
    }
}
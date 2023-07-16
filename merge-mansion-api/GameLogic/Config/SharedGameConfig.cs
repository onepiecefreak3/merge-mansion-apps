using System;
using System.Diagnostics;
using System.Reflection;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.GameLogic.Area;
using Metaplay.GameLogic.Codex;
using Metaplay.GameLogic.Config.Map.Characters;
using Metaplay.GameLogic.Decorations;
using Metaplay.GameLogic.Hotspots;
using Metaplay.GameLogic.Merge;
using Metaplay.GameLogic.MergeChains;
using Metaplay.GameLogic.Player.Items;
using Metaplay.GameLogic.Player.Items.Bubble;
using Metaplay.GameLogic.Player.Items.Merging;
using Metaplay.GameLogic.Story;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Player;
using Metaplay.TimedMergeBoards;

namespace Metaplay.GameLogic.Config
{
    public class SharedGameConfig : SharedGameConfigTemplate<InAppProductInfo, PlayerSegmentInfo, MergeMansionOfferInfo, MergeMansionOfferGroupInfo>
    {
        [GameConfigEntry("Items")]
        public GameConfigLibrary<ItemTypeConstant, ItemDefinition> Items { get; set; }
        [GameConfigEntry("MergeChains")]
        public GameConfigLibrary<MergeChainId, MergeChainDefinition> MergeChains { get; set; }
        [GameConfigEntry("CodexDiscoveryRewards")]
        public GameConfigLibrary<CodexDiscoveryRewardId, CodexDiscoveryRewardInfo> CodexDiscoveryRewards { get; set; }
        [GameConfigEntry("CodexCategories")]
        public GameConfigLibrary<CodexCategoryId, CodexCategoryInfo> CodexCategories { get; set; }
        [GameConfigEntry("DynamicPurchaseProducts")]
        public GameConfigLibrary<ShopItemId, DynamicPurchaseDefinition> DynamicPurchaseProducts { get; set; }
        [GameConfigEntry("TimedMergeBoards")]
        public GameConfigLibrary<MergeBoardId, TimedMergeBoard> TimedMergeBoards { get; set; }
        //[GameConfigEntry("SocialAuthentication")]
        //public GameConfigLibrary<AuthenticationPlatform, SocialAuthenticationConfig> SocialAuthentication { get; set; }
        //[GameConfigEntry("GameFeatures")]
        //public GameConfigLibrary<GameFeatureId, GameFeatureSetting> GameFeatures { get; set; }
        [GameConfigEntry("Boards")]
        public GameConfigLibrary<MergeBoardId, BoardInfo> Boards { get; set; }
        [GameConfigEntry("BoardEvents")]
        public GameConfigLibrary<EventId, BoardEventInfo> BoardEvents { get; set; }
        [GameConfigEntry("ShopEvents")]
        public GameConfigLibrary<EventId, ShopEventInfo> ShopEvents { get; set; }
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
        //[GameConfigEntry("PlayerLevels")]
        //public GameConfigLibrary<int, PlayerLevelData> PlayerLevels { get; set; }
        [GameConfigEntry("HotspotDefinitions")]
        public GameConfigLibrary<HotspotId, HotspotDefinition> HotspotDefinitions { get; set; }
        [GameConfigEntry("Decorations")]
        public GameConfigLibrary<DecorationId, DecorationInfo> Decorations { get; set; }
        [GameConfigEntry("StoryDefinitions")]
        public GameConfigLibrary<StoryDefinitionId, StoryElementInfo> StoryElements { get; set; }
        [GameConfigEntry("DialogItems")]
        public GameConfigLibrary<DialogItemId, DialogItemInfo> DialogItems { get; set; }
        [GameConfigEntry("MapCharacterEvents")]
        public GameConfigLibrary<MapCharacterEventId, MapCharacterEventDefinition> MapCharacterEvents { get; set; }
        //[GameConfigEntry("ShopItems")]
        //public GameConfigLibrary<ShopItemId, ShopItemInfo> ShopItems { get; set; }
        //[GameConfigEntry("FlashSales")]
        //public GameConfigLibrary<ShopItemId, FlashSaleDefinition> FlashSales { get; set; }
        //[GameConfigEntry("FlashSaleGroups")]
        //public GameConfigLibrary<FlashSaleGroupId, FlashSaleGroupDefinition> FlashSaleGroups { get; set; }
        //[GameConfigEntry("GarageCleanupEvents")]
        //public GameConfigLibrary<GarageCleanupEventId, GarageCleanupEventInfo> GarageCleanupEvents { get; set; }
        //[GameConfigEntry("GarageCleanupBoardRows")]
        //public GameConfigLibrary<GarageCleanupBoardRowId, GarageCleanupBoardRowInfo> GarageCleanupBoardRows { get; set; }
        //[GameConfigEntry("GarageCleanupPatternSets")]
        //public GameConfigLibrary<GarageCleanupPatternSetId, GarageCleanupPatternSetInfo> GarageCleanupPatternSets { get; set; }
        //[GameConfigEntry("GarageCleanupPatternRows")]
        //public GameConfigLibrary<GarageCleanupPatternRowId, GarageCleanupPatternRowInfo> GarageCleanupPatternRows { get; set; }
        //[GameConfigEntry("GarageCleanupRewards")]
        //public GameConfigLibrary<GarageCleanupRewardId, GarageCleanupRewardInfo> GarageCleanupRewards { get; set; }
        //[GameConfigEntry("SharedGlobals")]
        //public SharedGlobals SharedGlobals { get; set; }
        //[GameConfigEntry("InventorySlots")]
        //public GameConfigLibrary<int, InventorySlotsConfig> InventorySlots { get; set; }
        //[GameConfigEntry("ShopSettings")]
        //public ShopSettings ShopSettings { get; set; }
        //[GameConfigEntry("ShopLayouts")]
        //public GameConfigLibrary<ShopLayoutId, ShopLayout> ShopLayouts { get; set; }
        //[GameConfigEntry("DailyTasks")]
        //public GameConfigLibrary<DailyTaskId, DailyTaskDefinition> DailyTasks { get; set; }
        //[GameConfigEntry("Videos")]
        //public GameConfigLibrary<VideoId, Video> Videos { get; set; }
        //[GameConfigEntry("SlideShows")]
        //public GameConfigLibrary<SlideShowId, SlideShow> SlideShows { get; set; }
        [GameConfigEntry("BubbleSetups")]
        public GameConfigLibrary<BubblesSetupId, BubblesSetup> BubbleSetups { get; set; }
        [GameConfigEntry("Areas")]
        public GameConfigLibrary<AreaId, AreaInfo> Areas { get; set; }
        [GameConfigEntry("ProgressionEvents")]
        public GameConfigLibrary<ProgressionEventId, ProgressionEventInfo> ProgressionEvents { get; set; }
        [GameConfigEntry("ProgressionEventPerks")]
        public GameConfigLibrary<ProgressionEventPerkId, ProgressionEventPerkInfo> ProgressionEventPerks { get; set; }
        //[GameConfigEntry("CurrencyBank")]
        //public GameConfigLibrary<CurrencyBankId, CurrencyBankInfo> CurrencyBanks { get; set; }
        [GameConfigEntry("MergeRewards")]
        public GameConfigLibrary<MergeRewardId, MergeReward> XpMergeRewards { get; set; }
        //[GameConfigEntry("SocialMedia")]
        //public GameConfigLibrary<SocialMediaId, SocialMediaInfo> SocialMedia { get; set; }
        //[GameConfigEntry("SuppressedWarnings")]
        //public GameConfigLibrary<int, SuppressedBuildLogsInfo> SuppressedWarnings { get; set; }
        //[GameConfigEntry("EventOfferSets")]
        //public GameConfigLibrary<EventOfferSetId, EventOfferSetInfo> EventOfferSets { get; set; }
        //[GameConfigEntry("AutoOfferSettings")]
        //public GameConfigLibrary<AutoOfferSettingsId, AutoOfferSettingsInfo> AutoOfferSettings { get; set; }
        //[GameConfigEntry("AddressablesDownloadProcesses")]
        //public GameConfigLibrary<AddressablesDownloadProcessId, AddressablesDownloadProcess> AddressablesDownloadProcesses { get; set; }
        //[GameConfigEntry("CollectibleDialoguesInfo")]
        //public GameConfigLibrary<CollectibleDialoguesInfoId, CollectibleDialoguesInfo> CollectibleDialoguesInfo { get; set; }
        //[GameConfigEntry("LevelUpTutorialConfig")]
        //public GameConfigLibrary<LevelUpTutorialConfigId, LevelUpTutorialConfig> LevelUpTutorialConfig { get; set; }
        //[GameConfigEntry("ScheduledActions")]
        //public GameConfigLibrary<ScheduledActionId, ScheduledActionInfo> ScheduledActions { get; set; }
        [GameConfigEntry("CollectibleBoardEvents")]
        public GameConfigLibrary<CollectibleBoardEventId, CollectibleBoardEventInfo> CollectibleBoardEvents { get; set; }
        [GameConfigEntry("LeaderboardEvents")]
        public GameConfigLibrary<LeaderboardEventId, LeaderboardEventInfo> LeaderboardEvents { get; set; }
        //[GameConfigEntry("DialogueCharacters")]
        //public GameConfigLibrary<DialogCharacterType, DialogueCharacterInfo> DialogueCharacters { get; set; }
        //[GameConfigEntry("SocialAuthRewards")]
        //public GameConfigLibrary<SocialAuthRewardId, SocialAuthRewardInfo> SocialAuthRewards { get; set; }
        //[GameConfigEntry("ReEngagementSettings")]
        //public GameConfigLibrary<ReEngagementSettingsId, ReEngagementSettings> ReEngagementSettings { get; set; }
        //[GameConfigEntry("Cutscenes")]
        //public GameConfigLibrary<CutsceneId, CutsceneInfo> Cutscenes { get; set; }
        //[GameConfigEntry("LayeredDecorations")]
        //public GameConfigLibrary<LayeredDecorationSetId, LayeredDecorationSetInfo> LayeredDecorations { get; set; }

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

                // Invoke ImportBinaryLibrary method
                var importMethod = typeof(GameConfigImporter)
                    .GetMethod(nameof(GameConfigImporter.ImportBinaryLibrary))?
                    .MakeGenericMethod(property.PropertyType.GenericTypeArguments);
                property.SetValue(this, importMethod?.Invoke(importer, new object[] { entryName }));
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
    }
}

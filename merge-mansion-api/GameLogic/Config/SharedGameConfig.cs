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
using Metaplay.Metaplay.Core.InAppPurchase;
using Metaplay.Metaplay.Core.Localization;
using Metaplay.Metaplay.Core.Player;
using Metaplay.TimedMergeBoards;

namespace Metaplay.GameLogic.Config
{
    public class SharedGameConfig : SharedGameConfigTemplate<InAppProductInfo, PlayerSegmentInfo, MergeMansionOfferInfo, MergeMansionOfferGroupInfo>
    {
        // 0x70
        public GameConfigLibrary<ItemType, ItemDefinition> Items { get; set; }
        // 0x78
        public GameConfigLibrary<MergeChainId, MergeChainDefinition> MergeChains { get; set; }
        // 0x80
        public GameConfigLibrary<CodexDiscoveryRewardId, CodexDiscoveryRewardInfo> CodexDiscoveryRewards { get; set; }
        // 0x88
        public GameConfigLibrary<CodexCategoryId, CodexCategoryInfo> CodexCategories { get; set; }
        // 0x90
        public GameConfigLibrary<ShopItemId, DynamicPurchaseDefinition> DynamicPurchaseProducts { get; set; }
        // 0x98
        public GameConfigLibrary<MergeBoardId, TimedMergeBoard> TimedMergeBoards { get; set; }

        public GameConfigLibrary<MergeBoardId, BoardInfo> Boards { get; set; }

        public GameConfigLibrary<EventId, BoardEventInfo> BoardEvents { get; set; }

        public GameConfigLibrary<EventId, ShopEventInfo> ShopEvents { get; set; }

        public GameConfigLibrary<EventCurrencyId, EventCurrencyInfo> EventCurrencies { get; set; }

        public GameConfigLibrary<EventLevelId, EventLevelInfo> EventLevels { get; set; }

        public GameConfigLibrary<EventLevelSetId, EventLevels> LevelSets { get; set; }

        public GameConfigLibrary<EventTaskId, EventTaskInfo> EventTasks { get; set; }

        public GameConfigLibrary<EventOfferId, EventOfferInfo> EventOffers { get; set; }

        public GameConfigLibrary<HotspotId, HotspotDefinition> HotspotDefinitions { get; set; }

        public GameConfigLibrary<DecorationId, DecorationInfo> Decorations { get; set; }

        public GameConfigLibrary<StoryDefinitionId, StoryElementInfo> StoryElements { get; set; }

        public GameConfigLibrary<DialogItemId, DialogItemInfo> DialogItems { get; set; }

        public GameConfigLibrary<MapCharacterEventId, MapCharacterEventDefinition> MapCharacterEvents { get; set; }

        public GameConfigLibrary<BubblesSetupId, BubblesSetup> BubbleSetups { get; set; }

        public GameConfigLibrary<AreaId, AreaInfo> Areas { get; set; }

        public GameConfigLibrary<ProgressionEventId, ProgressionEventInfo> ProgressionEvents { get; set; }

        public GameConfigLibrary<ProgressionEventPerkId, ProgressionEventPerkInfo> ProgressionEventPerks { get; set; }

        public GameConfigLibrary<MergeRewardId, MergeReward> XpMergeRewards { get; set; }

        public GameConfigLibrary<CollectibleBoardEventId, CollectibleBoardEventInfo> CollectibleBoardEvents { get; set; }

        public override void Import(GameConfigImporter importer)
        {
            // Import data
            Languages = importer.ImportBinaryLibrary<LanguageId, LanguageInfo>("Languages.mpc");
            InAppProducts = importer.ImportBinaryLibrary<InAppProductId, InAppProductInfo>("InAppProducts.mpc");
            PlayerSegments = importer.ImportBinaryLibrary<PlayerSegmentId, PlayerSegmentInfo>("PlayerSegments.mpc");

            Items = importer.ImportBinaryLibrary<ItemType, ItemDefinition>("Items.mpc");
            MergeChains = importer.ImportBinaryLibrary<MergeChainId, MergeChainDefinition>("MergeChains.mpc");
            CodexDiscoveryRewards = importer.ImportBinaryLibrary<CodexDiscoveryRewardId, CodexDiscoveryRewardInfo>("CodexDiscoveryRewards.mpc");
            CodexCategories = importer.ImportBinaryLibrary<CodexCategoryId, CodexCategoryInfo>("CodexCategories.mpc");
            DynamicPurchaseProducts = importer.ImportBinaryLibrary<ShopItemId, DynamicPurchaseDefinition>("DynamicPurchaseProducts.mpc");
            TimedMergeBoards = importer.ImportBinaryLibrary<MergeBoardId, TimedMergeBoard>("TimedMergeBoards.mpc");

            Boards = importer.ImportBinaryLibrary<MergeBoardId, BoardInfo>("Boards.mpc");
            BoardEvents = importer.ImportBinaryLibrary<EventId, BoardEventInfo>("BoardEvents.mpc");
            ShopEvents = importer.ImportBinaryLibrary<EventId, ShopEventInfo>("ShopEvents.mpc");
            EventCurrencies = importer.ImportBinaryLibrary<EventCurrencyId, EventCurrencyInfo>("EventCurrencies.mpc");
            EventLevels = importer.ImportBinaryLibrary<EventLevelId, EventLevelInfo>("EventLevels.mpc");
            LevelSets = importer.ImportBinaryLibrary<EventLevelSetId, EventLevels>("EventLevelSets.mpc");
            EventTasks = importer.ImportBinaryLibrary<EventTaskId, EventTaskInfo>("EventTasks.mpc");
            EventOffers = importer.ImportBinaryLibrary<EventOfferId, EventOfferInfo>("EventOffers.mpc");

            HotspotDefinitions = importer.ImportBinaryLibrary<HotspotId, HotspotDefinition>("HotspotDefinitions.mpc");
            Decorations = importer.ImportBinaryLibrary<DecorationId, DecorationInfo>("Decorations.mpc");
            StoryElements = importer.ImportBinaryLibrary<StoryDefinitionId, StoryElementInfo>("StoryDefinitions.mpc");
            DialogItems = importer.ImportBinaryLibrary<DialogItemId, DialogItemInfo>("DialogItems.mpc");
            MapCharacterEvents = importer.ImportBinaryLibrary<MapCharacterEventId, MapCharacterEventDefinition>("MapCharacterEvents.mpc");

            BubbleSetups = importer.ImportBinaryLibrary<BubblesSetupId, BubblesSetup>("BubbleSetups.mpc");
            Areas = importer.ImportBinaryLibrary<AreaId, AreaInfo>("Areas.mpc");
            ProgressionEvents = importer.ImportBinaryLibrary<ProgressionEventId, ProgressionEventInfo>("ProgressionEvents.mpc");
            ProgressionEventPerks = importer.ImportBinaryLibrary<ProgressionEventPerkId, ProgressionEventPerkInfo>("ProgressionEventPerks.mpc");
            XpMergeRewards = importer.ImportBinaryLibrary<MergeRewardId, MergeReward>("MergeRewards.mpc");

            CollectibleBoardEvents = importer.ImportBinaryLibrary<CollectibleBoardEventId, CollectibleBoardEventInfo>("CollectibleBoardEvents.mpc");

            // Resolve refs
            Languages.ResolveMetaRefs(this);
            InAppProducts.ResolveMetaRefs(this);
            PlayerSegments.ResolveMetaRefs(this);

            Items.ResolveMetaRefs(this);
            MergeChains.ResolveMetaRefs(this);
            CodexDiscoveryRewards.ResolveMetaRefs(this);
            CodexCategories.ResolveMetaRefs(this);
            DynamicPurchaseProducts.ResolveMetaRefs(this);
            TimedMergeBoards.ResolveMetaRefs(this);

            Boards.ResolveMetaRefs(this);
            BoardEvents.ResolveMetaRefs(this);
            ShopEvents.ResolveMetaRefs(this);
            EventCurrencies.ResolveMetaRefs(this);
            EventLevels.ResolveMetaRefs(this);
            LevelSets.ResolveMetaRefs(this);
            EventTasks.ResolveMetaRefs(this);
            EventOffers.ResolveMetaRefs(this);

            HotspotDefinitions.ResolveMetaRefs(this);
            Decorations.ResolveMetaRefs(this);
            StoryElements.ResolveMetaRefs(this);
            DialogItems.ResolveMetaRefs(this);
            MapCharacterEvents.ResolveMetaRefs(this);

            BubbleSetups.ResolveMetaRefs(this);
            Areas.ResolveMetaRefs(this);
            ProgressionEvents.ResolveMetaRefs(this);
            ProgressionEventPerks.ResolveMetaRefs(this);
            XpMergeRewards.ResolveMetaRefs(this);

            CollectibleBoardEvents.ResolveMetaRefs(this);
        }
    }
}

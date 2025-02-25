using Code.GameLogic.Config;
using Metaplay.Core.Config;
using Metaplay.Core;
using System;
using System.Collections.Generic;
using GameLogic.Config;
using Metaplay.Core.Schedule;
using Metaplay.Core.Offers;
using GameLogic.ConfigPrefabs;
using GameLogic.Story;
using GameLogic.Decorations;
using Metaplay.Core.Player;

namespace Code.GameLogic.GameEvents
{
    public class BoardEventSource : IConfigItemSource<BoardEventInfo, EventId>, IGameConfigSourceItem<EventId, BoardEventInfo>, IHasGameConfigKey<EventId>
    {
        private MetaDuration ExtensionPurchaseSafetyMargin;
        private EventId EventId { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private MetaDuration? Lifetime { get; set; }
        private MetaDuration? Cooldown { get; set; }
        private bool IsEnabled { get; set; }
        private MetaRef<EventCurrencyInfo> Currency { get; set; }
        private MetaRef<BoardInfo> Board { get; set; }
        private MetaRef<EventTaskInfo> InitialTask { get; set; }
        private List<MetaRef<EventTaskInfo>> Tasks { get; set; }
        private MetaRef<EventLevels> Levels { get; set; }
        private string PortalItem { get; set; }
        private string NameLocalizationId { get; set; }
        private OfferPlacementId BoardShopPlacementId { get; set; }
        private int MaxExtensions { get; set; }
        private MetaDuration ExtensionDuration { get; set; }
        private MetaDuration ExtensionReviewDuration { get; set; }
        private MetaRef<InAppProductInfo> ExtensionInAppProduct { get; set; }
        private bool HasDynamicTasks { get; set; }
        private ConfigPrefabId InfoPopupId { get; set; }
        private ConfigPrefabId TaskProgressionId { get; set; }
        private ConfigPrefabId TaskGoalItemId { get; set; }
        private StoryDefinitionId StartDialogue { get; set; }
        private MetaRef<ShopEventInfo> HintedShopEvent { get; set; }
        private ConfigPrefabId StartPopupId { get; set; }
        private ConfigPrefabId TeasePopupId { get; set; }
        private ConfigPrefabId IntroPopupId { get; set; }
        private ConfigPrefabId ExtendPopupId { get; set; }
        private ConfigPrefabId EndPopupId { get; set; }
        private ConfigPrefabId HudButtonId { get; set; }
        private ConfigPrefabId RewardInfoPopupId { get; set; }
        private bool VisualiseEventPoints { get; set; }
        private ConfigPrefabId TaskItemCheckmarkId { get; set; }
        public List<string> StartActions { get; set; }
        public List<string> EndActions { get; set; }
        private string BoardTransitionSfxOverride { get; set; }
        private string PreviewRequirementType { get; set; }
        private string PreviewRequirementId { get; set; }
        private string PreviewRequirementAmount { get; set; }
        private string PreviewRequirementAux0 { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }
        private DecorationId ActiveDecoration { get; set; }
        private bool GivePortalItemWithoutTask { get; set; }
        private List<string> ExtensionRewardType { get; set; }
        private List<string> ExtensionRewardId { get; set; }
        private List<int> ExtensionRewardAmount { get; set; }
        private List<string> ExtensionRewardAux0 { get; set; }
        private List<string> ExtensionRewardAux1 { get; set; }
        private EventGroupId GroupId { get; set; }
        private string PrefabsId { get; set; }
        public EventId ConfigKey { get; }

        public BoardEventSource()
        {
        }

        private int Priority { get; set; }
        private string ContextCategory { get; set; }
        private string ContextSubCategory { get; set; }
    }
}
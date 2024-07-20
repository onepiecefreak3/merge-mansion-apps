using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Config;
using Metaplay.Core.Schedule;
using GameLogic.Story;
using Metaplay.Core.Offers;
using GameLogic.Decorations;

namespace Code.GameLogic.GameEvents
{
    public class SideBoardEventSource : IConfigItemSource<SideBoardEventInfo, SideBoardEventId>, IGameConfigSourceItem<SideBoardEventId, SideBoardEventInfo>, IHasGameConfigKey<SideBoardEventId>
    {
        private SideBoardEventId EventId { get; set; }
        private string NameLocId { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private bool IsEnabled { get; set; }
        private MetaRef<EventCurrencyInfo> Currency { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private MetaDuration? ShowTimeInCalendarPopupAfterFinish { get; set; }
        private MetaRef<BoardInfo> Board { get; set; }
        private string PortalItem { get; set; }
        private List<MetaRef<EventLevelInfo>> Levels { get; set; }
        private string FallbackLevels { get; set; }
        private StoryDefinitionId EnterBoardDialogue { get; set; }
        private OfferPlacementId BoardShopPlacementId { get; set; }
        private DecorationId ActiveDecoration { get; set; }
        private List<int> ProgressionPopupHeaderImageLevels { get; set; }
        private string EventInitTask { get; set; }
        private string EventTasks { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }
        private int MaxExtensions { get; set; }
        private MetaDuration ExtensionDuration { get; set; }
        private MetaDuration ExtensionReviewDuration { get; set; }
        private int LimitResourceItem { get; set; }
        private string ResourceItem { get; set; }
        private string ResourceItemCollectable { get; set; }
        private string ResourceItemSpawner { get; set; }
        private string EmptySinkResourceItem { get; set; }
        private string ItemsDisplayingResourceItemCountOnBoard { get; set; }
        private string ItemsDisplayingResourceItemCountOnItemInfoArea { get; set; }
        private string IsResourceItemAtMaxItemInfoAreaLocId { get; set; }
        private string IsResourceItemAtMaxItemInfoAreaPortalLocId { get; set; }
        private string EndPopupOptions { get; set; }
        public SideBoardEventId ConfigKey { get; }

        public SideBoardEventSource()
        {
        }

        private EventGroupId GroupId { get; set; }
    }
}
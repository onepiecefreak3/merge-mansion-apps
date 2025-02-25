using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Config;
using Metaplay.Core.Schedule;

namespace Code.GameLogic.GameEvents.CardCollectionSupportingEvent
{
    public class CardCollectionSupportingEventSource : IConfigItemSource<CardCollectionSupportingEventInfo, CardCollectionSupportingEventId>, IGameConfigSourceItem<CardCollectionSupportingEventId, CardCollectionSupportingEventInfo>, IHasGameConfigKey<CardCollectionSupportingEventId>
    {
        public CardCollectionSupportingEventId ConfigKey { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private bool IsEnabled { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private MetaDuration? Lifetime { get; set; }
        private string NameLocId { get; set; }
        private EventGroupId GroupId { get; set; }
        private int Priority { get; set; }
        private bool UpgradeUnclaimedPacks { get; set; }
        private bool ShowEndPopup { get; set; }
        private List<string> EventWhiteList { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }

        public CardCollectionSupportingEventSource()
        {
        }
    }
}
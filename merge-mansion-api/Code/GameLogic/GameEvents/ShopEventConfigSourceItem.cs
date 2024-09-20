using Code.GameLogic.Config;
using Metaplay.Core.Config;
using Metaplay.Core;
using System;
using System.Collections.Generic;
using GameLogic.Config;
using Metaplay.Core.Schedule;
using GameLogic.ConfigPrefabs;
using Metaplay.Core.Player;

namespace Code.GameLogic.GameEvents
{
    public class ShopEventConfigSourceItem : IConfigItemSource<ShopEventInfo, EventId>, IGameConfigSourceItem<EventId, ShopEventInfo>, IHasGameConfigKey<EventId>
    {
        private MetaDuration ExtensionPurchaseSafetyMargin;
        private EventId ShopEventId { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private List<MetaRef<EventOfferInfo>> Offers { get; set; }
        private MetaRef<EventLevels> Levels { get; set; }
        private MetaRef<EventCurrencyInfo> Currency { get; set; }
        private bool IsEnabled { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private MetaDuration? Lifetime { get; set; }
        private MetaDuration? Cooldown { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private List<MetaRef<BoardEventInfo>> HintedBoardEventInfos { get; set; }
        private int MaxExtensions { get; set; }
        private MetaDuration ExtensionDuration { get; set; }
        private MetaDuration ExtensionReviewDuration { get; set; }
        private MetaRef<InAppProductInfo> ExtensionInAppProduct { get; set; }
        private ConfigPrefabId EndPopupId { get; set; }
        private ConfigPrefabId ShopPopupId { get; set; }
        private ConfigPrefabId HudButtonId { get; set; }
        private List<MetaRef<EventOfferSetInfo>> OfferSets { get; set; }
        private string PreviewRequirementType { get; set; }
        private string PreviewRequirementId { get; set; }
        private string PreviewRequirementAmount { get; set; }
        private string PreviewRequirementAux0 { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }
        private EventGroupId GroupId { get; set; }
        private string PrefabsId { get; set; }
        public EventId ConfigKey { get; }

        public ShopEventConfigSourceItem()
        {
        }
    }
}
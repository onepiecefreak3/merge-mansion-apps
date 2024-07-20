using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Config;

namespace Code.GameLogic.GameEvents
{
    public class EventShopOfferSourceConfigItem : IConfigItemSource<EventOfferInfo, EventOfferId>, IGameConfigSourceItem<EventOfferId, EventOfferInfo>, IHasGameConfigKey<EventOfferId>
    {
        private EventOfferId EventOfferId { get; set; }
        private EventId ShopEventId { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private string CostType { get; set; }
        private string CostId { get; set; }
        private int CostAmount { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        private bool IsEnabled { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private int? MaxPurchases { get; set; }
        private int? MaxPurchasesPerActivation { get; set; }
        private int? MaxActivations { get; set; }
        private List<EventOfferId> PrecursorId { get; set; }
        private List<bool> PrecursorConsumed { get; set; }
        private List<MetaDuration> PrecursorDelay { get; set; }
        public EventOfferId ConfigKey { get; }

        public EventShopOfferSourceConfigItem()
        {
        }
    }
}
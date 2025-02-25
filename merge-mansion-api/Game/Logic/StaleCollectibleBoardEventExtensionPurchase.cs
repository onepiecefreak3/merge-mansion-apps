using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using System;

namespace Game.Logic
{
    [AnalyticsEventKeywords(new string[] { "event", "buysell" })]
    [AnalyticsEvent(21, "Collectible board event extended while being stale", 1, null, true, false, false)]
    public class StaleCollectibleBoardEventExtensionPurchase : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CollectibleBoardEventId EventId { get; set; }
        public override string EventDescription { get; }

        private StaleCollectibleBoardEventExtensionPurchase()
        {
        }

        public StaleCollectibleBoardEventExtensionPurchase(CollectibleBoardEventId eventId)
        {
        }
    }
}
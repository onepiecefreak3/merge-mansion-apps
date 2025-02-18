using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using System;

namespace Game.Logic
{
    [AnalyticsEvent(21, "Collectible board event extended while being stale", 1, null, true, false, false)]
    [AnalyticsEventKeywords(new string[] { "event", "buysell" })]
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
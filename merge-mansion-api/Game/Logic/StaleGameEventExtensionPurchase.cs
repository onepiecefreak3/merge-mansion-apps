using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using System;

namespace Game.Logic
{
    [AnalyticsEvent(9, "Game event extended while being stale", 1, null, true, false, false)]
    [AnalyticsEventKeywords(new string[] { "event", "buysell" })]
    public class StaleGameEventExtensionPurchase : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EventId EventId { get; set; }
        public override string EventDescription { get; }

        private StaleGameEventExtensionPurchase()
        {
        }

        public StaleGameEventExtensionPurchase(EventId eventId)
        {
        }
    }
}
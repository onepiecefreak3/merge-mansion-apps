using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using System;

namespace Game.Logic
{
    [AnalyticsEvent(19, "Progression event premium IAP consumed while being stale", 1, null, true, false, false)]
    public class StaleProgressionEventPremiumIAPPurchase : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ProgressionEventId EventId { get; set; }
        public override string EventDescription { get; }

        private StaleProgressionEventPremiumIAPPurchase()
        {
        }

        public StaleProgressionEventPremiumIAPPurchase(ProgressionEventId eventId)
        {
        }
    }
}
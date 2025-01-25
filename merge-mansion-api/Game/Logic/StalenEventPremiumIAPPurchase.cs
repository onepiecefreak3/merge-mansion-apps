using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using System;

namespace Game.Logic
{
    [AnalyticsEvent(29, "Progression event premium IAP consumed while being stale", 1, null, true, false, false)]
    public class StalenEventPremiumIAPPurchase : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string EventId { get; set; }
        public override string EventDescription { get; }

        private StalenEventPremiumIAPPurchase()
        {
        }

        public StalenEventPremiumIAPPurchase(string eventId)
        {
        }
    }
}
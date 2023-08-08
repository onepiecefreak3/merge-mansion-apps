using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using System;

namespace Game.Logic
{
    [AnalyticsEvent(4, "Support removed currency", 1, null, true, false, false)]
    public class PlayerEventSupportReducedCurrency : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Currencies Currency;
        [MetaMember(2, (MetaMemberFlags)0)]
        public long Amount;
        [MetaMember(3, (MetaMemberFlags)0)]
        public long TotalAfterRemove;
        public override string EventDescription { get; }

        public PlayerEventSupportReducedCurrency()
        {
        }

        public PlayerEventSupportReducedCurrency(Currencies currency, long amount, long totalAfterRemove)
        {
        }
    }
}
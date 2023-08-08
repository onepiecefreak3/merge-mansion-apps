using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System;
using GameLogic.Player;

namespace Game.Logic
{
    [AnalyticsEvent(15, "Gained coins", 1, null, true, false, false)]
    public class PlayerEventGainedCoins : PlayerEventGainedCurrency
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        [MetaOnMemberDeserializationFailure("FixItemType")]
        public string itemType;
        public override string EventDescription { get; }

        public PlayerEventGainedCoins()
        {
        }

        public PlayerEventGainedCoins(long amount, CurrencySource currencySource, long total, string itemType, AnalyticsContext context)
        {
        }
    }
}
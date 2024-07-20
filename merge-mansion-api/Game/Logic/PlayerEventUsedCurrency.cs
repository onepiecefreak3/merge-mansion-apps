using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using System;
using GameLogic;

namespace Game.Logic
{
    [AnalyticsEvent(1, "Currency used", 1, null, true, false, false)]
    public class PlayerEventUsedCurrency : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Currencies Currency;
        [MetaMember(2, (MetaMemberFlags)0)]
        public long Amount;
        [MetaMember(3, (MetaMemberFlags)0)]
        public CurrencySink CurrencySink;
        [MetaMember(4, (MetaMemberFlags)0)]
        [MetaOnMemberDeserializationFailure("FixItemType")]
        public string SpendOnItemType;
        [MetaMember(5, (MetaMemberFlags)0)]
        public long TotalAfterUse;
        public override string EventDescription { get; }

        public PlayerEventUsedCurrency()
        {
        }

        public PlayerEventUsedCurrency(Currencies currency, long amount, CurrencySink currencySink, string spendOnItemType, long totalAfterUse)
        {
        }
    }
}
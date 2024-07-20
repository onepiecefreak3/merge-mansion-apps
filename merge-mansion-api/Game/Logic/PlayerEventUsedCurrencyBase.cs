using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;
using GameLogic.Player;
using GameLogic;

namespace Game.Logic
{
    [MetaSerializable]
    public abstract class PlayerEventUsedCurrencyBase : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public long Amount;
        [MetaMember(2, (MetaMemberFlags)0)]
        public CurrencySink CurrencySink;
        [MetaOnMemberDeserializationFailure("FixItemType")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public string SpendOnItemType;
        [MetaMember(4, (MetaMemberFlags)0)]
        public long TotalAfterUse;
        [MetaMember(5, (MetaMemberFlags)0)]
        public AnalyticsContext AnalyticsContext;
        public abstract Currencies Currency { get; }
        public override string EventDescription { get; }

        public PlayerEventUsedCurrencyBase()
        {
        }

        public PlayerEventUsedCurrencyBase(long amount, CurrencySink currencySink, string spendOnItemType, long totalAfterUse, AnalyticsContext analyticsContext)
        {
        }
    }
}
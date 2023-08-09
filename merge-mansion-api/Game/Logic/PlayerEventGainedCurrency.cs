using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;
using GameLogic.Player;
using GameLogic;

namespace Game.Logic
{
    [MetaSerializable]
    public abstract class PlayerEventGainedCurrency : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public long Amount;
        [MetaMember(2, (MetaMemberFlags)0)]
        public CurrencySource CurrencySource;
        [MetaMember(3, (MetaMemberFlags)0)]
        public long TotalAfterAdd;
        [MetaMember(4, (MetaMemberFlags)0)]
        public AnalyticsContext AnalyticsContext;
        public PlayerEventGainedCurrency()
        {
        }

        public PlayerEventGainedCurrency(long amount, CurrencySource currencySource, long total, AnalyticsContext context)
        {
        }
    }
}
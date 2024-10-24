using Metaplay.Core.Model;
using GameLogic.Player;
using System;

namespace Code.Analytics
{
    [MetaSerializableDerived(7)]
    public class AdsProducerCooldownAnalyticsContext : AnalyticsContext
    {
        [MetaMember(10, (MetaMemberFlags)0)]
        public string TimeSkippedAmount { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public int DiamondValue { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public string TimeRemaining { get; set; }

        public AdsProducerCooldownAnalyticsContext()
        {
        }

        public AdsProducerCooldownAnalyticsContext(string context, string target, string timeSkippedAmount, int diamondValue, string timeRemaining)
        {
        }
    }
}
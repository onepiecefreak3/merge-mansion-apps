using Metaplay.Core.Model;
using System;

namespace GameLogic.Player
{
    [MetaSerializableDerived(5)]
    [MetaReservedMembers(10, 19)]
    public class WeightStarRewardAnalyticsContext : AnalyticsContext
    {
        [MetaMember(10, (MetaMemberFlags)0)]
        public string ItemType { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public int StarIndex { get; set; }

        private WeightStarRewardAnalyticsContext()
        {
        }

        public WeightStarRewardAnalyticsContext(string context, string target, string itemType, int starIndex)
        {
        }
    }
}
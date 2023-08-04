using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(18)]
    public class DaysSinceLastLoginRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int? Min { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private int? Max { get; set; }

        public DaysSinceLastLoginRequirement()
        {
        }

        public DaysSinceLastLoginRequirement(int? min, int? max)
        {
        }
    }
}
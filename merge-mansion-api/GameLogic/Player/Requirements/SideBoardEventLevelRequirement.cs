using Metaplay.Core.Model;
using System;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(30)]
    public class SideBoardEventLevelRequirement : PlayerRequirement
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public int? Min;
        [MetaMember(3, (MetaMemberFlags)0)]
        public int? Max;
        [MetaMember(1, (MetaMemberFlags)0)]
        private SideBoardEventId SideBoardEventId { get; set; }

        public SideBoardEventLevelRequirement()
        {
        }

        public SideBoardEventLevelRequirement(SideBoardEventId sideBoardEventId, int? min, int? max)
        {
        }
    }
}
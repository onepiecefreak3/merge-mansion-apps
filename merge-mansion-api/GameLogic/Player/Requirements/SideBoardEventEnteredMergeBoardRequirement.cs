using Metaplay.Core.Model;
using System.Collections.Generic;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(31)]
    public class SideBoardEventEnteredMergeBoardRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<SideBoardEventId> EventIds { get; set; }

        public SideBoardEventEnteredMergeBoardRequirement()
        {
        }

        public SideBoardEventEnteredMergeBoardRequirement(IEnumerable<SideBoardEventId> eventIds)
        {
        }
    }
}
using Metaplay.Core.Model;
using System.Collections.Generic;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(29)]
    public class SideBoardEventPortalItemGivenRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<SideBoardEventId> EventIds { get; set; }

        public SideBoardEventPortalItemGivenRequirement()
        {
        }

        public SideBoardEventPortalItemGivenRequirement(IEnumerable<SideBoardEventId> eventIds)
        {
        }
    }
}
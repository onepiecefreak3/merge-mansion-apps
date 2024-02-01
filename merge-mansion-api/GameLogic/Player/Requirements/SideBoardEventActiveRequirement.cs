using Metaplay.Core.Model;
using System.Collections.Generic;
using Code.GameLogic.GameEvents;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(28)]
    public class SideBoardEventActiveRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<SideBoardEventId> EventIds { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool Active { get; set; }

        public SideBoardEventActiveRequirement()
        {
        }

        public SideBoardEventActiveRequirement(IEnumerable<SideBoardEventId> eventIds, bool active)
        {
        }
    }
}
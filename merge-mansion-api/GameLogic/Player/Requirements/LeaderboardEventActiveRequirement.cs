using Metaplay.Core.Model;
using System.Collections.Generic;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(19)]
    public class LeaderboardEventActiveRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private List<LeaderboardEventId> EventIds { get; set; }

        public LeaderboardEventActiveRequirement()
        {
        }

        public LeaderboardEventActiveRequirement(IEnumerable<LeaderboardEventId> eventIds)
        {
        }
    }
}
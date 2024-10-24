using Metaplay.Core.Model;
using System.Collections.Generic;
using Code.GameLogic.GameEvents;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(52)]
    public class BoultonLeagueEventActiveRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private List<BoultonLeagueEventId> EventIds { get; set; }

        private BoultonLeagueEventActiveRequirement()
        {
        }

        public BoultonLeagueEventActiveRequirement(IEnumerable<BoultonLeagueEventId> eventIds)
        {
        }
    }
}
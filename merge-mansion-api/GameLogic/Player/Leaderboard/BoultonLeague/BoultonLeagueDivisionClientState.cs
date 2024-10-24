using Metaplay.Core.Model;
using Metaplay.Core.League;
using System;

namespace GameLogic.Player.Leaderboard.BoultonLeague
{
    [MetaSerializableDerived(2)]
    public class BoultonLeagueDivisionClientState : DivisionClientStateBase<BoultonLeagueDivisionHistoryEntry>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsBannedFromParticipating { get; set; }

        public BoultonLeagueDivisionClientState()
        {
        }
    }
}
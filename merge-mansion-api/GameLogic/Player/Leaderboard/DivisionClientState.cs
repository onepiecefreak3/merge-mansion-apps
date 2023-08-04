using Metaplay.Core.Model;
using Metaplay.Core.League;
using System;

namespace GameLogic.Player.Leaderboard
{
    [MetaSerializableDerived(1)]
    public class DivisionClientState : DivisionClientStateBase<PlayerDivisionHistoryEntry>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsBannedFromParticipating { get; set; }

        public DivisionClientState()
        {
        }
    }
}
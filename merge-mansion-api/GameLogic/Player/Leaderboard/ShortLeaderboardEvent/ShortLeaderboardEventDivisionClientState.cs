using Metaplay.Core.Model;
using Metaplay.Core.League;
using System;

namespace GameLogic.Player.Leaderboard.ShortLeaderboardEvent
{
    [MetaSerializableDerived(3)]
    public class ShortLeaderboardEventDivisionClientState : DivisionClientStateBase<ShortLeaderboardDivisionHistoryEntry>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsBannedFromParticipating { get; set; }

        public ShortLeaderboardEventDivisionClientState()
        {
        }
    }
}
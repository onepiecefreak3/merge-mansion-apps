using Metaplay.Core.Model;
using Metaplay.Core.League.Player;
using Metaplay.Core.League;
using System;

namespace GameLogic.Player.Leaderboard.ShortLeaderboardEvent
{
    [MetaSerializableDerived(3)]
    public class ShortLeaderboardEventDivisionParticipantState : PlayerDivisionParticipantStateBase<PlayerDivisionScore, PlayerDivisionScore, ShortLeaderboardEventDivisionAvatar>, IMetacoreLeagueParticipantState, IPlayerDivisionParticipantState, IDivisionParticipantState
    {
        public override string ParticipantInfo { get; }

        public ShortLeaderboardEventDivisionParticipantState()
        {
        }
    }
}
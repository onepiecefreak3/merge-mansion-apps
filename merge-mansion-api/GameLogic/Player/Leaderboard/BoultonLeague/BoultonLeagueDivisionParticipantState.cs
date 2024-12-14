using Metaplay.Core.Model;
using Metaplay.Core.League.Player;
using System;
using Metaplay.Core.League;

namespace GameLogic.Player.Leaderboard.BoultonLeague
{
    [MetaSerializableDerived(2)]
    public class BoultonLeagueDivisionParticipantState : PlayerDivisionParticipantStateBase<PlayerDivisionScore, PlayerDivisionScore, BoultonLeagueDivisionAvatar>, IMetacoreLeagueParticipantState, IPlayerDivisionParticipantState, IDivisionParticipantState
    {
        public override string ParticipantInfo { get; }

        public BoultonLeagueDivisionParticipantState()
        {
        }
    }
}
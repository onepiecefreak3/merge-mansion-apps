using Metaplay.Core.Model;
using Metaplay.Core.League.Player;
using System;

namespace GameLogic.Player.Leaderboard.BoultonLeague
{
    [MetaSerializableDerived(2)]
    public class BoultonLeagueDivisionParticipantState : PlayerDivisionParticipantStateBase<PlayerDivisionScore, PlayerDivisionScore, BoultonLeagueDivisionAvatar>
    {
        public override string ParticipantInfo { get; }

        public BoultonLeagueDivisionParticipantState()
        {
        }
    }
}
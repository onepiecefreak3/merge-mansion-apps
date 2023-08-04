using Metaplay.Core.Model;
using Metaplay.Core.League.Player;

namespace GameLogic.Player.Leaderboard
{
    [MetaSerializableDerived(1)]
    public class PlayerDivisionParticipantState : PlayerDivisionParticipantStateBase<PlayerDivisionScore, PlayerDivisionScore, PlayerDivisionAvatar>
    {
        public PlayerDivisionParticipantState()
        {
        }
    }
}
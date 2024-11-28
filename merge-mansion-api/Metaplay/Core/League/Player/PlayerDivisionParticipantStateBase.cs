using Metaplay.Core.Model;

namespace Metaplay.Core.League.Player
{
    [MetaReservedMembers(200, 300)]
    public abstract class PlayerDivisionParticipantStateBase<TDivisionScore, TDivisionContribution, TDivisionPlayerAvatar> : DivisionParticipantStateBase<TDivisionScore>, IPlayerDivisionParticipantState, IDivisionParticipantState
    {
        public PlayerDivisionAvatarBase PlayerAvatar { get; set; }
        public IDivisionContribution PlayerContribution { get; set; }

        PlayerDivisionAvatarBase Metaplay.Core.League.Player.IPlayerDivisionParticipantState.PlayerAvatar { get; set; }

        IDivisionContribution Metaplay.Core.League.Player.IPlayerDivisionParticipantState.PlayerContribution { get; set; }

        protected PlayerDivisionParticipantStateBase()
        {
        }
    }
}
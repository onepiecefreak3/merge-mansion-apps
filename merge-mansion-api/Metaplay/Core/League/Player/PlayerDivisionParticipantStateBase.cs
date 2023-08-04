using Metaplay.Core.Model;

namespace Metaplay.Core.League.Player
{
    [MetaReservedMembers(200, 300)]
    public abstract class PlayerDivisionParticipantStateBase<TDivisionScore, TDivisionContribution, TDivisionPlayerAvatar> : DivisionParticipantStateBase<TDivisionScore>, IPlayerDivisionParticipantState, IDivisionParticipantState
    {
        [MetaMember(201, (MetaMemberFlags)0)]
        public TDivisionPlayerAvatar PlayerAvatar { get; set; }

        [MetaMember(202, (MetaMemberFlags)0)]
        public TDivisionContribution PlayerContribution { get; set; }

        PlayerDivisionAvatarBase Metaplay.Core.League.Player.IPlayerDivisionParticipantState.PlayerAvatar { get; set; }

        IDivisionContribution Metaplay.Core.League.Player.IPlayerDivisionParticipantState.PlayerContribution { get; set; }

        EntityId Metaplay.Core.League.Player.IPlayerDivisionParticipantState.PlayerId { get; }

        protected PlayerDivisionParticipantStateBase()
        {
        }
    }
}
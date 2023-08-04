using Metaplay.Core.Model;
using Metaplay.Core.League.Player;

namespace Metaplay.Core.League
{
    [MetaReservedMembers(100, 200)]
    public abstract class PlayerDivisionParticipantConclusionResultBase<TAvatar> : IPlayerDivisionParticipantConclusionResult, IDivisionParticipantConclusionResult
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public EntityId ParticipantId { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public TAvatar Avatar { get; set; }

        PlayerDivisionAvatarBase Metaplay.Core.League.IPlayerDivisionParticipantConclusionResult.Avatar { get; }

        protected PlayerDivisionParticipantConclusionResultBase(EntityId participantId, TAvatar avatar)
        {
        }
    }
}
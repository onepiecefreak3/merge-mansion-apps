using Metaplay.Core.League.Player;

namespace Metaplay.Core.League
{
    public interface IPlayerDivisionParticipantConclusionResult : IDivisionParticipantConclusionResult
    {
        PlayerDivisionAvatarBase Avatar { get; }
    }
}
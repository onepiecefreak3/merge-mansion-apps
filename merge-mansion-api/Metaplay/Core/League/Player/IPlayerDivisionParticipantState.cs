using Metaplay.Core.Model;

namespace Metaplay.Core.League.Player
{
    [PlayerLeaguesEnabledCondition]
    [MetaSerializable]
    public interface IPlayerDivisionParticipantState : IDivisionParticipantState
    {
        PlayerDivisionAvatarBase PlayerAvatar { get; set; }

        IDivisionContribution PlayerContribution { get; set; }
    }
}
using Metaplay.Core.Model;

namespace Metaplay.Core.League.Player
{
    [MetaSerializable]
    [PlayerLeaguesEnabledCondition]
    public interface IPlayerDivisionParticipantState : IDivisionParticipantState
    {
        PlayerDivisionAvatarBase PlayerAvatar { get; set; }

        IDivisionContribution PlayerContribution { get; set; }
    }
}
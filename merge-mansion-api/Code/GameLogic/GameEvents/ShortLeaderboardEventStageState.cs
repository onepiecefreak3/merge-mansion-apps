using Metaplay.Core.Model;
using GameLogic;

namespace Code.GameLogic.GameEvents
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum ShortLeaderboardEventStageState
    {
        Joining = 0,
        JoinFailed = 1,
        WaitingForOtherPlayers = 2,
        Started = 3,
        Ended = 4
    }
}
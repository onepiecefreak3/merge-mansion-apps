using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public enum LeaderboardEventScoreChangeSourceAction
    {
        Spawn = 0,
        Merge = 1,
        Collect = 2,
        Debug = 3,
        MoveFromPocketToBoard = 4,
        Chest = 5,
        Reward = 6
    }
}
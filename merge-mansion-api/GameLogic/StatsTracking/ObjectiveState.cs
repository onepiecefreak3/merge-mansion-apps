using Metaplay.Core.Model;

namespace GameLogic.StatsTracking
{
    [MetaSerializable]
    public enum ObjectiveState
    {
        Locked = 0,
        Incomplete = 1,
        Complete = 2
    }
}
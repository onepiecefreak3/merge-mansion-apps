using Metaplay.Core.Model;

namespace GameLogic.Hotspots
{
    [MetaSerializable]
    public enum HotspotType
    {
        Undefined = 0,
        MergeGoal = 1,
        MergeGrid = 2,
        UnlockArea = 3,
        EndOfContent = 4,
        Event = 5,
        RepeatableTask = 6,
        OpenUIElement = 7
    }
}
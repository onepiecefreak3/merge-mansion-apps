using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public enum PlayerDeletionStatus
    {
        None = 0,
        Deleted = 2,
        ScheduledByAdmin = 1,
        ScheduledByUser = 5,
        ScheduledBySystem = 9
    }
}
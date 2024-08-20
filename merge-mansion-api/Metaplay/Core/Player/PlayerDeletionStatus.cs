using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public enum PlayerDeletionStatus
    {
        None = 0,
        ScheduledByAdmin = 1,
        ScheduledByUser = 5,
        ScheduledBySystem = 9,
        DeletedByUnknownLegacy = 2,
        DeletedByAdmin = 6,
        DeletedByUser = 14,
        DeletedBySystem = 22,
        ScheduledByUnknown = 25,
        DeletedByUnknown = 30
    }
}
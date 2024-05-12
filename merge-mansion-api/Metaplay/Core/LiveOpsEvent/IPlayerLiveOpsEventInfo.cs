namespace Metaplay.Core.LiveOpsEvent
{
    public interface IPlayerLiveOpsEventInfo
    {
        MetaGuid Id { get; }

        LiveOpsEventScheduleOccasion ScheduleMaybe { get; }

        LiveOpsEventContent Content { get; }

        LiveOpsEventPhase Phase { get; }
    }
}
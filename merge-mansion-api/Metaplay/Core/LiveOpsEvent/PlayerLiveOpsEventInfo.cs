namespace Metaplay.Core.LiveOpsEvent
{
    public class PlayerLiveOpsEventInfo
    {
        public MetaGuid Id { get; }
        public LiveOpsEventScheduleInfo ScheduleMaybe { get; }
        public LiveOpsEventContent Content { get; }
        public LiveOpsEventPhase Phase { get; }

        public PlayerLiveOpsEventInfo(MetaGuid id, LiveOpsEventScheduleInfo scheduleMaybe, LiveOpsEventContent content, LiveOpsEventPhase phase)
        {
        }
    }
}
namespace Metaplay.Metaplay.Core.Message
{
	[MetaMessage(15, MessageDirection.ServerToClient, false)]
    public class UpdateScheduledMaintenanceMode : MetaMessage
    {
        public ScheduledMaintenanceMode ScheduledMaintenanceMode { get; set; } // 0x10

        private UpdateScheduledMaintenanceMode() { }

        public UpdateScheduledMaintenanceMode(ScheduledMaintenanceMode scheduledMaintenanceMode)
        {
            ScheduledMaintenanceMode = scheduledMaintenanceMode;
        }
    }
}

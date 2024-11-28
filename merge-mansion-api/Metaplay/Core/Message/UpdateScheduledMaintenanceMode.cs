namespace Metaplay.Core.Message
{
	[MetaMessage(15, MessageDirection.ServerToClient, false)]
    public class UpdateScheduledMaintenanceMode : MetaMessage
    {
        public ScheduledMaintenanceModeForClient ScheduledMaintenanceMode { get; set; } // 0x10

        private UpdateScheduledMaintenanceMode() { }

        public UpdateScheduledMaintenanceMode(ScheduledMaintenanceModeForClient scheduledMaintenanceMode)
        {
            ScheduledMaintenanceMode = scheduledMaintenanceMode;
        }
    }
}

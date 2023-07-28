using Metaplay.Core;

namespace Metaplay.Unity
{
    public readonly struct MaintenanceModeState
    {
        public readonly ScheduleStatus Status; // 0x0
        public readonly MetaTime MaintenanceStartAt; // 0x8
        public readonly MetaTime? EstimatedMaintenanceOverAt; // 0x10

        private MaintenanceModeState(ScheduleStatus status, MetaTime maintenanceStartAt, MetaTime? estimatedMaintenanceOverAt)
        {
            Status = status;
            MaintenanceStartAt = maintenanceStartAt;
            EstimatedMaintenanceOverAt = estimatedMaintenanceOverAt;
        }

        public static MaintenanceModeState CreateOngoing(MetaTime maintenanceStartAt, MetaTime? estimatedMaintenanceOverAt)
        {
            var now = MetaTime.Now;
            if (maintenanceStartAt <= now)
                return new MaintenanceModeState(ScheduleStatus.Ongoing, maintenanceStartAt, estimatedMaintenanceOverAt);

            return new MaintenanceModeState(ScheduleStatus.Ongoing, now, estimatedMaintenanceOverAt);
        }

        public static MaintenanceModeState CreateNotScheduled()
        {
            return new MaintenanceModeState(ScheduleStatus.NotScheduled, MetaTime.Epoch, null);
        }

        public static MaintenanceModeState CreateUpcoming(MetaTime maintenanceStartAt, MetaTime? estimatedMaintenanceOverAt)
        {
            return new MaintenanceModeState(ScheduleStatus.Upcoming, maintenanceStartAt, estimatedMaintenanceOverAt);
        }

        public static bool operator ==(MaintenanceModeState a, MaintenanceModeState b) => a.Status == b.Status && a.EstimatedMaintenanceOverAt == b.EstimatedMaintenanceOverAt && a.MaintenanceStartAt == b.MaintenanceStartAt;
        public static bool operator !=(MaintenanceModeState a, MaintenanceModeState b) => a.Status != b.Status || a.EstimatedMaintenanceOverAt != b.EstimatedMaintenanceOverAt || a.MaintenanceStartAt != b.MaintenanceStartAt;

        public enum ScheduleStatus
        {
            NotScheduled = 0,
            Ongoing = 1,
            Upcoming = 2
        }
    }
}

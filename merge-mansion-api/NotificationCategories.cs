using Metaplay.Core.Model;

[MetaSerializable]
public enum NotificationCategories
{
    None = 0,
    ActivationItemReady = 1,
    ChestReadyForOpening = 2,
    SpawnerItemReady = 3,
    HotspotUnlockScheduleReached = 4
}
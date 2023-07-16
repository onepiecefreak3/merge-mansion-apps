namespace Metaplay.Metaplay.Core.Network
{
    public interface ISessionDeviceGuidService
    {
        // RVA: -1 Offset: -1 Slot: 0
        string TryGetDeviceGuid();

        // RVA: -1 Offset: -1 Slot: 1
        void StoreDeviceGuid(string deviceGuid);
    }
}

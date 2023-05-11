using Metaplay.Metaplay.Core.Message;
using Metaplay.Metaplay.Core.Network;

namespace Metaplay.Metaplay.Unity
{
	internal interface IMetaplayConnectionSDKHook
    {
        // Methods

        // RVA: -1 Offset: -1 Slot: 0
        void OnCurrentCdnAddressUpdated(MetaplayCdnAddress currentAddress);

        // RVA: -1 Offset: -1 Slot: 1
        void OnScheduledMaintenanceModeUpdated(MaintenanceModeState maintenanceMode);

        // RVA: -1 Offset: -1 Slot: 2
        void OnSessionStarted(SessionProtocol.SessionStartSuccess sessionStart);

        // RVA: -1 Offset: -1 Slot: 3
        string GetDeviceGuid();

        // RVA: -1 Offset: -1 Slot: 3
        //void SuppressIncidentReportForNextNetworkError();
    }
}

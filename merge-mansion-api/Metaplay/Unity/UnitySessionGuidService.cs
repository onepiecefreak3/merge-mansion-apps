using Metaplay.Metaplay.Core.Network;

namespace Metaplay.Metaplay.Unity
{
    internal class UnitySessionGuidService : ISessionDeviceGuidService
    {
        protected readonly IMetaplayConnectionSDKHook _sdk; // 0x10
        
        public UnitySessionGuidService(IMetaplayConnectionSDKHook sdk)
        {
            _sdk = sdk;
        }

        public string TryGetDeviceGuid()
        {
            return _sdk.GetDeviceGuid();
        }

        public void StoreDeviceGuid(string deviceGuid)
        {
            _sdk.SetDeviceGuid(deviceGuid);
        }
    }
}

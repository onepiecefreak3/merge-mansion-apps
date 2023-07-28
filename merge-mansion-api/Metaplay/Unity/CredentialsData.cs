using Metaplay.Core;
using Metaplay.Core.Model;

namespace Metaplay.Unity
{
    [MetaSerializable]
    public class CredentialsData
    {
        [MetaMember(1, 0)]
        public string DeviceId; // 0x10
        [MetaMember(2, 0)]
        public string AuthToken; // 0x18
        [MetaMember(3, 0)]
        public EntityId PlayerId; // 0x20
    }
}

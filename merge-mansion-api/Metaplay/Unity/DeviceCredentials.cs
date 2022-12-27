using Metaplay.Metaplay.Core;

namespace Metaplay.Metaplay.Unity
{
    public class DeviceCredentials
    {
        public string DeviceId; // 0x10
        public string AuthToken; // 0x18
        public EntityId PlayerId; // 0x20

        public static bool operator ==(DeviceCredentials a, DeviceCredentials b) => ReferenceEquals(a, b) || a != null && b != null && a.DeviceId == b.DeviceId && a.AuthToken == b.AuthToken && a.PlayerId == b.PlayerId;
        public static bool operator !=(DeviceCredentials a, DeviceCredentials b) => !ReferenceEquals(a, b) && (a?.DeviceId != b?.DeviceId || a?.AuthToken != b?.AuthToken || a?.PlayerId != b?.PlayerId);

        public override bool Equals(object obj)
        {
            if (!(obj is DeviceCredentials devCreds))
                return false;

            return this == devCreds;
        }

        public override int GetHashCode()
        {
            return DeviceId.GetHashCode();
        }
    }
}

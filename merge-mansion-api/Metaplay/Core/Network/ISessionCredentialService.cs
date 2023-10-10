using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.Core.Network
{
    public interface ISessionCredentialService
    {
        public readonly struct GuestCredentials
        {
            // Fields
            public readonly string DeviceId; // 0x0
            public readonly string AuthToken; // 0x8
            public readonly EntityId PlayerIdHint; // 0x10

            // Methods

            // RVA: 0x21BEC64 Offset: 0x21BEC64 VA: 0x21BEC64
            public GuestCredentials(string deviceId, string authToken, EntityId playerIdHint)
            {
                DeviceId = deviceId;
                AuthToken = authToken;
                PlayerIdHint = playerIdHint;
            }
        }
    }
}

using Metaplay.Core.Model;
using System;
using Metaplay.Core.Message;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public class PlayerLoginEvent
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime Timestamp { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DeviceId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string DeviceModel { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string ClientVersion { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public PlayerLocation? Location { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public AuthenticationKey AuthenticationKey { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string IpAddress { get; set; }

        [MetaMember(100, (MetaMemberFlags)0)]
        public ClientPlatform ClientPlatform { get; set; }

        public PlayerLoginEvent()
        {
        }

        public PlayerLoginEvent(MetaTime timestamp, string deviceId, string deviceModel, string clientVersion, PlayerLocation? location, AuthenticationKey authKey, string ipAddress, ClientPlatform clientPlatform)
        {
        }

        [MetaMember(9, (MetaMemberFlags)0)]
        public string OperatingSystem { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public MetaDuration? SessionLengthApprox { get; set; }

        public PlayerLoginEvent(MetaTime timestamp, string deviceId, SessionProtocol.ClientDeviceInfo device, string clientVersion, PlayerLocation? location, AuthenticationKey authKey, string ipAddress)
        {
        }
    }
}
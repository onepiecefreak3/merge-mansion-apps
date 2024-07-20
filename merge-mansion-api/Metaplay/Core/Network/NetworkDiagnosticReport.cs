using System.Collections.Generic;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Network
{
    [MetaSerializable]
    public class NetworkDiagnosticReport
    {
        // STUB
        public NetworkDiagnosticReport()
        {
        }

        public NetworkDiagnosticReport(string gameServerHostnameIPv4, string gameServerHostnameIPv6, List<int> gameServerPorts, string cdnHostnameIPv4, string cdnHostnameIPv6)
        {
        }

        [MetaMember(1, (MetaMemberFlags)0)]
        public GameServerEndpointResult GameServerIPv4 { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public GameServerEndpointResult GameServerIPv6 { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public SocketProbeResult GameCdnSocketIPv4 { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public SocketProbeResult GameCdnSocketIPv6 { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public HttpRequestProbeResult GameCdnHttpIPv4 { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public HttpRequestProbeResult GameCdnHttpIPv6 { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public SocketProbeResult GoogleComIPv4 { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public SocketProbeResult GoogleComIPv6 { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public SocketProbeResult MicrosoftComIPv4 { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public SocketProbeResult MicrosoftComIPv6 { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public SocketProbeResult AppleComIPv4 { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public SocketProbeResult AppleComIPv6 { get; set; }

        [MetaMember(100, (MetaMemberFlags)0)]
        public SocketProbeResult MetacoreLighthouse { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public SocketProbeResult MetacoreGlobalAccelerator { get; set; }

        [MetaMember(102, (MetaMemberFlags)0)]
        public SocketProbeResult MetacoreGlobalAcceleratorTls { get; set; }
    }
}
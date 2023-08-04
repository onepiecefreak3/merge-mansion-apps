using Metaplay.Core.Model;

namespace Metaplay.Core.Network
{
    [MetaSerializable]
    public class SocketProbeResult
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public SocketProbeStep ResolveDnsStatus { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public SocketProbeStep TcpHandshakeStatus { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public SocketProbeStep TlsHandshakeStatus { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public SocketProbeStep TransferStatus { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public SocketProbeStep ProtocolStatus { get; set; }

        public SocketProbeResult()
        {
        }
    }
}
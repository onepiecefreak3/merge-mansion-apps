using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Network;

namespace Metaplay.Metaplay.Client.Messages
{
    [MetaMessage(200003, MessageDirection.ClientInternal, false)]
    public class ConnectionHandshakeFailure : MetaMessage
    {
        public ProtocolStatus ProtocolStatus { get; set; } // 0x10

        private ConnectionHandshakeFailure() { }

        public ConnectionHandshakeFailure(ProtocolStatus protocolStatus)
        {
            ProtocolStatus = protocolStatus;
        }
    }
}

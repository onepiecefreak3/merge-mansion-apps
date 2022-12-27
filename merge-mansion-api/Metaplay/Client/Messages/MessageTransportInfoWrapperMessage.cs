using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Network;

namespace Metaplay.Metaplay.Client.Messages
{
    [MetaMessage(200004, MessageDirection.ClientInternal, false)]
    public class MessageTransportInfoWrapperMessage : MetaMessage
    {
        public MessageTransport.Info Info { get; set; } // 0x10

        private MessageTransportInfoWrapperMessage() { }

        public MessageTransportInfoWrapperMessage(MessageTransport.Info info)
        {
            Info = info;
        }
	}
}

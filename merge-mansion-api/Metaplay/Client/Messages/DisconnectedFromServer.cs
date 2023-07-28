using Metaplay.Core;

namespace Metaplay.Client.Messages
{
	[MetaMessage(200002, MessageDirection.ClientInternal, false)]
    public class DisconnectedFromServer : MetaMessage
    {
    }
}

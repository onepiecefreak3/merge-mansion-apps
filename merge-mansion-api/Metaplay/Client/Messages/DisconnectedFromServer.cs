using Metaplay.Metaplay.Core;

namespace Metaplay.Metaplay.Client.Messages
{
	[MetaMessage(200002, MessageDirection.ClientInternal, false)]
    public class DisconnectedFromServer : MetaMessage
    {
    }
}

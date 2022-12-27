using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Client.Messages
{
    [MetaMessage(200001, MessageDirection.ClientInternal, false)]
    public class ConnectedToServer : MetaMessage
    {
        [MetaMember(1, 0)]
        public string ChosenHostname; // 0x10
        [MetaMember(2, 0)]
        public bool IsIPv4; // 0x18
        [MetaMember(3, 0)]
        public string TlsPeerDescription; // 0x20

        private ConnectedToServer() { }

        public ConnectedToServer(string chosenHostname, bool isIPv4, string tlsPeerDescription)
        {
            ChosenHostname = chosenHostname;
            IsIPv4 = isIPv4;
            TlsPeerDescription = tlsPeerDescription;
        }
    }
}

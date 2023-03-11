using System.Net.Sockets;
using Metaplay.Metaplay.Core.Message;

namespace Metaplay.Metaplay.Core.Network
{
    public abstract class MessageTransport : IMessageTransport
    {
        public delegate void ConnectEventHandler(Handshake.ServerHello serverHello, TransportHandshakeReport transportHandshake);
        public delegate void ReceiveEventHandler(MetaMessage message);
        public delegate void InfoEventHandler(Info info);
        public delegate void ErrorEventHandler(Error error);

        public event ConnectEventHandler OnConnect;
        public event ReceiveEventHandler OnReceive;
        public event InfoEventHandler OnInfo;
        public event ErrorEventHandler OnError;

        // RVA: -1 Offset: -1 Slot: 18
        public abstract void SetDebugDiagnosticsRef(LoginTransportDebugDiagnostics debugDiagnostics);

        // RVA: -1 Offset: -1 Slot: 19
        public abstract void Open();

        // RVA: -1 Offset: -1 Slot: 20
        public abstract void EnqueueSendMessage(MetaMessage message);

        // RVA: -1 Offset: -1 Slot: 23
        public abstract void Dispose();

        // CUSTOM: Tells if the transport got closed
        //public abstract bool WasClosed();

        protected void InvokeOnConnect(Handshake.ServerHello serverHello, TransportHandshakeReport transportHandshake)
        {
            OnConnect?.Invoke(serverHello, transportHandshake);
        }

        protected void InvokeOnReceive(MetaMessage message)
        {
            OnReceive?.Invoke(message);
        }

        protected void InvokeOnInfo(Info info)
        {
            OnInfo?.Invoke(info);
        }

        protected void InvokeOnError(Error error)
        {
            OnError?.Invoke(error);
        }

        public abstract class Info
        {
        }

        public abstract class Error
        {
        }

        public sealed class EnqueuedCloseError : Error
        {
        }

        public struct TransportHandshakeReport
        {
            public string ChosenHostname; // 0x0
            public AddressFamily ChosenProtocol; // 0x8
            public string TlsPeerDescription; // 0x10

            public TransportHandshakeReport(string chosenHostname, AddressFamily chosenProtocol, string tlsPeerDescription)
            {
                ChosenHostname = chosenHostname;
                ChosenProtocol = chosenProtocol;
                TlsPeerDescription = tlsPeerDescription;
            }
        }
    }
}

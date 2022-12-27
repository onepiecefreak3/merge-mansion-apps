using Metaplay.Metaplay.Core.Message;

namespace Metaplay.Metaplay.Core.Network
{
    public interface IMessageTransport
    {
        // RVA: -1 Offset: -1 Slot: 0
        void SetDebugDiagnosticsRef(LoginTransportDebugDiagnostics debugDiagnostics);

        event MessageTransport.ConnectEventHandler OnConnect;
        event MessageTransport.ReceiveEventHandler OnReceive;
        event MessageTransport.InfoEventHandler OnInfo;
        event MessageTransport.ErrorEventHandler OnError;

        // RVA: -1 Offset: -1 Slot: 9
        void Open();

        // RVA: -1 Offset: -1 Slot: 10
        void EnqueueSendMessage(MetaMessage message);

        // RVA: -1 Offset: -1 Slot: 13
        void Dispose();
    }
}

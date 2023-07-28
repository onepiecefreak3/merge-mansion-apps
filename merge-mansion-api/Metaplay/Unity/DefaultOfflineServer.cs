using System;
using System.Threading.Tasks;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Message;
using Metaplay.Core.Network;

namespace Metaplay.Unity
{
    public class DefaultOfflineServer : MessageTransport, IOfflineServer, IMetaIntegrationConstructible<IOfflineServer>
    {
        public ConfigArchive GameConfigArchive { get; }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public override void SetDebugDiagnosticsRef(LoginTransportDebugDiagnostics debugDiagnostics)
        {
            throw new NotImplementedException();
        }

        public override void Open()
        {
            throw new NotImplementedException();
        }

        public override void EnqueueSendMessage(MetaMessage message)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

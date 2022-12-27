using Metaplay.Metaplay.Core;

namespace Metaplay.Metaplay.Unity.ConnectionStates
{
	public class Connected : ConnectionState // TypeDefIndex: 13123
    {
        public readonly bool IsHealthy; // 0x10
        public readonly MetaTime LatestReceivedMessageTimestamp; // 0x18

        public sealed override ConnectionStatus Status => ConnectionStatus.Connected;

        public Connected(bool isHealthy, MetaTime latestReceivedMessageTimestamp)
        {
            IsHealthy = isHealthy;
            LatestReceivedMessageTimestamp = latestReceivedMessageTimestamp;
        }
    }
}

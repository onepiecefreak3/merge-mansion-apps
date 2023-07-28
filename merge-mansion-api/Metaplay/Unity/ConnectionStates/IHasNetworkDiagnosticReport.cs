using Metaplay.Core.Network;

namespace Metaplay.Unity.ConnectionStates
{
    public interface IHasNetworkDiagnosticReport
    {
        // RVA: -1 Offset: -1 Slot: 0
        // RVA: -1 Offset: -1 Slot: 1
        public NetworkDiagnosticReport NetworkDiagnosticReport { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Network;

namespace Metaplay.Metaplay.Unity.ConnectionStates
{
    public interface IHasNetworkDiagnosticReport
    {
        // RVA: -1 Offset: -1 Slot: 0
        // RVA: -1 Offset: -1 Slot: 1
        public NetworkDiagnosticReport NetworkDiagnosticReport { get; set; }
    }
}

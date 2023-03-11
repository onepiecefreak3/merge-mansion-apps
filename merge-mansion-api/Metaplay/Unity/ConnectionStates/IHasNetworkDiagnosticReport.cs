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
        public NetworkDiagnosticReport NetworkDiagnosticReport { get; set; }
    }
}

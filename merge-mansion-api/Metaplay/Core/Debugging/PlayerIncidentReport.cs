using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Message;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Network;

namespace Metaplay.Metaplay.Core.Debugging
{
    public abstract class PlayerIncidentReport
    {
        [MetaSerializableDerived(4)]
        public class SessionStartFailed : PlayerIncidentReport
        {
            [MetaMember(4, 0)]
            public string ErrorType { get; set; }
            [MetaMember(1, 0)]
            public string NetworkError { get; set; }
            [MetaMember(2, 0)]
            public ServerEndpoint Endpoint { get; set; }
            [MetaMember(3, 0)]
            public string NetworkReachability { get; set; }
            [MetaMember(5, 0)]
            public NetworkDiagnosticReport NetworkReport { get; set; }
            [MetaMember(6, 0)]
            public string TlsPeerDescription { get; set; }
		}
    }
}

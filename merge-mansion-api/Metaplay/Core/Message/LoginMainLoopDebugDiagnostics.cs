using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Message
{
    public class LoginMainLoopDebugDiagnostics
    {
        [MetaMember(1, 0)]
        public int UpdatesStarted; // 0x10
        [MetaMember(2, 0)]
        public int UpdatesEndedPrematurely; // 0x14
        [MetaMember(3, 0)]
        public int UpdatesEndedNormally; // 0x18
	}
}

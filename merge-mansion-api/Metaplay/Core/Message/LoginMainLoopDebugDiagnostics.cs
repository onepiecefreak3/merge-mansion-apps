using Metaplay.Core.Model;

namespace Metaplay.Core.Message
{
    [MetaSerializable]
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

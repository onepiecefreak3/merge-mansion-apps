using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Message
{
    [MetaSerializable]
    public class LoginSessionDebugDiagnostics
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int NumSent { get; set; } // 0x10

        [MetaMember(2, 0)]
        public int NumRememberedSent { get; set; } // 0x14

        [MetaMember(6, 0)]
        public int[] FirstNRememberedSentMessageTypeCodes { get; set; } // 0x18

        [MetaMember(3, 0)]
        public int TotalPendingFlushActionsOperationsBytes { get; set; } // 0x20

        [MetaMember(4, 0)]
        public int TotalPendingFlushActionsChecksums { get; set; } // 0x24

        [MetaMember(5, 0)]
        public string PreviousTransportErrorName { get; set; } // 0x28
        public string[] FirstNRememberedSentMessageTypeNames { get; }

        public LoginSessionDebugDiagnostics()
        {
        }
    }
}
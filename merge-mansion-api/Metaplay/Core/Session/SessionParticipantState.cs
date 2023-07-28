using System.Collections.Generic;

namespace Metaplay.Core.Session
{
    public class SessionParticipantState
    {
        public SessionToken Token { get; } // 0x10
        public int NumSent { get; set; } // 0x18
        public Queue<MetaMessage> RememberedSent { get; set; } // 0x20
        public int NumAcknowledgedSent { get; set; } // 0x28
        public int NumReceived { get; set; } // 0x2C
        public int AcknowledgedNumReceived { get; set; } // 0x30
        public uint ChecksumForForgottenSent { get; set; } // 0x34
        public uint ChecksumForReceived { get; set; } // 0x38

        public SessionParticipantState(SessionToken token)
        {
            RememberedSent = new Queue<MetaMessage>();
            Token = token;
        }
    }
}

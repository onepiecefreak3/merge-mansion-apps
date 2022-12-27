using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Message
{
	public class LoginTransportDebugDiagnostics // TypeDefIndex: 1014
    {
        // Fields
        [MetaMember(1, 0)]
        public int WritesStarted; // 0x10
        [MetaMember(2, 0)]
        public int WritesCompleted; // 0x14
        [MetaMember(3, 0)]
        public int ReadsStarted; // 0x18
        [MetaMember(4, 0)]
        public int ReadsCompleted; // 0x1C
        [MetaMember(5, 0)]
        public int MetaMessageEnqueuesAttempted; // 0x20
        [MetaMember(6, 0)]
        public int MetaMessageUnconnectedEnqueuesAttempted; // 0x24
        [MetaMember(7, 0)]
        public int MetaMessageDisposedEnqueuesAttempted; // 0x28
        [MetaMember(8, 0)]
        public int MetaMessagePacketSizesExceeded; // 0x2C
        [MetaMember(9, 0)]
        public int MetaMessageClosingEnqueuesAttempted; // 0x30
        [MetaMember(10, 0)]
        public int MetaMessagesEnqueued; // 0x34
        [MetaMember(11, 0)]
        public int PacketEnqueuesAttempted; // 0x38
        [MetaMember(12, 0)]
        public int PacketsEnqueued; // 0x3C
        [MetaMember(13, 0)]
        public int BytesEnqueued; // 0x40
        [MetaMember(14, 0)]
        public int MetaMessagesWritten; // 0x44
        [MetaMember(15, 0)]
        public int PacketsWritten; // 0x48
        [MetaMember(16, 0)]
        public int BytesWritten; // 0x4C
        [MetaMember(17, 0)]
        public int BytesRead; // 0x50
        [MetaMember(18, 0)]
        public int PacketsRead; // 0x54
        [MetaMember(19, 0)]
        public int MetaMessagesRead; // 0x58
        [MetaMember(20, 0)]
        public int MetaMessagesReceived; // 0x5C

        public LoginTransportDebugDiagnostics Clone()
        {
            return (LoginTransportDebugDiagnostics)MemberwiseClone();
        }
    }
}

using Metaplay.Core.Model;

namespace Metaplay.Core.Message
{
    [MetaSerializable]
    public class LoginTransportDebugDiagnostics // TypeDefIndex: 1014
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int WritesStarted; // 0x10
        [MetaMember(2, (MetaMemberFlags)0)]
        public int WritesCompleted; // 0x14
        [MetaMember(3, (MetaMemberFlags)0)]
        public int ReadsStarted; // 0x18
        [MetaMember(4, (MetaMemberFlags)0)]
        public int ReadsCompleted; // 0x1C
        [MetaMember(5, (MetaMemberFlags)0)]
        public int MetaMessageEnqueuesAttempted; // 0x20
        [MetaMember(6, (MetaMemberFlags)0)]
        public int MetaMessageUnconnectedEnqueuesAttempted; // 0x24
        [MetaMember(7, (MetaMemberFlags)0)]
        public int MetaMessageDisposedEnqueuesAttempted; // 0x28
        [MetaMember(8, (MetaMemberFlags)0)]
        public int MetaMessagePacketSizesExceeded; // 0x2C
        [MetaMember(9, (MetaMemberFlags)0)]
        public int MetaMessageClosingEnqueuesAttempted; // 0x30
        [MetaMember(10, (MetaMemberFlags)0)]
        public int MetaMessagesEnqueued; // 0x34
        [MetaMember(11, (MetaMemberFlags)0)]
        public int PacketEnqueuesAttempted; // 0x38
        [MetaMember(12, (MetaMemberFlags)0)]
        public int PacketsEnqueued; // 0x3C
        [MetaMember(13, (MetaMemberFlags)0)]
        public int BytesEnqueued; // 0x40
        [MetaMember(14, (MetaMemberFlags)0)]
        public int MetaMessagesWritten; // 0x44
        [MetaMember(15, (MetaMemberFlags)0)]
        public int PacketsWritten; // 0x48
        [MetaMember(16, (MetaMemberFlags)0)]
        public int BytesWritten; // 0x4C
        [MetaMember(17, (MetaMemberFlags)0)]
        public int BytesRead; // 0x50
        [MetaMember(18, (MetaMemberFlags)0)]
        public int PacketsRead; // 0x54
        [MetaMember(19, (MetaMemberFlags)0)]
        public int MetaMessagesRead; // 0x58
        [MetaMember(20, (MetaMemberFlags)0)]
        public int MetaMessagesReceived; // 0x5C
        public LoginTransportDebugDiagnostics Clone()
        {
            return (LoginTransportDebugDiagnostics)MemberwiseClone();
        }

        public LoginTransportDebugDiagnostics()
        {
        }
    }
}
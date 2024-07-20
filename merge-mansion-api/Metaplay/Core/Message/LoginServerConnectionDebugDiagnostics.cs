using Metaplay.Core.Model;

namespace Metaplay.Core.Message
{
    [MetaSerializable]
    public class LoginServerConnectionDebugDiagnostics
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int TransportsCreated; // 0x10
        [MetaMember(2, (MetaMemberFlags)0)]
        public int SessionMessageEnqueuesAttempted; // 0x14
        [MetaMember(3, (MetaMemberFlags)0)]
        public int SessionMessageImmediateSendEnqueues; // 0x18
        [MetaMember(4, (MetaMemberFlags)0)]
        public long FirstSessionMessageSentAtMS; // 0x20
        [MetaMember(5, (MetaMemberFlags)0)]
        public int SessionMessagesDelayedSendEnqueues; // 0x28
        [MetaMember(6, (MetaMemberFlags)0)]
        public int SessionMessagesEnqueues; // 0x2C
        [MetaMember(7, (MetaMemberFlags)0)]
        public int SessionMessagesDelayedSent; // 0x30
        [MetaMember(8, (MetaMemberFlags)0)]
        public int StreamClosedErrors; // 0x34
        [MetaMember(9, (MetaMemberFlags)0)]
        public int StreamIOFailedErrors; // 0x38
        [MetaMember(10, (MetaMemberFlags)0)]
        public int StreamExecutorErrors; // 0x3C
        [MetaMember(11, (MetaMemberFlags)0)]
        public int ConnectTimeoutErrors; // 0x40
        [MetaMember(12, (MetaMemberFlags)0)]
        public int HeaderTimeoutErrors; // 0x44
        [MetaMember(13, (MetaMemberFlags)0)]
        public int ReadTimeoutErrors; // 0x48
        [MetaMember(14, (MetaMemberFlags)0)]
        public int WriteTimeoutErrors; // 0x4C
        [MetaMember(15, (MetaMemberFlags)0)]
        public int OtherErrors; // 0x50
        [MetaMember(16, (MetaMemberFlags)0)]
        public int HellosSent; // 0x54
        [MetaMember(17, (MetaMemberFlags)0)]
        public int InitialLoginsSent; // 0x58
        [MetaMember(18, (MetaMemberFlags)0)]
        public int ResumptionLoginsSent; // 0x5C
        [MetaMember(19, (MetaMemberFlags)0)]
        public int HellosReceived; // 0x60
        [MetaMember(20, (MetaMemberFlags)0)]
        public int LoginSuccessesReceived; // 0x64
        [MetaMember(21, (MetaMemberFlags)0)]
        public long LastLoginSuccessReceivedAtMS; // 0x68
        [MetaMember(22, (MetaMemberFlags)0)]
        public int SessionMessagesReceived; // 0x70
        [MetaMember(23, (MetaMemberFlags)0)]
        public int SessionPayloadMessagesReceived; // 0x74
        public MetaTime FirstSessionMessageSentAt => MetaTime.FromMillisecondsSinceEpoch(FirstSessionMessageSentAtMS);
        public MetaTime LastLoginSuccessReceivedAt => MetaTime.FromMillisecondsSinceEpoch(LastLoginSuccessReceivedAtMS);

        public LoginServerConnectionDebugDiagnostics Clone()
        {
            return (LoginServerConnectionDebugDiagnostics)MemberwiseClone();
        }

        public LoginServerConnectionDebugDiagnostics()
        {
        }
    }
}
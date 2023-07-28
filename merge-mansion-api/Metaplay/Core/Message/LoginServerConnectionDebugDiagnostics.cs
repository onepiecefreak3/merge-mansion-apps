using Metaplay.Core.Model;

namespace Metaplay.Core.Message
{
    [MetaSerializable]
    public class LoginServerConnectionDebugDiagnostics
    {
        [MetaMember(1, 0)]
        public int TransportsCreated; // 0x10
        [MetaMember(2, 0)]
        public int SessionMessageEnqueuesAttempted; // 0x14
        [MetaMember(3, 0)]
        public int SessionMessageImmediateSendEnqueues; // 0x18
        [MetaMember(4, 0)]
        public long FirstSessionMessageSentAtMS; // 0x20
        [MetaMember(5, 0)]
        public int SessionMessagesDelayedSendEnqueues; // 0x28
        [MetaMember(6, 0)]
        public int SessionMessagesEnqueues; // 0x2C
        [MetaMember(7, 0)]
        public int SessionMessagesDelayedSent; // 0x30
        [MetaMember(8, 0)]
        public int StreamClosedErrors; // 0x34
        [MetaMember(9, 0)]
        public int StreamIOFailedErrors; // 0x38
        [MetaMember(10, 0)]
        public int StreamExecutorErrors; // 0x3C
        [MetaMember(11, 0)]
        public int ConnectTimeoutErrors; // 0x40
        [MetaMember(12, 0)]
        public int HeaderTimeoutErrors; // 0x44
        [MetaMember(13, 0)]
        public int ReadTimeoutErrors; // 0x48
        [MetaMember(14, 0)]
        public int WriteTimeoutErrors; // 0x4C
        [MetaMember(15, 0)]
        public int OtherErrors; // 0x50
        [MetaMember(16, 0)]
        public int HellosSent; // 0x54
        [MetaMember(17, 0)]
        public int InitialLoginsSent; // 0x58
        [MetaMember(18, 0)]
        public int ResumptionLoginsSent; // 0x5C
        [MetaMember(19, 0)]
        public int HellosReceived; // 0x60
        [MetaMember(20, 0)]
        public int LoginSuccessesReceived; // 0x64
        [MetaMember(21, 0)]
        public long LastLoginSuccessReceivedAtMS; // 0x68
        [MetaMember(22, 0)]
        public int SessionMessagesReceived; // 0x70
        [MetaMember(23, 0)]
        public int SessionPayloadMessagesReceived; // 0x74

        public MetaTime FirstSessionMessageSentAt => MetaTime.FromMillisecondsSinceEpoch(FirstSessionMessageSentAtMS);
        public MetaTime LastLoginSuccessReceivedAt => MetaTime.FromMillisecondsSinceEpoch(LastLoginSuccessReceivedAtMS);

        public LoginServerConnectionDebugDiagnostics Clone()
        {
            return (LoginServerConnectionDebugDiagnostics)MemberwiseClone();
        }
    }
}

using Metaplay.Core;
using Metaplay.Core.Network;

namespace Metaplay.Unity
{
	public class ConnectionConfig
    {
        // Fields
        public int ConnectAttemptsMaxCount; // 0x10
        public MetaDuration ConnectAttemptInterval; // 0x18
        public MetaDuration SessionResumptionAttemptMaxDuration; // 0x20
        public MetaDuration SessionResumptionAttemptConnectionInterval; // 0x28
        public MetaDuration MaxSessionRetainingPauseDuration; // 0x30
        public MetaDuration MaxSessionRetainingFrameDuration; // 0x38
        public MetaDuration MaxNonErrorMaskingPauseDuration; // 0x40
        public MetaDuration ConnectTimeout; // 0x48
        public MetaDuration ServerIdentifyTimeout; // 0x50
        public MetaDuration ServerSessionInitTimeout; // 0x58
        public int ConfigFetchAttemptsMaxCount; // 0x60
        public MetaDuration ConfigFetchTimeout; // 0x68
        public MetaDuration CloseFlushTimeout; // 0x70
        public MetaDuration ServerStatusHintCheckDelay; // 0x78
        public MetaDuration ServerStatusHintConnectTimeout; // 0x80
        public MetaDuration ServerStatusHintReadTimeout; // 0x88
        public ClientServerCommitIdCheckRule CommitIdCheckRule; // 0x90
        public MetaDuration SessionPingPongDurationIncidentThreshold; // 0x98
        public int MaxSessionPingPongDurationIncidentsPerSession; // 0xA0

        public ConnectionConfig()
        {
            ConnectAttemptsMaxCount = 5;
            ConnectAttemptInterval=MetaDuration.FromMilliseconds(500);
            SessionResumptionAttemptMaxDuration=MetaDuration.FromSeconds(20);
            SessionResumptionAttemptConnectionInterval=MetaDuration.FromSeconds(2);
            MaxSessionRetainingPauseDuration=MetaDuration.FromSeconds(90);
            MaxSessionRetainingFrameDuration=MetaDuration.FromSeconds(90);
            MaxNonErrorMaskingPauseDuration=MetaDuration.FromSeconds(20);
            ConnectTimeout=MetaDuration.FromSeconds(32);
            ServerIdentifyTimeout=MetaDuration.FromSeconds(10);
            ServerSessionInitTimeout=MetaDuration.FromSeconds(10);
            ConfigFetchAttemptsMaxCount = 4;
            ConfigFetchTimeout=MetaDuration.FromSeconds(10);
            CloseFlushTimeout=MetaDuration.FromMilliseconds(100);
            ServerStatusHintCheckDelay = MetaDuration.FromMilliseconds(1000);
            ServerStatusHintConnectTimeout = MetaDuration.FromMilliseconds(2000);
            ServerStatusHintReadTimeout = MetaDuration.FromMilliseconds(2000);

            SessionPingPongDurationIncidentThreshold=MetaDuration.FromSeconds(5);
            MaxSessionPingPongDurationIncidentsPerSession = 3;
        }
    }
}

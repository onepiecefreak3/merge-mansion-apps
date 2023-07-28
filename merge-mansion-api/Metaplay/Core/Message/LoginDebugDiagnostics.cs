using Metaplay.Core.Model;

namespace Metaplay.Core.Message
{
    [MetaSerializable]
    public class LoginDebugDiagnostics
    {
        [MetaMember(5, 0)]
        public MetaTime Timestamp; // 0x10
        [MetaMember(1, 0)]
        public LoginSessionDebugDiagnostics Session; // 0x18
        [MetaMember(6, 0)]
        public LoginServerConnectionDebugDiagnostics ServerConnection; // 0x20
        [MetaMember(7, 0)]
        public LoginTransportDebugDiagnostics Transport; // 0x28
        [MetaMember(8, 0)]
        public LoginIncidentReportDebugDiagnostics IncidentReport; // 0x30
        [MetaMember(9, 0)]
        public LoginMainLoopDebugDiagnostics MainLoop; // 0x38
        [MetaMember(2, 0)]
        public MetaDuration? CurrentPauseDuration; // 0x40
        [MetaMember(11, 0)]
        public MetaDuration? DurationSincePauseEnd; // 0x50
        [MetaMember(3, 0)]
        public MetaDuration? DurationSinceConnectionUpdate; // 0x60
        [MetaMember(4, 0)]
        public MetaDuration? DurationSincePlayerContextUpdate; // 0x70
        [MetaMember(12, 0)]
        public bool ExpectSessionResumptionPing; // 0x80
        [MetaMember(10, 0)]
        public string DiagnosticsError; // 0x88
	}
}

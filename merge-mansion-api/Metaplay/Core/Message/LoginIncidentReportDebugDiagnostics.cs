using Metaplay.Core.Model;

namespace Metaplay.Core.Message
{
    [MetaSerializable]
    public class LoginIncidentReportDebugDiagnostics
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int CurrentPendingIncidents; // 0x10
        [MetaMember(2, (MetaMemberFlags)0)]
        public int CurrentRequestedIncidents; // 0x14
        [MetaMember(3, (MetaMemberFlags)0)]
        public int TotalUploadRequestMessages; // 0x18
        [MetaMember(4, (MetaMemberFlags)0)]
        public int TotalRequestedIncidents; // 0x1C
        [MetaMember(5, (MetaMemberFlags)0)]
        public int AcknowledgedIncidents; // 0x20
        [MetaMember(6, (MetaMemberFlags)0)]
        public int UploadsAttempted; // 0x24
        [MetaMember(7, (MetaMemberFlags)0)]
        public int UploadUnavailable; // 0x28
        [MetaMember(8, (MetaMemberFlags)0)]
        public int UploadException; // 0x2C
        [MetaMember(9, (MetaMemberFlags)0)]
        public int UploadTooLarge; // 0x30
        [MetaMember(10, (MetaMemberFlags)0)]
        public int UploadsSent; // 0x34
        public LoginIncidentReportDebugDiagnostics Clone()
        {
            return (LoginIncidentReportDebugDiagnostics)MemberwiseClone();
        }

        public LoginIncidentReportDebugDiagnostics()
        {
        }
    }
}
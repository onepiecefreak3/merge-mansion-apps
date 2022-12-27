using System;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Debugging;
using Metaplay.Metaplay.Core.Message;
using Metaplay.Metaplay.Core.Network;
using Metaplay.Metaplay.Core.Session;

namespace Metaplay.Metaplay.Unity
{
    public class PlayerIncidentTracker : IDisposable
    {
        public delegate void IncidentReportCallback(PlayerIncidentReport report);
        public event IncidentReportCallback OnNewIncidentReport;

        public PlayerIncidentTracker(PlayerIncidentRepository incidentRepository) { }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void ReportWatchdogDeadlineExceededError()
        {
            // STUB
        }

        public PlayerIncidentReport.SessionStartFailed TryCreateSessionStartFailureReport(ConnectionState error,
            ServerEndpoint endpoint, string tlsPeerDescription, NetworkDiagnosticReport networkReport,
            bool informListeners)
        {
            return null;
        }

        public void ReportSessionPingPongDurationThresholdExceeded(LoginDebugDiagnostics debugDiagnostics,
            MetaDuration roundtripEstimate, ServerGateway serverGateway, SessionToken sessionToken, int pingId,
            MetaDuration timeSincePing)
        {
            // STUB
        }
    }
}

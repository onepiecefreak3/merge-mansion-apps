using System;
using Metaplay.Core;
using Metaplay.Core.Debugging;
using Metaplay.Core.Message;
using Metaplay.Core.Network;

namespace Metaplay.Unity
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

        public void ReportSessionPingPongDurationThresholdExceeded(LoginDebugDiagnostics debugDiagnostics, MetaDuration roundtripEstimate, ServerGateway serverGateway, int pingId, MetaDuration timeSincePing)
        {
            // STUB
        }
    }
}

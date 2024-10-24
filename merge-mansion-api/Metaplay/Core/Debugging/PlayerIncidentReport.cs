using Metaplay.Core.Message;
using Metaplay.Core.Model;
using Metaplay.Core.Network;
using System;
using System.Collections.Generic;
using Metaplay.Core.Session;

namespace Metaplay.Core.Debugging
{
    [MetaReservedMembers(100, 200)]
    [MetaSerializable]
    public abstract class PlayerIncidentReport
    {
        [MetaSerializableDerived(4)]
        public class SessionStartFailed : PlayerIncidentReport
        {
            [MetaMember(4, (MetaMemberFlags)0)]
            public string ErrorType { get; set; }

            [MetaMember(1, 0)]
            public string NetworkError { get; set; }

            [MetaMember(2, 0)]
            public ServerEndpoint Endpoint { get; set; }

            [MetaMember(3, 0)]
            public string NetworkReachability { get; set; }

            [MetaMember(5, 0)]
            public NetworkDiagnosticReport NetworkReport { get; set; }

            [MetaMember(6, 0)]
            public string TlsPeerDescription { get; set; }

            [MetaMember(7, (MetaMemberFlags)0)]
            public string ReasonOverride { get; set; }
            public override string Type { get; }
            public override string SubType { get; }

            private SessionStartFailed()
            {
            }

            public SessionStartFailed(string id, MetaTime occurredAt, List<ClientLogEntry> logEntries, UnitySystemInfo systemInfo, UnityPlatformInfo platformInfo, IncidentGameConfigInfo gameConfigInfo, string errorType, string networkError, string reasonOverride, ServerEndpoint endpoint, string networkReachability, NetworkDiagnosticReport networkReport, string tlsPeerDescription)
            {
            }

            public SessionStartFailed(string id, MetaTime occurredAt, List<ClientLogEntry> logEntries, UnitySystemInfo systemInfo, UnityPlatformInfo platformInfo, IncidentGameConfigInfo gameConfigInfo, IncidentApplicationInfo applicationInfo, string errorType, string networkError, string reasonOverride, ServerEndpoint endpoint, string networkReachability, NetworkDiagnosticReport networkReport, string tlsPeerDescription)
            {
            }
        }

        [MetaMember(100, (MetaMemberFlags)0)]
        public string IncidentId { get; set; }

        [MetaMember(102, (MetaMemberFlags)0)]
        public MetaTime OccurredAt { get; set; }

        [MetaMember(103, (MetaMemberFlags)0)]
        public List<ClientLogEntry> ClientLogEntries { get; set; }

        [MetaMember(104, (MetaMemberFlags)0)]
        public UnitySystemInfo ClientSystemInfo { get; set; }

        [MetaMember(105, (MetaMemberFlags)0)]
        public UnityPlatformInfo ClientPlatformInfo { get; set; }

        [MetaMember(106, (MetaMemberFlags)0)]
        public IncidentGameConfigInfo GameConfigInfo { get; set; }
        public DateTime UploadedAt { get; set; }
        public abstract string Type { get; }
        public abstract string SubType { get; }

        public PlayerIncidentReport()
        {
        }

        public PlayerIncidentReport(string incidentId, MetaTime occurredAt, List<ClientLogEntry> logEntries, UnitySystemInfo systemInfo, UnityPlatformInfo platformInfo, IncidentGameConfigInfo gameConfigInfo)
        {
        }

        [MetaSerializableDerived(1)]
        public class TerminalNetworkError : PlayerIncidentReport
        {
            [MetaMember(4, (MetaMemberFlags)0)]
            public string ErrorType { get; set; }

            [MetaMember(1, (MetaMemberFlags)0)]
            public string NetworkError { get; set; }

            [MetaMember(7, (MetaMemberFlags)0)]
            public string ReasonOverride { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public ServerEndpoint Endpoint { get; set; }

            [MetaMember(3, (MetaMemberFlags)0)]
            public string NetworkReachability { get; set; }

            [MetaMember(5, (MetaMemberFlags)0)]
            public NetworkDiagnosticReport NetworkReport { get; set; }

            [MetaMember(6, (MetaMemberFlags)0)]
            public string TlsPeerDescription { get; set; }
            public override string Type { get; }
            public override string SubType { get; }

            public TerminalNetworkError()
            {
            }

            public TerminalNetworkError(string id, MetaTime occurredAt, List<ClientLogEntry> logEntries, UnitySystemInfo systemInfo, UnityPlatformInfo platformInfo, IncidentGameConfigInfo gameConfigInfo, string errorType, string networkError, string reasonOverride, ServerEndpoint endpoint, string networkReachability, NetworkDiagnosticReport networkReport, string tlsPeerDescription)
            {
            }

            public TerminalNetworkError(string id, MetaTime occurredAt, List<ClientLogEntry> logEntries, UnitySystemInfo systemInfo, UnityPlatformInfo platformInfo, IncidentGameConfigInfo gameConfigInfo, IncidentApplicationInfo applicationInfo, string errorType, string networkError, string reasonOverride, ServerEndpoint endpoint, string networkReachability, NetworkDiagnosticReport networkReport, string tlsPeerDescription)
            {
            }
        }

        [MetaSerializableDerived(2)]
        public class UnhandledExceptionError : PlayerIncidentReport
        {
            [MetaMember(3, (MetaMemberFlags)0)]
            public string ExceptionName { get; set; }

            [MetaMember(1, (MetaMemberFlags)0)]
            public string ExceptionMessage { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public string StackTrace { get; set; }
            public override string Type { get; }
            public override string SubType { get; }

            public UnhandledExceptionError()
            {
            }

            public UnhandledExceptionError(string id, MetaTime occurredAt, List<ClientLogEntry> logEntries, UnitySystemInfo systemInfo, UnityPlatformInfo platformInfo, IncidentGameConfigInfo gameConfigInfo, string exceptionName, string exceptionMessage, string stackTrace)
            {
            }

            public UnhandledExceptionError(string id, MetaTime occurredAt, List<ClientLogEntry> logEntries, UnitySystemInfo systemInfo, UnityPlatformInfo platformInfo, IncidentGameConfigInfo gameConfigInfo, IncidentApplicationInfo applicationInfo, string exceptionName, string exceptionMessage, string stackTrace)
            {
            }
        }

        [MetaSerializableDerived(3)]
        public class SessionCommunicationHanged : PlayerIncidentReport
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public string IssueType { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public string IssueInfo { get; set; }

            [MetaMember(9, (MetaMemberFlags)0)]
            public LoginDebugDiagnostics DebugDiagnostics { get; set; }

            [MetaMember(10, (MetaMemberFlags)0)]
            public MetaDuration RoundtripEstimate { get; set; }

            [MetaMember(11, (MetaMemberFlags)0)]
            public ServerGateway ServerGateway { get; set; }

            [MetaMember(4, (MetaMemberFlags)0)]
            public string NetworkReachability { get; set; }

            [MetaMember(12, (MetaMemberFlags)0)]
            public string TlsPeerDescription { get; set; }

            [MetaMember(6, (MetaMemberFlags)0)]
            public SessionToken SessionToken { get; set; }

            [MetaMember(7, (MetaMemberFlags)0)]
            public int PingId { get; set; }

            [MetaMember(8, (MetaMemberFlags)0)]
            public MetaDuration ElapsedSinceCommunication { get; set; }
            public override string Type { get; }
            public override string SubType { get; }

            private SessionCommunicationHanged()
            {
            }

            public SessionCommunicationHanged(string id, MetaTime occurredAt, List<ClientLogEntry> logEntries, UnitySystemInfo systemInfo, UnityPlatformInfo platformInfo, IncidentGameConfigInfo gameConfigInfo, string issueType, string issueInfo, LoginDebugDiagnostics debugDiagnostics, MetaDuration roundtripEstimate, ServerGateway serverGateway, string networkReachability, string tlsPeerDescription, SessionToken sessionToken, int pingId, MetaDuration elapsedSinceCommunication)
            {
            }

            public SessionCommunicationHanged(string id, MetaTime occurredAt, List<ClientLogEntry> logEntries, UnitySystemInfo systemInfo, UnityPlatformInfo platformInfo, IncidentGameConfigInfo gameConfigInfo, IncidentApplicationInfo applicationInfo, string issueType, string issueInfo, LoginDebugDiagnostics debugDiagnostics, MetaDuration roundtripEstimate, ServerGateway serverGateway, string networkReachability, string tlsPeerDescription, SessionToken sessionToken, int pingId, MetaDuration elapsedSinceCommunication)
            {
            }
        }

        [MetaMember(107, (MetaMemberFlags)0)]
        public IncidentApplicationInfo ApplicationInfo { get; set; }
        public DateTime DeletionDateTime { get; set; }

        public PlayerIncidentReport(string incidentId, MetaTime occurredAt, List<ClientLogEntry> logEntries, UnitySystemInfo systemInfo, UnityPlatformInfo platformInfo, IncidentGameConfigInfo gameConfigInfo, IncidentApplicationInfo applicationInfo)
        {
        }

        [MetaSerializableDerived(5)]
        public class CompanyIdLoginError : PlayerIncidentReport
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public string Phase { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public string Message { get; set; }

            [MetaMember(3, (MetaMemberFlags)0)]
            public string Exception { get; set; }
            public override string Type { get; }
            public override string SubType { get; }
            public string StackTrace { get; }

            private CompanyIdLoginError()
            {
            }

            public CompanyIdLoginError(string id, MetaTime occurredAt, List<ClientLogEntry> logEntries, UnitySystemInfo systemInfo, UnityPlatformInfo platformInfo, IncidentGameConfigInfo gameConfigInfo, IncidentApplicationInfo applicationInfo, string phase, string message, string exception)
            {
            }
        }
    }
}
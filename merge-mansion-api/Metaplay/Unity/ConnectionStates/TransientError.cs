using System;
using Metaplay.Metaplay.Core.Message;
using Metaplay.Metaplay.Core.Network;

namespace Metaplay.Metaplay.Unity.ConnectionStates
{
    public abstract class TransientError : ConnectionState
    {
        public sealed override ConnectionStatus Status => ConnectionStatus.Error;

        public sealed class Closed : TransientError, IHasNetworkDiagnosticReport
        {
            public NetworkDiagnosticReport NetworkDiagnosticReport { get; set; }
        }

        public class Timeout : TransientError, IHasNetworkDiagnosticReport
        {
            public readonly TimeoutSource Source; // 0x10

            public NetworkDiagnosticReport NetworkDiagnosticReport { get; set; } // 0x18

            public Timeout(TimeoutSource source)
            {
                Source = source;
            }

            public enum TimeoutSource
            {
                ResourceFetch = 0,
                Connect = 1,
                Stream = 2
            }
        }

        public class SessionLostInBackground : TransientError
        { }

        public sealed class TlsError : TransientError
        {
            public readonly ErrorCode Error; // 0x10

            public TlsError(ErrorCode error)
            {
                Error = error;
            }

            public enum ErrorCode
            {
                Unknown = 0,
                NotAuthenticated = 1,
                FailureWhileAuthenticating = 2,
                NotEncrypted = 3
            }
        }

        public sealed class FailedToResumeSession : TransientError
        { }

        public sealed class ConfigFetchFailed : TransientError
        {
            // Fields
            public readonly Exception Exception; // 0x10
            public readonly FailureSource Source; // 0x18

            // Methods

            // RVA: 0x1F22D14 Offset: 0x1F22D14 VA: 0x1F22D14
            public ConfigFetchFailed(Exception exeption, FailureSource source)
            {
                Exception = exeption;
                Source = source;
            }

            public enum FailureSource
            {
                ResourceFetch = 0,
                Activation = 1
            }
        }

        public sealed class ClusterNotReady : TransientError
        {
            public readonly ClusterStatus Reason; // 0x10

            public ClusterNotReady(ClusterStatus reason)
            {
                Reason = reason;
            }

            public enum ClusterStatus
            {
                ClusterStarting = 0,
                ClusterShuttingDown = 1
            }
        }

        public sealed class SessionForceTerminated : TransientError
        {
            public SessionForceTerminateReason Reason { get; }

            public SessionForceTerminated(SessionForceTerminateReason reason)
            {
                Reason = reason;
            }
        }

        public sealed class ProtocolError : TransientError
        {
            public ErrorKind Kind { get; }
            public string Message { get; }

            public ProtocolError(ErrorKind kind, string message)
            {
                Kind = kind;
                Message = message;
            }

            public enum ErrorKind
            {
                UnexpectedLoginMessage = 0,
                MissingServerHello = 1,
                SessionStartFailed = 2,
                SessionProtocolError = 3
            }
        }

        public sealed class InternalWatchdogDeadlineExceeded : TransientError
        {
            public ConnectionInternalWatchdogType WatchdogType { get; }

            public InternalWatchdogDeadlineExceeded(ConnectionInternalWatchdogType watchdogType)
            {
                WatchdogType = watchdogType;
            }
        }
    }
}

namespace Metaplay.Core.Message
{
    public abstract class SessionForceTerminateReason
    {
        public class MaintenanceModeStarted : SessionForceTerminateReason
        { }

        public class PauseDeadlineExceeded : SessionForceTerminateReason
        { }
    }
}

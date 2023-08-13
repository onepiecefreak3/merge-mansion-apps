using Metaplay.Core.Model;

namespace Metaplay.Core.Message
{
    [MetaSerializable]
    public abstract class SessionForceTerminateReason
    {
        [MetaSerializableDerived(9)]
        public class MaintenanceModeStarted : SessionForceTerminateReason
        {
            public MaintenanceModeStarted()
            {
            }
        }

        [MetaSerializableDerived(10)]
        public class PauseDeadlineExceeded : SessionForceTerminateReason
        {
            public PauseDeadlineExceeded()
            {
            }
        }

        [MetaSerializableDerived(1)]
        public class ReceivedAnotherConnection : SessionForceTerminateReason
        {
            public ReceivedAnotherConnection()
            {
            }
        }

        protected SessionForceTerminateReason()
        {
        }

        [MetaSerializableDerived(2)]
        public class KickedByAdminAction : SessionForceTerminateReason
        {
            public KickedByAdminAction()
            {
            }
        }

        [MetaSerializableDerived(3)]
        public class InternalServerError : SessionForceTerminateReason
        {
            public InternalServerError()
            {
            }
        }

        [MetaSerializableDerived(4)]
        public class Unknown : SessionForceTerminateReason
        {
            public Unknown()
            {
            }
        }

        [MetaSerializableDerived(5)]
        public class ClientTimeTooFarBehind : SessionForceTerminateReason
        {
            public ClientTimeTooFarBehind()
            {
            }
        }

        [MetaSerializableDerived(6)]
        public class ClientTimeTooFarAhead : SessionForceTerminateReason
        {
            public ClientTimeTooFarAhead()
            {
            }
        }

        [MetaSerializableDerived(7)]
        public class SessionTooLong : SessionForceTerminateReason
        {
            public SessionTooLong()
            {
            }
        }

        [MetaSerializableDerived(8)]
        public class PlayerBanned : SessionForceTerminateReason
        {
            public PlayerBanned()
            {
            }
        }

        [MetaSerializableDerived(100)]
        public class PlayerInitiatedReset : SessionForceTerminateReason
        {
            public PlayerInitiatedReset()
            {
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core.Message
{
    public abstract class SessionForceTerminateReason
    {
        public class MaintenanceModeStarted : SessionForceTerminateReason
        { }

        public class PauseDeadlineExceeded : SessionForceTerminateReason
        { }
    }
}

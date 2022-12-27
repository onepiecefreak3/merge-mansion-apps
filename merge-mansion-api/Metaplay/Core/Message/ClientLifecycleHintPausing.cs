using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core.Message
{
    [MetaMessage(17300, MessageDirection.ClientToServer, false)]
    public class ClientLifecycleHintPausing : MetaMessage
    {
        public MetaDuration? MaxPauseDuration { get; set; }
        public string PauseReason { get; set; }

        public ClientLifecycleHintPausing()
        {
        }

        public ClientLifecycleHintPausing(MetaDuration? maxPauseDuration, string pauseReason)
        {
            MaxPauseDuration = maxPauseDuration;
            PauseReason = pauseReason;
        }
    }
}

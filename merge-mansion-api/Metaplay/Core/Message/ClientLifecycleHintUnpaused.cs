using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core.Message
{
    [MetaMessage(17302, MessageDirection.ClientToServer, false)]
    public class ClientLifecycleHintUnpaused : MetaMessage
    {
    }
}

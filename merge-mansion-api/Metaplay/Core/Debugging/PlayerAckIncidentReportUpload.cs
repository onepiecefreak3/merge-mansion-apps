using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core.Debugging
{
    [MetaMessage(1023, MessageDirection.ServerToClient, false)]
    public class PlayerAckIncidentReportUpload : MetaMessage
    {
    }
}

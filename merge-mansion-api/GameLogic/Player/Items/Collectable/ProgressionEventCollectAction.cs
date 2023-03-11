using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(6)]
    public class ProgressionEventCollectAction : IProgressCollectAction
    {
        [MetaMember(1)]
        private MetaRef<ProgressionEventInfo> ProgressionEventRef { get; set; }
        [MetaMember(2)]
        public int Progress { get; set; }
    }
}

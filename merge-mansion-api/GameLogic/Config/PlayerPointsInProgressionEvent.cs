using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Player;

namespace Metaplay.GameLogic.Config
{
    [MetaSerializableDerived(1031)]
    [MetaSerializable]
    public class PlayerPointsInProgressionEvent : TypedPlayerPropertyId<int>
    {
        [MetaMember(1, 0)]
        private ProgressionEventId Event { get; set; }
    }
}

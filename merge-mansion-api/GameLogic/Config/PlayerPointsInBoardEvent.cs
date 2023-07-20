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
    [MetaSerializableDerived(1030)]
    [MetaSerializable]
    public class PlayerPointsInBoardEvent : TypedPlayerPropertyId<int>
    {
        [MetaMember(1, 0)]
        private EventId EventId { get; set; }
    }
}

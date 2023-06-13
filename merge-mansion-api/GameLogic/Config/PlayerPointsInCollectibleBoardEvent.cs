using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Player;

namespace merge_mansion_api.GameLogic.Config
{
    [MetaSerializableDerived(1032)]
    public class PlayerPointsInCollectibleBoardEvent : TypedPlayerPropertyId<int>
    {
        [MetaMember(1, 0)]
        private CollectibleBoardEventId EventId { get; set; }
    }
}

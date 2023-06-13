using Metaplay.Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using merge_mansion_api.Code.GameLogic.GameEvents;
using Metaplay.Metaplay.Core.Player;

namespace merge_mansion_api.GameLogic.Config
{
    [MetaSerializableDerived(1033)]
    public class PlayerPointsInLeaderboardEvent : TypedPlayerPropertyId<int>
    {
        [MetaMember(1, 0)]
        private LeaderboardEventId EventId { get; set; }
    }
}

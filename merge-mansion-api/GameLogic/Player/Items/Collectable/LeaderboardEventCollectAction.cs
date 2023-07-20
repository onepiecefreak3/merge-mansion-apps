using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.GameLogic.Player.Items.Collectable;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(8)]
    [MetaSerializable]
    public class LeaderboardEventCollectAction : IProgressCollectAction
    {
        [MetaMember(1, 0)]
        private MetaRef<LeaderboardEventInfo> LeaderboardEventRef { get; set; }
        [MetaMember(2, 0)]
        public int Progress { get; set; }
    }
}

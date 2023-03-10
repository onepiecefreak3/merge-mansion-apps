using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Sink
{
    [MetaSerializableDerived(2)]
    public class SingleTargetSinkStateFactory : ISinkStateFactory
    {
        [MetaMember(1, 0)]
        public Dictionary<ItemType, int> Scores { get; set; }
        [MetaMember(2, 0)]
        public int ScoreTarget { get; set; }
        [MetaMember(3, 0)]
        public MetaRef<ItemDefinition> Reward { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Sink
{
    [MetaSerializableDerived(3)]
    public class MultiTargetSinkStateFactory : ISinkStateFactory
    {
        [MetaMember(1, 0)]
        public Dictionary<ItemTypeConstant, int> ScoreTargets { get; set; }
        [MetaMember(2, 0)]
        public MetaRef<ItemDefinition> Reward { get; set; }
    }
}

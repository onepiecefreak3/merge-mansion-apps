using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.MergeChains;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Requirements
{
    [MetaSerializableDerived(12)]
    public class MergeChainItemNeededRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        private MetaRef<MergeChainDefinition> MergeChainRef { get; set; }
        [MetaMember(2, 0)]
        private Nullable<int> MinLevel { get; set; }
        [MetaMember(3, 0)]
        private Nullable<int> MaxLevel { get; set; }
    }
}

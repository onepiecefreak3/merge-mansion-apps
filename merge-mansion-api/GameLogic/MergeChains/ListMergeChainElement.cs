using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Player.Items;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.MergeChains
{
    [MetaSerializableDerived(2)]
    public class ListMergeChainElement : IMergeChainElement
    {
        [MetaMember(1, 0)]
        public List<MetaRef<ItemDefinition>> Items { get; set; }
    }
}

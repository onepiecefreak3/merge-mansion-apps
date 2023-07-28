using System.Collections.Generic;
using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.MergeChains
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
    public class ListMergeChainElement : IMergeChainElement
    {
        [MetaMember(1, 0)]
        public List<MetaRef<ItemDefinition>> Items { get; set; }
    }
}

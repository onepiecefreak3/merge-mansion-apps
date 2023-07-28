using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.MergeChains
{
    [MetaSerializableDerived(1)]
    [MetaSerializable]
    public class SingleMergeChainElement : IMergeChainElement
    {
        [MetaMember(1, 0)]
        public MetaRef<ItemDefinition> Item { get; set; }
    }
}

using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;
using System;

namespace GameLogic.MergeChains
{
    [MetaSerializableDerived(1)]
    [MetaSerializable]
    public class SingleMergeChainElement : IMergeChainElement
    {
        [MetaMember(1, 0)]
        public MetaRef<ItemDefinition> Item { get; set; }

        private SingleMergeChainElement()
        {
        }

        public SingleMergeChainElement(int type)
        {
        }

        public SingleMergeChainElement(MetaRef<ItemDefinition> item)
        {
        }

        public ItemDefinition First()
        {
            return Item.Ref;
        }
    }
}
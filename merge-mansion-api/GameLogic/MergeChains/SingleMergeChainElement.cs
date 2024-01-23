using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;
using System;

namespace GameLogic.MergeChains
{
    [MetaSerializableDerived(1)]
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

        public int IndexOf(int itemId)
        {
            return Contains(itemId) ? 0 : -1;
        }

        public bool Contains(int itemId)
        {
            return (int)Item.KeyObject == itemId;
        }

        public ItemDefinition First()
        {
            return Item.Ref;
        }

        public ItemDefinition ElementAtOrDefault(int index)
        {
            if (index != 0)
                return null;
            return Item.Ref;
        }

        public int Count { get; }
    }
}
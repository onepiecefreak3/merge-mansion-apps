using System.Collections.Generic;
using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;
using System;
using System.Linq;

namespace GameLogic.MergeChains
{
    [MetaSerializableDerived(2)]
    public class ListMergeChainElement : IMergeChainElement
    {
        [MetaMember(1, 0)]
        public List<MetaRef<ItemDefinition>> Items { get; set; }

        public int IndexOf(int itemId)
        {
            return Items.FindIndex(item => (int)item.KeyObject == itemId);
        }

        public bool Contains(int itemId)
        {
            return IndexOf(itemId) != -1;
        }

        public ItemDefinition First()
        {
            return Items.FirstOrDefault()?.Ref;
        }

        public ItemDefinition ElementAtOrDefault(int index)
        {
            return Items.ElementAtOrDefault(index)?.Ref;
        }

        private ListMergeChainElement()
        {
        }

        public ListMergeChainElement(IEnumerable<int> types)
        {
        }

        public ListMergeChainElement(IEnumerable<MetaRef<ItemDefinition>> items)
        {
        }

        public int Count { get; }
    }
}
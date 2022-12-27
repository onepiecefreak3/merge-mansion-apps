using System;
using System.Collections.Generic;
using Metaplay.GameLogic.Player.Items.Production;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Merge
{
    public class MergeCollection
    {
        [MetaMember(1)]
        public Dictionary<ItemPair, IItemProducer> Collection { get; set; }

        public bool ContainsPair((ItemType, ItemType) pair)
        {
            var search=new ItemPair{First = pair.Item1,Second = pair.Item2};

            // TODO: Implement Equals and GetHashCode for ItemPair
            return Collection.ContainsKey(search);
        }

        public class ItemPair
        {
            [MetaMember(1)]
            public ItemType First { get; set; }
            [MetaMember(2)]
            public ItemType Second { get; set; }
        }
    }
}

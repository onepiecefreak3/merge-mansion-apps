using System.Collections.Generic;
using GameLogic.Player.Items.Production;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Merge
{
    [MetaSerializable]
    public class MergeCollection
    {
        [MetaMember(1)]
        public Dictionary<ItemPair, IItemProducer> Collection { get; set; }

        public bool ContainsPair((int, int) pair)
        {
            var search = new ItemPair
            {
                First = pair.Item1,
                Second = pair.Item2
            };
            // TODO: Implement Equals and GetHashCode for ItemPair
            return Collection.ContainsKey(search);
        }

        [MetaSerializable]
        public class ItemPair
        {
            [MetaMember(1)]
            public int First { get; set; }

            [MetaMember(2)]
            public int Second { get; set; }

            public ItemPair()
            {
            }

            public ItemPair(int first, int second)
            {
            }
        }

        public MergeCollection()
        {
        }

        public MergeCollection(IEnumerable<ValueTuple<int, int, IItemProducer>> list)
        {
        }

        public MergeCollection(ValueTuple<int, int, IItemProducer>[] list)
        {
        }
    }
}
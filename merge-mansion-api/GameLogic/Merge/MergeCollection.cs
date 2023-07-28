using System.Collections.Generic;
using GameLogic.Player.Items.Production;
using Metaplay.Core.Model;

namespace GameLogic.Merge
{
    [MetaSerializable]
    public class MergeCollection
    {
        [MetaMember(1)]
        public Dictionary<ItemPair, IItemProducer> Collection { get; set; }

        public bool ContainsPair((ItemTypeConstant, ItemTypeConstant) pair)
        {
            var search=new ItemPair{First = pair.Item1,Second = pair.Item2};

            // TODO: Implement Equals and GetHashCode for ItemPair
            return Collection.ContainsKey(search);
        }

        [MetaSerializable]

        public class ItemPair
        {
            [MetaMember(1)]
            public ItemTypeConstant First { get; set; }
            [MetaMember(2)]
            public ItemTypeConstant Second { get; set; }
        }
    }
}

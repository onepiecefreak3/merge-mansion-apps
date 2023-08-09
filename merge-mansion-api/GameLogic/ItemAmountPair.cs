using Metaplay.Core.Model;
using System;

namespace GameLogic
{
    [MetaSerializable]
    public class ItemAmountPair
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int itemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int amount { get; set; }

        public ItemAmountPair()
        {
        }
    }
}
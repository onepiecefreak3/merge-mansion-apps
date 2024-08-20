using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Order
{
    [MetaSerializable]
    public class OrderStateReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ItemDefinition Item { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Claimed { get; set; }

        public OrderStateReward()
        {
        }

        public OrderStateReward(ItemDefinition item, int amount, int claimed)
        {
        }
    }
}
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Order
{
    [MetaSerializable]
    public class OrderParentState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public IOrderState CurrentOrder { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int CurrentOrderIndex { get; set; }

        public OrderParentState()
        {
        }

        public OrderParentState(IOrderState currentOrder)
        {
        }
    }
}
using GameLogic.Player.Items.Sink;
using GameLogic.Player.Items.Production;
using System.Collections.Generic;
using System;

namespace GameLogic.Player.Items.Order
{
    public interface IOrderState : ISinkState, IItemProducer
    {
        IEnumerable<OrderStateReward> CompletionItems { get; }

        int ClaimableRewardsCount { get; }

        int ItemsPerActivation { get; }
    }
}
using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using GameLogic.Random;

namespace GameLogic.Player.Items.Order
{
    [MetaSerializableDerived(20)]
    public class SingleTargetOrderState : OrderState
    {
        public SingleTargetOrderState()
        {
        }

        public SingleTargetOrderState(Dictionary<int, int> takeIn, List<int> rewardItems, List<int> rewardAmounts, string activationType, IGenerationContext context)
        {
        }
    }
}
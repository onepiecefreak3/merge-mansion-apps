using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using GameLogic.Random;

namespace GameLogic.Player.Items.Order
{
    [MetaSerializableDerived(21)]
    public class MultiTargetOrderState : OrderState
    {
        public MultiTargetOrderState()
        {
        }

        public MultiTargetOrderState(Dictionary<int, int> takeIn, List<int> rewardItems, List<int> rewardAmounts, string activationType, IGenerationContext context)
        {
        }
    }
}
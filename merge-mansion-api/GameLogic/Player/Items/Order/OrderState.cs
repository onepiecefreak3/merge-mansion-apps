using GameLogic.Player.Items.Sink;
using GameLogic.Player.Items.Production;
using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GameLogic.Random;

namespace GameLogic.Player.Items.Order
{
    public abstract class OrderState : IOrderState, ISinkState, IItemProducer
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        protected Dictionary<int, ValueTuple<int, int>> TakeInScores { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private List<OrderStateReward> RewardItems { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private string ActivationType { get; set; }
        public IEnumerable<OrderStateReward> CompletionItems { get; }

        [IgnoreDataMember]
        public int ClaimableRewardsCount { get; }

        [IgnoreDataMember]
        public int ItemsPerActivation { get; }
        public IEnumerable<ValueTuple<ItemDefinition, int>> Odds { get; }

        protected OrderState()
        {
        }

        protected OrderState(Dictionary<int, int> takeIn, List<int> rewardItems, List<int> rewardAmounts, string activationType, IGenerationContext context)
        {
        }

        public IEnumerable<ItemDefinition> Produce(IGenerationContext context, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
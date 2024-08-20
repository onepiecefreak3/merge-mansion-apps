using Metaplay.Core.Model;
using GameLogic.Player.Items.Order;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializableDerived(1)]
    public class SingleTargetOrderStateFactory : IOrderStateFactory
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private Dictionary<int, int> Scores { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private List<int> RewardItems { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private List<int> RewardAmounts { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private string ActivationType { get; set; }

        private SingleTargetOrderStateFactory()
        {
        }

        public SingleTargetOrderStateFactory(Dictionary<int, int> scores, Dictionary<int, int> rewards, string activationType)
        {
        }
    }
}
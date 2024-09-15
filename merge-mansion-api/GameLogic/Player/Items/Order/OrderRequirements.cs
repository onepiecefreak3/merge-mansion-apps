using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Items.Order
{
    [MetaSerializable]
    public class OrderRequirements : IGameConfigData<OrderRequirementsId>, IGameConfigData, IHasGameConfigKey<OrderRequirementsId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public OrderRequirementsId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string SinkFactoryType { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public Dictionary<int, int> SinkItemsAndAmounts { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string ActivationType { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public Dictionary<int, int> ActivationRewardsAndAmounts { get; set; }

        public OrderRequirements()
        {
        }

        public OrderRequirements(OrderRequirementsId configKey, string sinkFactoryType, List<ValueTuple<int, int>> sinkItems, string activationType, List<ValueTuple<int, int>> activationRewards)
        {
        }
    }
}
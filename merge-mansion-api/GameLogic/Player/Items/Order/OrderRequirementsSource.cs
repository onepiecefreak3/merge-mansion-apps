using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Player.Items.Order
{
    public class OrderRequirementsSource : IConfigItemSource<OrderRequirements, OrderRequirementsId>, IGameConfigSourceItem<OrderRequirementsId, OrderRequirements>, IHasGameConfigKey<OrderRequirementsId>
    {
        public OrderRequirementsId ConfigKey { get; set; }
        private string FactoryType { get; set; }
        private string Scores { get; set; }
        private string ActivationType { get; set; }
        private string ActivationRewards { get; set; }

        public OrderRequirementsSource()
        {
        }
    }
}
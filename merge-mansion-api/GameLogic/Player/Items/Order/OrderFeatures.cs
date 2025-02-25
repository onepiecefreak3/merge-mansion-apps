using Metaplay.Core.Model;
using System;
using GameLogic.Player.Items.Production;
using GameLogic.Player.Board.Placement;
using GameLogic.Merge;

namespace GameLogic.Player.Items.Order
{
    [MetaSerializable]
    public class OrderFeatures : IOrderFeatures
    {
        public static OrderFeatures NoOrder;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsOrder { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public IOrderProducer OrderProducer { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public bool HideRequirementsPhaseProgressBar { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public IPlacement RewardsPlacement { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public ItemVisibility RewardsItemVisibility { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public IItemProducer DecayProducer { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public OrderItemDecayLogic DecayLogic { get; set; }

        private OrderFeatures()
        {
        }

        public OrderFeatures(bool isOrder, bool hideRequirementsPhaseProgressBar, IItemProducer decayProducer, IOrderSpawner orderProducer, OrderItemDecayLogic decayLogic)
        {
        }
    }
}
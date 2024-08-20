using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using GameLogic.Player.Items.Order;
using System.Runtime.Serialization;

namespace GameLogic.Player.Items.Production
{
    [MetaSerializableDerived(1)]
    public class ConstantOrderProducer : IOrderSpawner, IOrderProducer
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private RollHistoryType RollType { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private int ItemType { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private List<ValueTuple<OrderRequirementsId, int>> GenerationOdds { get; set; }

        [IgnoreDataMember]
        public int OrderCount { get; }

        private ConstantOrderProducer()
        {
        }

        public ConstantOrderProducer(RollHistoryType rollType, int itemType, IEnumerable<ValueTuple<OrderRequirementsId, int>> pairs)
        {
        }
    }
}
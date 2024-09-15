using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using GameLogic.Player.Items.Order;
using System.Runtime.Serialization;

namespace GameLogic.Player.Items.Production
{
    [MetaSerializableDerived(4)]
    public class ControlledRandomOrderProducer : IOrderSpawner, IOrderProducer
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public RollHistoryType RollType { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int ItemType { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<ValueTuple<OrderRequirementsId, int>> GenerationOdds { get; set; }

        [IgnoreDataMember] 
        public int OrderCount => GenerationOdds.Count;

        private ControlledRandomOrderProducer()
        {
        }

        public ControlledRandomOrderProducer(RollHistoryType rollType, int itemId, List<ValueTuple<OrderRequirementsId, int>> oddsList)
        {
        }
    }
}
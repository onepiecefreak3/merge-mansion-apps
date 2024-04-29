using Metaplay.Core.Model;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization;
using GameLogic.Random;
using Metaplay.Core.Math;

namespace GameLogic.Player.Items.Production
{
    [MetaSerializableDerived(14)]
    public class MixedSequenceProducer : IItemSpawner, IItemProducer
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private List<ItemOdds> OddsList { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private int TotalCount { get; set; }

        [IgnoreDataMember]
        public IEnumerable<ValueTuple<ItemDefinition, int>> Odds { get; }

        public IEnumerable<ItemDefinition> Produce(IGenerationContext context, int quantity)
        {
            throw new NotImplementedException();
        }

        public int SpawnQuantity { get; }

        public F64 TimeSkipPriceGems(IGenerationContext context)
        {
            throw new NotImplementedException();
        }

        private MixedSequenceProducer()
        {
        }

        public MixedSequenceProducer(IEnumerable<ValueTuple<int, int>> oddsList)
        {
        }
    }
}
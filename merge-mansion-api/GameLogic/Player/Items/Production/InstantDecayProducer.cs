using Metaplay.Core.Model;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System;
using GameLogic.Random;
using Metaplay.Core.Math;

namespace GameLogic.Player.Items.Production
{
    [MetaSerializableDerived(19)]
    public class InstantDecayProducer : IItemSpawner, IItemProducer
    {
        [IgnoreDataMember]
        public IEnumerable<ValueTuple<ItemDefinition, int>> Odds { get; }
        public int SpawnQuantity { get; }

        public InstantDecayProducer()
        {
        }

        public IEnumerable<ItemDefinition> Produce(IGenerationContext context, int quantity)
        {
            throw new NotImplementedException();
        }

        public F64 TimeSkipPriceGems(IGenerationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
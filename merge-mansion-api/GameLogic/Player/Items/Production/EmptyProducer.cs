using System;
using System.Collections.Generic;
using System.Linq;
using GameLogic.Random;
using Metaplay.Core.Math;
using Metaplay.Core.Model;
using System.Runtime.Serialization;

namespace GameLogic.Player.Items.Production
{
    [MetaAllowNoSerializedMembers]
    [MetaSerializableDerived(10)]
    public class EmptyProducer : IItemSpawner, IItemProducer
    {
        [IgnoreDataMember]
        public IEnumerable<(ItemDefinition, int)> Odds => Array.Empty<(ItemDefinition, int)>();
        public int SpawnQuantity => 0;

        public F64 TimeSkipPriceGems(IGenerationContext context)
        {
            return new F64(0);
        }

        public IEnumerable<ItemDefinition> Produce(IGenerationContext context, int quantity)
        {
            return Enumerable.Empty<ItemDefinition>();
        }

        public EmptyProducer()
        {
        }
    }
}
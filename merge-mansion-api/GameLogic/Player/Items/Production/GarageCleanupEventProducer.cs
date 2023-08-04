using System;
using System.Collections.Generic;
using GameLogic.Random;
using Metaplay.Core.Math;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Production
{
    [MetaSerializableDerived(12)]
    public class GarageCleanupEventProducer : IItemSpawner, IItemProducer
    {
        public IEnumerable<(ItemDefinition, int)> Odds => Array.Empty<(ItemDefinition, int)>();
        public int SpawnQuantity => 1;

        public F64 TimeSkipPriceGems(IGenerationContext context)
        {
            // STUB
            return F64.FromInt(0);
        }

        public IEnumerable<ItemDefinition> Produce(IGenerationContext context, int quantity)
        {
            // STUB
            throw new NotImplementedException();
        }

        public GarageCleanupEventProducer()
        {
        }
    }
}
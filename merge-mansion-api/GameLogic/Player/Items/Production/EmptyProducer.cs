using System;
using System.Collections.Generic;
using System.Linq;
using Metaplay.GameLogic.Random;
using Metaplay.Metaplay.Core.Math;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Production
{
    [MetaSerializableDerived(10)]
    public class EmptyProducer : IItemSpawner
    {
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
    }
}

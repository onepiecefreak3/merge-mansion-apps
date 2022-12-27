using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Random;
using Metaplay.Metaplay.Core.Math;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Production
{
    [MetaSerializableDerived(12)]
    public class GarageCleanupEventProducer : IItemSpawner
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
    }
}

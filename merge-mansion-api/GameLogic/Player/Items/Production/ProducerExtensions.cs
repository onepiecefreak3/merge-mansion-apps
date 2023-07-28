using System;
using System.Collections.Generic;
using System.Linq;
using GameLogic.Random;
using Metaplay.Core.Math;

namespace GameLogic.Player.Items.Production
{
    public static class ProducerExtensions
    {
        public static ItemDefinition Produce(this IItemProducer producer, IGenerationContext context)
        {
            // TODO: Implement ItemDefinition production
            return null;
        }

        public static F64 Average(this ICollection<ItemOdds> itemOdds, Func<ItemOdds, F64> view)
        {
            var totalWeight = itemOdds.Sum(odds => odds.Weight);
            var aggregated = itemOdds.Aggregate(F64.Zero, (res, odds) => res + view(odds) * odds.Weight);

            return aggregated / totalWeight;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using GameLogic.Random;
using Metaplay.Core.Math;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Production
{
    [MetaSerializableDerived(2)]
    public class RandomProducer : IItemSpawner, IItemProducer
    {
        [MetaMember(1)]
        public List<ItemOdds> OddsList { get; set; }
        public IEnumerable<(ItemDefinition, int)> Odds => OddsList.Select(x => (x.Type.Ref, x.Weight));
        public int SpawnQuantity => 1;

        public F64 TimeSkipPriceGems(IGenerationContext context)
        {
            return F64.FromDouble(OddsList.Average(odds => odds.Type.Ref.TimeSkipPriceGems.Double));
        }

        public IEnumerable<ItemDefinition> Produce(IGenerationContext context, int quantity)
        {
            // STUB
            yield break;
        }

        private RandomProducer()
        {
        }

        public RandomProducer(List<ValueTuple<int, int>> oddsList)
        {
        }
    }
}
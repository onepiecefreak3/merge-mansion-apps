using System.Collections.Generic;
using System.Linq;
using GameLogic.Random;
using Metaplay.Core.Math;
using Metaplay.Core.Model;
using System;
using System.Runtime.Serialization;

namespace GameLogic.Player.Items.Production
{
    [MetaSerializableDerived(2)]
    public class RandomProducer : IItemSpawner, IItemProducer
    {
        [MetaMember(1)]
        private List<ItemOdds> OddsList { get; set; }

        [IgnoreDataMember]
        public IEnumerable<(ItemDefinition, int)> Odds => OddsList.Select(x => (x.Item, x.Weight));
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
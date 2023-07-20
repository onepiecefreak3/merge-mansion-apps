using System;
using System.Collections.Generic;
using System.Linq;
using Metaplay.GameLogic.Random;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Math;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Production
{
    [MetaSerializableDerived(11)]
    [MetaSerializable]
    public class PrefixProducer : IItemSpawner
    {
        [MetaMember(1)]
        public string Marker { get; set; } // 0x10
        [MetaMember(2)]
        private List<MetaRef<ItemDefinition>> Items { get; set; }   // 0x18
        [MetaMember(3)]
        public IItemSpawner BaseProducer { get; set; } // 0x20

        public int SpawnQuantity => BaseProducer.SpawnQuantity;
        public IEnumerable<(ItemDefinition, int)> Odds => BaseProducer.Odds;

        public IEnumerable<ItemDefinition> Produce(IGenerationContext context, int quantity)
        {
            if (Items == null)
                throw new ArgumentNullException(nameof(Items));

            if (BaseProducer == null)
                throw new ArgumentNullException(nameof(BaseProducer));

            var markerIndex = context.SpawnState.GetIndexOf(Marker);
            var start = Items.Count - markerIndex;
            if (start == 0 || Items.Count < markerIndex)
                return BaseProducer.Produce(context, quantity);

            // Produce n items here, and afterwards produce remaining quantity in base producer
            var maxStart = Math.Max(start, 0);
            var localQuantity = Math.Min(quantity, maxStart);
            var remainingQuantity = Math.Max(quantity - localQuantity, 0);

            return Enumerable.Range(markerIndex, localQuantity).Select(x =>
            {
                context.SpawnState.IncreaseIndexOf(Marker);
                return Items[x].Deref();
            }).Concat(BaseProducer.Produce(context, remainingQuantity));
        }

        public F64 TimeSkipPriceGems(IGenerationContext context)
        {
            return BaseProducer.TimeSkipPriceGems(context);
        }
    }
}

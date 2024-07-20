using System;
using System.Collections.Generic;
using System.Linq;
using Game.Logic;
using GameLogic.Random;
using Metaplay.Core;
using Metaplay.Core.Math;
using Metaplay.Core.Model;
using System.Runtime.Serialization;

namespace GameLogic.Player.Items.Production
{
    [MetaSerializableDerived(1)]
    public class ConstantProducer : IItemSpawner, IItemProducer
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<MetaRef<ItemDefinition>> Products { get; set; } // 0x10

        [MetaMember(2)]
        public List<int> Quantities { get; set; } // 0x18
        public IEnumerable<(ItemDefinition, int)> Odds => Products.Select(x => (x.Ref, 1));
        public int SpawnQuantity => Quantities.Sum();

        public F64 TimeSkipPriceGems(IGenerationContext context)
        {
            var totalPrice = Products.Aggregate(F64.Zero, (res, item) => res + item.Ref.TimeSkipPriceGems);
            return totalPrice / Math.Max(Products.Count, 1);
        }

        public IEnumerable<ItemDefinition> Produce(IGenerationContext context, int quantity)
        {
            foreach (var product in Products.CycleWithIndex())
            {
                var localQuantity = Quantities[product.Item2];
                var itemQuantity = Math.Min(quantity, localQuantity);
                quantity -= itemQuantity;
                for (var i = 0; i < itemQuantity; i++)
                    yield return product.Item1.Deref();
                if (quantity < 1)
                    yield break;
            }
        }

        private ConstantProducer()
        {
        }

        public ConstantProducer(int products, int spawnQuantity)
        {
        }

        public ConstantProducer(IEnumerable<int> products)
        {
        }

        public ConstantProducer(IEnumerable<ValueTuple<int, int>> pairs)
        {
        }
    }
}
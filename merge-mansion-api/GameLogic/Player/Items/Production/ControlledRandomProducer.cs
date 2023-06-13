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
    [MetaSerializableDerived(4)]
    public class ControlledRandomProducer : IItemSpawner
    {
        [MetaMember(1)]
        public RollHistoryType RollType { get; set; }   // 0x10
        [MetaMember(2)]
        public ItemTypeConstant ItemType { get; set; }  // 0x14
        [MetaMember(3)]
        public List<ItemOdds> GenerationOdds { get; set; }  // 0x18

        public IEnumerable<(ItemDefinition, int)> Odds => GenerationOdds.Select(x => (x.Type.Ref, x.Weight));

        public int SpawnQuantity => 1;

        public F64 TimeSkipPriceGems(IGenerationContext context)
        {
            return GenerationOdds.Average(odds => odds.Type.Ref.TimeSkipPriceGems);
        }

        public IEnumerable<ItemDefinition> Produce(IGenerationContext context, int quantity)
        {
            return Enumerable.Range(0, quantity).Select(_ =>
            {
                var itemWeights = GenerationOdds.Select(y => (y.Type.Deref().ConfigKey, y.Weight)).ToList();

                var distribution = context.DistributionStates;
                var random = context.Random;

                var itemIndex = distribution.Roll(RollType, ItemType, itemWeights, random);
                return GenerationOdds[itemIndex].Type.Deref();
            });
        }
    }
}

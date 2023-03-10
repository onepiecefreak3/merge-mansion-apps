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
    [MetaSerializableDerived(2)]
    public class RandomProducer : IItemSpawner
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
    }
}

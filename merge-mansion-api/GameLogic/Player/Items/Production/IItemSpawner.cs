using System.Collections.Generic;
using Metaplay.GameLogic.Random;
using Metaplay.Metaplay.Core.Math;

namespace Metaplay.GameLogic.Player.Items.Production
{
    public interface IItemSpawner : IItemProducer
    {
        int SpawnQuantity { get; }

        F64 TimeSkipPriceGems(IGenerationContext context);
    }
}

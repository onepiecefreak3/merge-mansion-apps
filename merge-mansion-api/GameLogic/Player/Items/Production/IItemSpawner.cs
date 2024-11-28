using GameLogic.Random;
using Metaplay.Core.Math;
using System;

namespace GameLogic.Player.Items.Production
{
    public interface IItemSpawner : IItemProducer
    {
        int SpawnQuantity { get; }

        F64 TimeSkipPriceGems(IGenerationContext context);
    }
}
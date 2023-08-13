using System;
using System.Collections.Generic;
using GameLogic.Random;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Production
{
    [MetaSerializable]
    public interface IItemProducer
    {
        // Slot 0
        IEnumerable<ValueTuple<ItemDefinition, int>> Odds { get; }

        // Slot 1
        IEnumerable<ItemDefinition> Produce(IGenerationContext context, int quantity);
    }
}
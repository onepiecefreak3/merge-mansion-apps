using System;
using System.Collections.Generic;
using Metaplay.GameLogic.Random;

namespace Metaplay.GameLogic.Player.Items.Production
{
    public interface IItemProducer
    {
        // Slot 0
        IEnumerable<ValueTuple<ItemDefinition, int>> Odds { get; }

        // Slot 1
        IEnumerable<ItemDefinition> Produce(IGenerationContext context, int quantity);
    }
}

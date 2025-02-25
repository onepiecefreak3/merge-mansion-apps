using Metaplay.Core;
using System;

namespace GameLogic.Player.Items.Bubble
{
    public interface IBubbleFeatures
    {
        MetaDuration BubbleDuration { get; }

        Currencies OpenCurrency { get; }

        int OpenQuantity { get; }

        int SpawnOdds { get; }

        ItemDefinition Replacement { get; }

        ValueTuple<Currencies, int> OpenCost { get; }
    }
}
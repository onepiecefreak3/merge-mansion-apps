using System;
using GameLogic.Player.Items.Consumption.Logic;

namespace GameLogic.Player.Items.Consumption
{
    public interface IConsumableFeatures
    {
        bool IsConsumable { get; }

        IConsumptionLogic Logic { get; }

        bool AllowNearMatching { get; }

        bool DragSafeAreaEnabled { get; }

        int ItemStackCap { get; }

        bool CanSpawnBubbles { get; }
    }
}
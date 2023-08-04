using System;

namespace GameLogic.Player.Items.Consumption
{
    public interface IConsumptionCheckResult
    {
        bool Success { get; }

        string ErrorLocKey { get; }
    }
}
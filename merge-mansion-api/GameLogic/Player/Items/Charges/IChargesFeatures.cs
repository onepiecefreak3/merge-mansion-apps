using System;

namespace GameLogic.Player.Items.Charges
{
    public interface IChargesFeatures
    {
        bool SupportsCharges { get; }

        int DefaultInitialCharges { get; }

        ChargeMergeBehavior MergeBehavior { get; }
    }
}
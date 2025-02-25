using System;
using GameLogic.Player.Board.Placement;
using GameLogic.Merge;
using GameLogic.Player.Items.Production;

namespace GameLogic.Player.Items.Order
{
    public interface IOrderFeatures
    {
        bool IsOrder { get; }

        bool HideRequirementsPhaseProgressBar { get; }

        IPlacement RewardsPlacement { get; }

        ItemVisibility RewardsItemVisibility { get; }

        IItemProducer DecayProducer { get; }
    }
}
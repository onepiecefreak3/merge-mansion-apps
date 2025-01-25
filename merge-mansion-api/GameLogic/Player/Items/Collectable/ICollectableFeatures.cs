using System;

namespace GameLogic.Player.Items.Collectable
{
    public interface ICollectableFeatures
    {
        bool Collectable { get; }

        ICollectAction CollectAction { get; }

        bool ConfirmCollectBelowMergeChainLevel { get; }
    }
}
using GameLogic.Player.Items.Production;
using System;

namespace GameLogic.Player.Items.Merging
{
    public interface IMergeFeatures
    {
        IMergeMechanic Mechanic { get; }

        IItemProducer AdditionalSpawnProducer { get; }

        bool Mergeable { get; }

        bool RequiresXpState { get; }
    }
}
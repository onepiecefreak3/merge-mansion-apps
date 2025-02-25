using GameLogic.Player.Items.Production;
using GameLogic.Player.Board.Placement;
using System;
using GameLogic.Merge;

namespace GameLogic.Player.Items.Spawning
{
    public interface ISpawnFeatures
    {
        IItemSpawner Spawn { get; }

        IPlacement Placement { get; }

        ISpawnCycle SpawnCycle { get; }

        int StorageMax { get; }

        IItemProducer DecayProducer { get; }

        ItemVisibility SpawnVisibility { get; }

        bool Spawnable { get; }

        bool DecaysWhenCyclesAreDone { get; }
    }
}
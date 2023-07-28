using Code.GameLogic.GameEvents;
using Game.Logic;
using GameLogic.Config;
using GameLogic.Player;
using Metaplay.Core;

namespace GameLogic.Random
{
    public interface IGenerationContext
    {
        // Slot 0
        Statistics Statistics { get; }
        // Slot 1
        WeightedDistributionStates DistributionStates { get; }
        // Slot 2
        SpawnFactoryState SpawnState { get; }
        // Slot 3
        RandomPCG Random { get; }
        // Slot 4
        SharedGameConfig GameConfig { get; }
        // Slot 5
        GarageCleanupEventModel GarageCleanupEventModel { get; }
    }
}

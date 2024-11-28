using Code.GameLogic.GameEvents;
using Game.Logic;
using GameLogic.Config;
using GameLogic.Player;
using Metaplay.Core;

namespace GameLogic.Random
{
    public interface IGenerationContext
    {
        Statistics Statistics { get; }

        WeightedDistributionStates DistributionStates { get; }

        SpawnFactoryState SpawnState { get; }

        RandomPCG Random { get; }

        SharedGameConfig GameConfig { get; }

        GarageCleanupEventModel GarageCleanupEventModel { get; }
    }
}
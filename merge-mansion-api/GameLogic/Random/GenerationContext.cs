using Code.GameLogic.GameEvents;
using Game.Logic;
using GameLogic.Config;
using GameLogic.Player;
using Metaplay.Core;

namespace GameLogic.Random
{
    public class GenerationContext : IGenerationContext
    {
        public Statistics Statistics { get; }
        public WeightedDistributionStates DistributionStates { get; }
        public SpawnFactoryState SpawnState { get; }
        public RandomPCG Random { get; }
        public SharedGameConfig GameConfig { get; }
        public GarageCleanupEventModel GarageCleanupEventModel { get; }

        public GenerationContext(IPlayer player, GarageCleanupEventModel garageCleanupEventModel)
        {
            Statistics = player.Statistics;
            DistributionStates =player.DistributionStates;
            SpawnState=player.SpawnFactoryState;
            Random=player.Random;
            GameConfig = player.GameConfig;
            GarageCleanupEventModel = garageCleanupEventModel;
        }
    }
}

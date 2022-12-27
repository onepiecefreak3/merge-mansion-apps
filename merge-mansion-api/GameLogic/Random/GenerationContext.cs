using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Code.GameLogic.GameEvents;
using Metaplay.Game.Logic;
using Metaplay.GameLogic.Config;
using Metaplay.GameLogic.Player;
using Metaplay.Metaplay.Core;

namespace Metaplay.GameLogic.Random
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

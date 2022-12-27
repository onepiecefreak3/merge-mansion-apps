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

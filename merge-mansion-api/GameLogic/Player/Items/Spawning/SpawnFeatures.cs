using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Merge;
using Metaplay.GameLogic.Player.Board.Placement;
using Metaplay.GameLogic.Player.Items.Production;
using Metaplay.GameLogic.Random;
using Metaplay.Metaplay.Core.Math;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Spawning
{
    public sealed class SpawnFeatures
    {
        [MetaMember(1)]
        public IItemSpawner Spawn { get; set; }
        [MetaMember(2)]
        public IPlacement Placement { get; set; }
        [MetaMember(3)]
        public ISpawnCycle SpawnCycle { get; set; }
        [MetaMember(4)]
        public int StorageMax { get; set; }
        [MetaMember(6)]
        public IItemProducer DecayProducer { get; set; }
        [MetaMember(7)]
        public ItemVisibility SpawnVisibility { get; set; }

        public F64 TimeSkipPriceGems(IGenerationContext context)
        {
            return Spawn.TimeSkipPriceGems(context);
        }
    }
}

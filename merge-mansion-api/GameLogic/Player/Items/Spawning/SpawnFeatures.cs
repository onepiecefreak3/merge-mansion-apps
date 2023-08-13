using GameLogic.Merge;
using GameLogic.Player.Board.Placement;
using GameLogic.Player.Items.Production;
using GameLogic.Random;
using Metaplay.Core.Math;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Spawning
{
    [MetaSerializable]
    public class SpawnFeatures
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

        [MetaMember(8)]
        public string OverrideSfx { get; set; }

        public F64 TimeSkipPriceGems(IGenerationContext context)
        {
            return Spawn.TimeSkipPriceGems(context);
        }

        public static SpawnFeatures NoSpawn;
        public bool Spawnable { get; }
        public bool DecaysWhenCyclesAreDone { get; }

        private SpawnFeatures()
        {
        }

        public SpawnFeatures(IItemSpawner spawn, IPlacement placement, ISpawnCycle cycle, int howManyCanStore, IItemProducer decayProducer, string overrideSfx, ItemVisibility itemVisibility)
        {
        }
    }
}
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
    [MetaBlockedMembers(new int[] { 8 })]
    public class SpawnFeatures
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public IItemSpawner Spawn { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public IPlacement Placement { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public ISpawnCycle SpawnCycle { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int StorageMax { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public IItemProducer DecayProducer { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public ItemVisibility SpawnVisibility { get; set; }

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

        public SpawnFeatures(IItemSpawner spawn, IPlacement placement, ISpawnCycle cycle, int howManyCanStore, IItemProducer decayProducer, ItemVisibility itemVisibility)
        {
        }
    }
}
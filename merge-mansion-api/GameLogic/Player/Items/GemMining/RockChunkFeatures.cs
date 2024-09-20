using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.GemMining
{
    [MetaSerializable]
    public class RockChunkFeatures
    {
        public static RockChunkFeatures NoRockChunkFeatures;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsRockChunk { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int SpawnItemWeight { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int NoItemWeight { get; set; }

        private RockChunkFeatures()
        {
        }

        public RockChunkFeatures(bool isRockChunk, int spawnItemWeight, int noItemWeight)
        {
        }
    }
}
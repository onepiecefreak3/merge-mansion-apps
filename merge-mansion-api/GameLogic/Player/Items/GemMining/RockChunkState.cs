using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Items.GemMining
{
    [MetaSerializable]
    public class RockChunkState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int SpawnItemWeight { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int NoItemWeight { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private List<int> weights { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool SpawnsItem { get; set; }

        private RockChunkState()
        {
        }

        public RockChunkState(int spawnItemWeight, int noItemWeight)
        {
        }
    }
}
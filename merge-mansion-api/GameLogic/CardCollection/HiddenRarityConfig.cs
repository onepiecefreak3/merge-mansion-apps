using Metaplay.Core.Model;
using System;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class HiddenRarityConfig
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Cards { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Min { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Max { get; set; }

        private HiddenRarityConfig()
        {
        }

        public HiddenRarityConfig(int cards, int min, int max)
        {
        }
    }
}
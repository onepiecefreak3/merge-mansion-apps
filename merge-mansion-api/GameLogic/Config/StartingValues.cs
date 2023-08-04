using Metaplay.Core.Model;
using System;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class StartingValues
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Coins { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Diamonds { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Energy { get; set; }

        public StartingValues()
        {
        }

        public StartingValues(int coins, int diamonds, int energy)
        {
        }
    }
}
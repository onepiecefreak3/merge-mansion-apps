using Metaplay.Core.Model;
using Metaplay.Core.Math;
using System;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class RandomHiddenRarity
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardHiddenRarity HiddenRarity { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public F32 Weight { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int MinBetweenTwoSame { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int MaxBetweenTwoSame { get; set; }

        private RandomHiddenRarity()
        {
        }

        public RandomHiddenRarity(CardHiddenRarity hiddenRarity, F32 weight, int minBetweenTwoSame, int maxBetweenTwoSame)
        {
        }
    }
}
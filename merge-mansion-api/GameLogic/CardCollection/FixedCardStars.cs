using Metaplay.Core.Model;
using System;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class FixedCardStars
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardStars Stars { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        private FixedCardStars()
        {
        }

        public FixedCardStars(CardStars stars, int amount)
        {
        }
    }
}
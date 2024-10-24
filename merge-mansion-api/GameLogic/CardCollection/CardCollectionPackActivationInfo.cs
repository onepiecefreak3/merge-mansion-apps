using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;
using GameLogic.Random.ControlledRandom;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class CardCollectionPackActivationInfo : IGameConfigData<CardCollectionPackActivationId>, IGameConfigData, IHasGameConfigKey<CardCollectionPackActivationId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardCollectionPackActivationId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public CardCollectionPackId PackId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<CardCollectionCardId> InitialSequence { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<FixedCardStars> FixedCardsStars { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public CardsToRollFirst CardsToRollFirst { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int RandomRolls { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public RandomType RandomType { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public List<RandomCardStars> RandomCardsStars { get; set; }

        public CardCollectionPackActivationInfo()
        {
        }

        public CardCollectionPackActivationInfo(CardCollectionPackActivationId cardCollectionPackActivationId, CardCollectionPackId packId, List<CardCollectionCardId> initialSequence, List<FixedCardStars> fixedCardsStars, CardsToRollFirst cardsToRollFirst, int randomRolls, RandomType randomType, List<RandomCardStars> randomCardsStars)
        {
        }
    }
}
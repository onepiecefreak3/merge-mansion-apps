using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.Random.ControlledRandom;
using System.Collections.Generic;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class CardCollectionHiddenRarityActivationInfo : IGameConfigData<CardCollectionHiddenRarityActivationId>, IGameConfigData, IHasGameConfigKey<CardCollectionHiddenRarityActivationId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardCollectionHiddenRarityActivationId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public CardStars CardStars { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public RandomType RandomType { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<RandomHiddenRarity> RandomHiddenRarities { get; set; }

        public CardCollectionHiddenRarityActivationInfo()
        {
        }

        public CardCollectionHiddenRarityActivationInfo(CardCollectionHiddenRarityActivationId cardCollectionHiddenRarityActivationId, CardStars cardStars, RandomType randomType, List<RandomHiddenRarity> randomHiddenRarities)
        {
        }
    }
}
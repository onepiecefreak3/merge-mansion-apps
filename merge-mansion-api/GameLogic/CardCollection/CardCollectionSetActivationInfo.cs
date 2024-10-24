using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.Random.ControlledRandom;
using System.Collections.Generic;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class CardCollectionSetActivationInfo : IGameConfigData<CardCollectionSetActivationId>, IGameConfigData, IHasGameConfigKey<CardCollectionSetActivationId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardCollectionSetActivationId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public CardStars CardStars { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public CardHiddenRarity HiddenRarity { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public RandomType RandomType { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<RandomSetId> RandomSetIds { get; set; }

        public CardCollectionSetActivationInfo()
        {
        }

        public CardCollectionSetActivationInfo(CardCollectionSetActivationId cardCollectionSetActivationId, CardStars cardStars, CardHiddenRarity hiddenRarity, RandomType randomType, List<RandomSetId> randomSetIds)
        {
        }
    }
}
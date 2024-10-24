using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class CardCollectionCardActivationInfo : IGameConfigData<CardCollectionCardActivationId>, IGameConfigData, IHasGameConfigKey<CardCollectionCardActivationId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardCollectionCardActivationId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public CardCollectionCardSetId CardSetId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private Dictionary<CardStars, ActivationConfig> ActivationConfigByCardStars { get; set; }

        public CardCollectionCardActivationInfo()
        {
        }

        public CardCollectionCardActivationInfo(CardCollectionCardActivationId cardCollectionCardActivationId, CardCollectionCardSetId cardSetId, Dictionary<CardStars, ActivationConfig> activationConfigByCardStars)
        {
        }
    }
}
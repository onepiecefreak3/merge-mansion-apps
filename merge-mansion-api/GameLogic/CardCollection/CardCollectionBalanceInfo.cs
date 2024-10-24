using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class CardCollectionBalanceInfo : IGameConfigData<CardCollectionBalanceId>, IGameConfigData, IHasGameConfigKey<CardCollectionBalanceId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardCollectionBalanceId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<CardCollectionCardActivationId> CardActivationIds { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<CardCollectionPackActivationId> PackActivationIds { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<CardCollectionHiddenRarityActivationId> HiddenRarityActivationIds { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<CardCollectionSetActivationId> SetActivationIds { get; set; }

        public CardCollectionBalanceInfo()
        {
        }

        public CardCollectionBalanceInfo(CardCollectionBalanceId cardCollectionBalanceId, List<CardCollectionCardActivationId> cardActivationIds, List<CardCollectionPackActivationId> packActivationIds, List<CardCollectionHiddenRarityActivationId> hiddenRarityActivationIds, List<CardCollectionSetActivationId> setActivationIds)
        {
        }
    }
}
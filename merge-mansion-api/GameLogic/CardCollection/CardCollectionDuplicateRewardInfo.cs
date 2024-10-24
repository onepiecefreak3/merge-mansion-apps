using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.GameEvents;
using System;

namespace GameLogic.CardCollection
{
    [MetaSerializable]
    public class CardCollectionDuplicateRewardInfo : IGameConfigData<CardCollectionDuplicateRewardId>, IGameConfigData, IHasGameConfigKey<CardCollectionDuplicateRewardId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardCollectionDuplicateRewardId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public TemporaryCardCollectionEventId CollectionId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string BalanceId { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public CardStars CardStars { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool IsSpecial { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int Reward { get; set; }

        public CardCollectionDuplicateRewardInfo()
        {
        }

        public CardCollectionDuplicateRewardInfo(CardCollectionDuplicateRewardId configKey, TemporaryCardCollectionEventId collectionId, CardStars cardStars, bool isSpecial, int reward)
        {
        }
    }
}
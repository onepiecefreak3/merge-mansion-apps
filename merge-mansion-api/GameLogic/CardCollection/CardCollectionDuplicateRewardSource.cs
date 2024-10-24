using Code.GameLogic.Config;
using Metaplay.Core.Config;
using Code.GameLogic.GameEvents;
using System;

namespace GameLogic.CardCollection
{
    public class CardCollectionDuplicateRewardSource : IConfigItemSource<CardCollectionDuplicateRewardInfo, CardCollectionDuplicateRewardId>, IGameConfigSourceItem<CardCollectionDuplicateRewardId, CardCollectionDuplicateRewardInfo>, IHasGameConfigKey<CardCollectionDuplicateRewardId>
    {
        public CardCollectionDuplicateRewardId ConfigKey { get; set; }
        private TemporaryCardCollectionEventId CollectionId { get; set; }
        private string BalanceId { get; set; }
        private CardStars CardStars { get; set; }
        private bool IsSpecial { get; set; }
        private int RewardAmount { get; set; }

        public CardCollectionDuplicateRewardSource()
        {
        }
    }
}
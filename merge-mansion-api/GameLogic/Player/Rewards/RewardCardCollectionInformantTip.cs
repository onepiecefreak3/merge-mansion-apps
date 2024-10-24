using Metaplay.Core.Model;
using GameLogic.CardCollection;
using GameLogic.Fallbacks;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(40)]
    public class RewardCardCollectionInformantTip : PlayerReward
    {
        [MetaMember(101, (MetaMemberFlags)0)]
        public CardCollectionCardId CardId { get; set; }

        [MetaMember(102, (MetaMemberFlags)0)]
        public FallbackPlayerRewardId FallbackPlayerRewardId { get; set; }

        public RewardCardCollectionInformantTip()
        {
        }

        public RewardCardCollectionInformantTip(CardCollectionCardId cardId, FallbackPlayerRewardId fallbackPlayerRewardId, CurrencySource currencySource)
        {
        }
    }
}
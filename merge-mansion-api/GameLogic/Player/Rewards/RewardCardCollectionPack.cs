using Metaplay.Core.Model;
using GameLogic.CardCollection;
using GameLogic.Fallbacks;
using System;
using System.Runtime.Serialization;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(39)]
    public class RewardCardCollectionPack : PlayerReward
    {
        [MetaMember(101, (MetaMemberFlags)0)]
        public CardCollectionPackId CardCollectionPackId { get; set; }

        [MetaMember(102, (MetaMemberFlags)0)]
        public FallbackPlayerRewardId FallbackPlayerRewardId { get; set; }

        [MetaMember(103, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        public RewardCardCollectionPack()
        {
        }

        public RewardCardCollectionPack(CardCollectionPackId cardCollectionPackId, FallbackPlayerRewardId fallbackPlayerRewardId, int amount, CurrencySource currencySource)
        {
        }

        [IgnoreDataMember]
        public override bool ShouldShowInfoButton { get; }
    }
}
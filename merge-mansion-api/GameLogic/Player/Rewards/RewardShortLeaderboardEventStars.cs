using Metaplay.Core.Model;
using Code.GameLogic.GameEvents;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(43)]
    public class RewardShortLeaderboardEventStars : PlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ShortLeaderboardEventId EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public ShortLeaderboardEventStageId StageId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        public RewardShortLeaderboardEventStars()
        {
        }

        public RewardShortLeaderboardEventStars(ShortLeaderboardEventId eventId, ShortLeaderboardEventStageId stageId, int amount, CurrencySource currencySource)
        {
        }
    }
}
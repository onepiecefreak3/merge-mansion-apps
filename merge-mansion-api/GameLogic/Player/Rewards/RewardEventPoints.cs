using Code.GameLogic.GameEvents;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(14)]
    public class RewardEventPoints : PlayerReward
    {
        [MetaMember(1, 0)]
        public EventId EventId { get; set; }

        [MetaMember(2, 0)]
        public int Amount { get; set; }

        public RewardEventPoints()
        {
        }

        public RewardEventPoints(EventId eventId, int amount, CurrencySource currencySource)
        {
        }
    }
}
using Code.GameLogic.GameEvents;
using Metaplay.Core;
using Metaplay.Core.Model;
using System.Runtime.Serialization;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(22)]
    public class RewardCollectibleBoardEventProgress : PlayerReward
    {
        [MetaMember(1, 0)]
        private MetaRef<CollectibleBoardEventInfo> EventInfoRef { get; set; }

        [MetaMember(2, 0)]
        public int Amount { get; set; }

        [IgnoreDataMember]
        public CollectibleBoardEventId EventId { get; }

        public RewardCollectibleBoardEventProgress()
        {
        }

        public RewardCollectibleBoardEventProgress(CollectibleBoardEventId eventId, int amount, CurrencySource currencySource)
        {
        }
    }
}
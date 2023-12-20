using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace Code.GameLogic.DynamicEvents
{
    [MetaSerializable]
    public class DynamicEventRewardInfo : IGameConfigData<DynamicEventRewardId>, IGameConfigData, IGameConfigKey<DynamicEventRewardId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DynamicEventRewardId EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int RewardPoints { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        public DynamicEventRewardId ConfigKey => EventId;

        public DynamicEventRewardInfo()
        {
        }

        public DynamicEventRewardInfo(DynamicEventRewardId eventId, int rewardPoints, List<PlayerReward> rewards)
        {
        }
    }
}
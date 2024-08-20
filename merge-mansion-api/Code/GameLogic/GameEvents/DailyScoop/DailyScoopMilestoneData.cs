using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Metaplay.Core.Player;

namespace Code.GameLogic.GameEvents.DailyScoop
{
    [MetaSerializable]
    public class DailyScoopMilestoneData : IGameConfigData<DailyScoopMilestoneId>, IGameConfigData, IHasGameConfigKey<DailyScoopMilestoneId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DailyScoopMilestoneId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int RequiredPoints { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<PlayerSegmentId> RewardSegment { get; set; }

        public DailyScoopMilestoneData()
        {
        }

        public DailyScoopMilestoneData(DailyScoopMilestoneId configKey, int requiredPoints, List<PlayerReward> rewards, List<PlayerSegmentId> rewardSegment)
        {
        }
    }
}
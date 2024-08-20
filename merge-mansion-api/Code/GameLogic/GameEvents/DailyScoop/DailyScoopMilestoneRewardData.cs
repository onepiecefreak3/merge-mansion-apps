using Metaplay.Core.Model;
using GameLogic.Player.Rewards;
using System;

namespace Code.GameLogic.GameEvents.DailyScoop
{
    [MetaSerializable]
    public class DailyScoopMilestoneRewardData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public PlayerReward PlayerReward { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int RequiredPoints { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public DailyScoopMilestoneId MilestoneId { get; set; }

        public DailyScoopMilestoneRewardData()
        {
        }

        public DailyScoopMilestoneRewardData(PlayerReward playerReward, int requiredPoints, DailyScoopMilestoneId milestoneId)
        {
        }
    }
}
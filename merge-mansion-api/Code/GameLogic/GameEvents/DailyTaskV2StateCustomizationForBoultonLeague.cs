using Metaplay.Core.Model;
using GameLogic.DailyTasksV2;
using GameLogic.Player.Rewards;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class DailyTaskV2StateCustomizationForBoultonLeague
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DailyTaskV2Id TaskId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public RewardExperience RewardExperience { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public RewardBoultonLeaguePoints RewardBoultonLeaguePoints { get; set; }

        public DailyTaskV2StateCustomizationForBoultonLeague()
        {
        }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int SoloMilestonePoints { get; set; }
    }
}
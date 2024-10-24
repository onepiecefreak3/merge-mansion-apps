using Metaplay.Core.Model;
using System;
using Metaplay.Core.Math;
using System.Collections.Generic;

namespace GameLogic.DailyTasksV2
{
    [MetaSerializable]
    public class DailyTaskV2BoultonLeagueStepInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int RequirementItemValue { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public F32 RewardCoefficientMin { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public F32 RewardCoefficientMax { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool RefreshEnabled { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<int> RefreshCosts { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<string> AlgorithmAttempts { get; set; }

        private DailyTaskV2BoultonLeagueStepInfo()
        {
        }

        public DailyTaskV2BoultonLeagueStepInfo(int requirementItemValue, F32 rewardCoefficientMin, F32 rewardCoefficientMax, bool refreshEnabled, List<int> refreshCosts, List<string> algorithmAttempts)
        {
        }
    }
}
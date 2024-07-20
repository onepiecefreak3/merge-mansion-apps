using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace GameLogic.DailyTasksV2
{
    [MetaSerializable]
    public class DailyTaskV2StepInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int RequirementItemValue { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int RewardItemValue { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public bool RefreshEnabled { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<int> RefreshCosts { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<string> AlgorithmAttempts { get; set; }

        private DailyTaskV2StepInfo()
        {
        }

        public DailyTaskV2StepInfo(int requirementItemValue, int rewardItemValue, bool refreshEnabled, List<int> refreshCosts, List<string> algorithmAttempts)
        {
        }
    }
}
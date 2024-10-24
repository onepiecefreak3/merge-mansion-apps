using Metaplay.Core.Model;
using GameLogic.DailyTasksV2;
using Metaplay.Core;
using GameLogic.Player.Items;
using System;
using System.Collections.Generic;
using GameLogic.Random.ControlledRandom;

namespace GameLogic.Player.DailyTasksV2
{
    [MetaSerializable]
    public class DailyTaskV2State
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DailyTaskV2Id TaskId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> RequirementItemRef { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> RewardItemRef { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int StepIndex { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<DailyTaskV2StepInfo> Steps { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MetaTime CompletedTimestamp { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public int AccumulatedDiminishingValue { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public int LogAttempt { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public string LogContent { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public int RefreshCount { get; set; }

        public DailyTaskV2State()
        {
        }

        [MetaMember(11, (MetaMemberFlags)0)]
        public ControlledRandomFiniteSequence UnlimitedRandomSequenceForBoultonLeague { get; set; }
    }
}
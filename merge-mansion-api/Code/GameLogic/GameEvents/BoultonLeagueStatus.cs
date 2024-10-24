using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class BoultonLeagueStatus
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int StageNumber { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public Dictionary<int, int> FinishedCountPerStageNumber { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int HighestReachedStageNumber { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool DailyTasksV2FtueInspectionRegistered { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool FtueInspectionRegistered { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int? DevPendingNextStageNumber { get; set; }

        public BoultonLeagueStatus()
        {
        }
    }
}
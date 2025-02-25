using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using GameLogic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 4 })]
    public class BoultonLeagueStatus
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int StageNumber { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public Dictionary<int, int> FinishedCountPerStageNumber { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int HighestReachedStageNumber { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool FtueInspectionRegistered { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int? DevPendingNextStageNumber { get; set; }

        public BoultonLeagueStatus()
        {
        }

        [MetaMember(7, (MetaMemberFlags)0)]
        public BoultonLeagueStatus.DailyTasksV2FtuePart DailyTasksV2FtuePartInspected { get; set; }

        [ForceExplicitEnumValues]
        [MetaSerializable]
        public enum DailyTasksV2FtuePart
        {
            NotSeen = 0,
            SeenBubble = 1,
            SeenPopup = 2
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using Code.GameLogic.GameEvents.DailyScoop;
using System.Runtime.Serialization;
using Metaplay.Core.Player;
using System;
using GameLogic.Player.Rewards;
using System.Collections.Generic;
using GameLogic.StatsTracking;

namespace Code.GameLogic.Player.Events.DailyScoopEvent
{
    [MetaSerializable]
    public class DailyScoopEventModel : MetaActivableState<DailyScoopEventId, DailyScoopEventInfo>
    {
        [IgnoreDataMember]
        private PlayerSegmentId eventSegment;
        [MetaMember(1, (MetaMemberFlags)0)]
        public sealed override DailyScoopEventId ActivableId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private byte BoolFields { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int CollectedEventPoints { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public DailyScoopWeekId EventWeekId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public DailyScoopDayId CurrentDayId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public PlayerReward CurrentDailyReward { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public List<DailyScoopMilestoneRewardData> MilestoneRewards { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public List<StatsObjective> CurrentStandardTasks { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public List<DailyScoopSpecialStatsObjective> CurrentSpecialTasks { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public List<DailyScoopMilestoneId> ClaimedMilestones { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public bool DailyRewardClaimed { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public float DailyProgress { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public float WeeklyProgress { get; set; }
        public bool PreviewNoted { get; set; }
        public bool StartNoted { get; set; }
        public bool EndNoted { get; set; }
        public bool DisplayedDailyScoopPopup { get; set; }
        public bool DailyChallengeUnlocked { get; set; }

        private DailyScoopEventModel()
        {
        }

        public DailyScoopEventModel(DailyScoopEventInfo info)
        {
        }
    }
}
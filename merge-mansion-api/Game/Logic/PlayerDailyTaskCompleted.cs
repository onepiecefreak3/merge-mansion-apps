using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using System;
using GameLogic.Player.DailyTasks;

namespace Game.Logic
{
    [AnalyticsEvent(7, "Completed daily task", 1, null, true, false, false)]
    public class PlayerDailyTaskCompleted : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Wanted;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Reward;
        public override string EventDescription { get; }

        public PlayerDailyTaskCompleted()
        {
        }

        public PlayerDailyTaskCompleted(DailyTaskState taskState)
        {
        }
    }
}
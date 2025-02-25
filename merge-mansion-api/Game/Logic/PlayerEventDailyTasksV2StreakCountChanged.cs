using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;
using GameLogic;

namespace Game.Logic
{
    [AnalyticsEventKeywords(new string[] { "daily" })]
    [MetaBlockedMembers(new int[] { 3 })]
    [AnalyticsEvent(25, "Daily tasks V2 streak count changed", 1, null, true, false, false)]
    public class PlayerEventDailyTasksV2StreakCountChanged : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public PlayerEventDailyTasksV2StreakCountChanged.ChangeSource Source { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int NewStreakCount { get; set; }
        public override string EventDescription { get; }

        public PlayerEventDailyTasksV2StreakCountChanged()
        {
        }

        public PlayerEventDailyTasksV2StreakCountChanged(PlayerEventDailyTasksV2StreakCountChanged.ChangeSource source, int newStreakCount)
        {
        }

        [MetaSerializable]
        [ForceExplicitEnumValues]
        public enum ChangeSource
        {
            Player = 0,
            Admin = 1
        }
    }
}
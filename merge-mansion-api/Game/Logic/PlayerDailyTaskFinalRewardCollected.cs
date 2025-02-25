using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using System;

namespace Game.Logic
{
    [AnalyticsEvent(8, "Daily task final reward collected", 1, null, true, false, false)]
    [AnalyticsEventKeywords(new string[] { "daily" })]
    public class PlayerDailyTaskFinalRewardCollected : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Reward;
        public override string EventDescription { get; }

        public PlayerDailyTaskFinalRewardCollected()
        {
        }

        public PlayerDailyTaskFinalRewardCollected(int finalReward)
        {
        }
    }
}
using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using GameLogic.Player;

namespace Analytics
{
    [AnalyticsEvent(176, "Bot test end", 1, null, true, true, false)]
    public class AnalyticsEventBotTestEnd : AnalyticsServersideEventBase
    {
        [JsonProperty("producer_id")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public string ProducerId;
        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("producer_level")]
        public int ProducerLvl;
        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("target_id")]
        public string TargetId;
        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("target_lvl")]
        public int TargetLvl;
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("board_items")]
        public Dictionary<string, int> BoardItems;
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("bot_configuration_id")]
        public string ConfigId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("test_id")]
        public string TestId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("total_sessions")]
        public int TotalSessions { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("diamonds_spent")]
        public int DiamondsSpent { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("energy_spent")]
        public int EnergySpent { get; set; }

        [JsonProperty("was_goal_achieved")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public bool WasGoalAchieved { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventBotTestEnd()
        {
        }

        public AnalyticsEventBotTestEnd(PlayerModel player, string producerId, int producerLvl, string targetId, int targetLvl, string configurationId, string testId, int totalSessions, int diamondsSpent, int energySpent, bool wasGoalAchieved)
        {
        }
    }
}
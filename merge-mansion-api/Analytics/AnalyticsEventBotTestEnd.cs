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
        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("producer_id")]
        public string ProducerId;
        [JsonProperty("producer_level")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public int ProducerLvl;
        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("target_id")]
        public string TargetId;
        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("target_lvl")]
        public int TargetLvl;
        [JsonProperty("board_items")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
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

        [JsonProperty("diamonds_spent")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public int DiamondsSpent { get; set; }

        [JsonProperty("energy_spent")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public int EnergySpent { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("was_goal_achieved")]
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
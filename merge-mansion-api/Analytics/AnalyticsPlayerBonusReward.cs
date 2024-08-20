using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [MetaSerializable]
    public class AnalyticsPlayerBonusReward
    {
        [JsonProperty("reward_type")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Type of the reward")]
        public string Type { get; set; }

        [Description("Id/Name of the reward")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("reward_id")]
        public string Id { get; set; }

        [JsonProperty("reward_amount")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Reward amount")]
        public long Amount { get; set; }

        public AnalyticsPlayerBonusReward()
        {
        }

        public AnalyticsPlayerBonusReward(string type, string id, long amount)
        {
        }
    }
}
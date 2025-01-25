using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [MetaSerializable]
    public class AnalyticsPlayerBonusReward
    {
        [Description("Type of the reward")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("reward_type")]
        public string Type { get; set; }

        [Description("Id/Name of the reward")]
        [JsonProperty("reward_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string Id { get; set; }

        [Description("Reward amount")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("reward_amount")]
        public long Amount { get; set; }

        public AnalyticsPlayerBonusReward()
        {
        }

        public AnalyticsPlayerBonusReward(string type, string id, long amount)
        {
        }
    }
}
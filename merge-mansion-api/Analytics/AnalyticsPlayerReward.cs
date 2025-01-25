using Newtonsoft.Json;
using Metaplay.Core.Model;
using System;

namespace Analytics
{
    [JsonConverter(typeof(AnalyticsTaskRewardJsonConverter))]
    [MetaSerializable]
    public class AnalyticsPlayerReward
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string FlattenName { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string FlattenValue { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        private AnalyticsPlayerReward()
        {
        }

        public AnalyticsPlayerReward(string flattenName, string flattenValue, int amount)
        {
        }
    }
}
using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(139, "Player claimed chain completion reward", 1, null, true, true, false)]
    [AnalyticsEventKeywords(new string[] { "item" })]
    public class PlayerClaimedChainCompletionReward : AnalyticsServersideEventBase
    {
        [JsonProperty("merge_chain_id")]
        [Description("ID of the merge chain claimed")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string MergeChainId;
        [Description("ID of the reward claimed")]
        [JsonProperty("codex_discovery_reward_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string CodexDiscoveryRewardId;
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        public PlayerClaimedChainCompletionReward()
        {
        }

        public PlayerClaimedChainCompletionReward(string mergeChainId, string codexDiscoveryRewardId)
        {
        }

        [JsonProperty("merge_chain_total_length")]
        [Description("Merge chain total length")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int MergeChainTotalLength { get; set; }

        [JsonProperty("merge_chain_unlocked_length")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Merge chain unlocked length")]
        public int MergeChainUnlockedLength { get; set; }

        public PlayerClaimedChainCompletionReward(string mergeChainId, string codexDiscoveryRewardId, int mergeChainTotalLength, int mergeChainUnlockedLength)
        {
        }
    }
}
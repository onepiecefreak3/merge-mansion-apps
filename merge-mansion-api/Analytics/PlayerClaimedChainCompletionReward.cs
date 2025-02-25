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
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("codex_discovery_reward_id")]
        [Description("ID of the reward claimed")]
        public string CodexDiscoveryRewardId;
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        public PlayerClaimedChainCompletionReward()
        {
        }

        public PlayerClaimedChainCompletionReward(string mergeChainId, string codexDiscoveryRewardId)
        {
        }

        [Description("Merge chain total length")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("merge_chain_total_length")]
        public int MergeChainTotalLength { get; set; }

        [JsonProperty("merge_chain_unlocked_length")]
        [Description("Merge chain unlocked length")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public int MergeChainUnlockedLength { get; set; }

        public PlayerClaimedChainCompletionReward(string mergeChainId, string codexDiscoveryRewardId, int mergeChainTotalLength, int mergeChainUnlockedLength)
        {
        }
    }
}
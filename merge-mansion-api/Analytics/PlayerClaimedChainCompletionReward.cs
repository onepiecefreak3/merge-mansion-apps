using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using System;

namespace Analytics
{
    [AnalyticsEvent(139, "Player claimed chain completion reward", 1, null, true, true, false)]
    public class PlayerClaimedChainCompletionReward : AnalyticsServersideEventBase
    {
        [Description("ID of the merge chain claimed")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("merge_chain_id")]
        public string MergeChainId;
        [JsonProperty("codex_discovery_reward_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
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

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("merge_chain_total_length")]
        [Description("Merge chain total length")]
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
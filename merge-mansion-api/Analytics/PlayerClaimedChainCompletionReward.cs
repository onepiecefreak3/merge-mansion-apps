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
        [JsonProperty("merge_chain_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the merge chain claimed")]
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
    }
}
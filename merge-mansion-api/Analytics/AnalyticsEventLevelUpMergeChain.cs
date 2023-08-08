using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using GameLogic.MergeChains;
using System;

namespace Analytics
{
    [AnalyticsEvent(163, "Merge chain level up", 1, null, false, true, false)]
    public class AnalyticsEventLevelUpMergeChain : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("merge_chain_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Id of the merge chain that was leveled up")]
        public MergeChainId MergeChainId { get; set; }

        [JsonProperty("merge_chain_level")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Merge chain level after level up")]
        public int Level { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventLevelUpMergeChain()
        {
        }

        public AnalyticsEventLevelUpMergeChain(MergeChainId mergeChainId, int level)
        {
        }
    }
}
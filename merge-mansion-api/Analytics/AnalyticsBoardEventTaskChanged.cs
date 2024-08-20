using Metaplay.Core.Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using GameLogic.MergeChains;
using Code.GameLogic.DynamicEvents;

namespace Analytics
{
    [AnalyticsEvent(126, "Board event task has changed", 1, null, false, true, false)]
    public class AnalyticsBoardEventTaskChanged : AnalyticsServersideEventBase
    {
        [JsonProperty("event_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("ID of the event")]
        public string EventId;
        [JsonProperty("event_task_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("ID of the event task")]
        public string EventTaskId;
        [JsonProperty("state")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("State of the event task")]
        public string State;
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        public AnalyticsBoardEventTaskChanged()
        {
        }

        [Description("Items required by the task")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("required_items")]
        public List<AnalyticsBoardEventTaskChanged.ItemRequirement> RequiredItems;
        [JsonProperty("task_type")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Task type: dynamic / predefined")]
        public string TaskType;
        [JsonProperty("rewards")]
        [Description("Task rewards")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public List<AnalyticsPlayerReward> Rewards;
        [MetaSerializable]
        public class ItemRequirement
        {
            [JsonProperty("item_id")]
            [MetaMember(1, (MetaMemberFlags)0)]
            public int ItemId;
            [MetaMember(2, (MetaMemberFlags)0)]
            [JsonProperty("merge_chain_id")]
            public MergeChainId MergeChainId;
            [JsonProperty("item_level")]
            [MetaMember(3, (MetaMemberFlags)0)]
            public int ItemLevel;
            [MetaMember(4, (MetaMemberFlags)0)]
            [JsonProperty("item_level_to_lvl_1")]
            public int ItemLevelToLvl1;
            [JsonProperty("merge_chain_items_as_lvl_1", NullValueHandling = (NullValueHandling)1)]
            [MetaMember(5, (MetaMemberFlags)0)]
            public List<int> MergeChainItemsAsLvl1;
            [JsonProperty("sum_of_merge_chain_items_as_lvl_1", NullValueHandling = (NullValueHandling)1)]
            [MetaMember(6, (MetaMemberFlags)0)]
            public int? SumOfMergeChainItemsAsLvl1;
            public ItemRequirement()
            {
            }
        }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("debug_data", NullValueHandling = (NullValueHandling)1)]
        public List<DebugItemData> DebugData { get; set; }
    }
}
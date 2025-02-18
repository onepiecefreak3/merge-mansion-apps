using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using Merge;
using System.Collections.Generic;
using GameLogic.MergeChains;
using System;
using GameLogic.Player.Board;

namespace Analytics
{
    [AnalyticsEvent(149, "Board activations left", 1, null, false, true, false)]
    public class AnalyticsEventBoardActivationsLeft : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("board_id")]
        [Description("Board Id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public MergeBoardId BoardId { get; set; }

        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("activations_left")]
        public Dictionary<MergeChainId, int> ActivationsLeft { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventBoardActivationsLeft()
        {
        }

        public AnalyticsEventBoardActivationsLeft(MergeBoard board)
        {
        }
    }
}
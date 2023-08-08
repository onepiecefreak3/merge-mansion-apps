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

        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("board_id")]
        [Description("Board Id")]
        public MergeBoardId BoardId { get; set; }

        [JsonProperty("activations_left")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [BigQueryAnalyticsFormat((BigQueryAnalyticsFormatMode)0)]
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
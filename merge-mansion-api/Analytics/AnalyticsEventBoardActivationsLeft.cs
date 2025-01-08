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
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Board Id")]
        public MergeBoardId BoardId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("activations_left")]
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
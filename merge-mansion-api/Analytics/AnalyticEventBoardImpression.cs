using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using Merge;
using System;

namespace Analytics
{
    [AnalyticsEvent(166, "Board impression", 1, null, false, true, false)]
    public class AnalyticEventBoardImpression : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [JsonProperty("board_id")]
        [Description("Board Id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public MergeBoardId BoardId { get; set; }
        public override string EventDescription { get; }

        private AnalyticEventBoardImpression()
        {
        }

        public AnalyticEventBoardImpression(MergeBoardId boardId)
        {
        }
    }
}
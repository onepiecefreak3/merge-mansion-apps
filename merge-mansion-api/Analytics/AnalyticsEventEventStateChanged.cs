using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using Merge;
using System;

namespace Analytics
{
    [AnalyticsEvent(109, "Event state changed", 1, null, false, true, false)]
    public class AnalyticsEventEventStateChanged : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("event_state")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("New state of the event")]
        public AnalyticsEventEventStateChanged.EventStateChangeType EventState { get; set; }

        [JsonProperty("event_id")]
        [Description("Merge board corresponding to the event")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public MergeBoardId BoardId { get; set; }

        [JsonProperty("ended_by_customer_support")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Ended by customer support?")]
        public bool EndedByCustomerSupport { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventEventStateChanged()
        {
        }

        public AnalyticsEventEventStateChanged(AnalyticsEventEventStateChanged.EventStateChangeType eventStateChangeType, MergeBoardId boardId, bool endedByCustomerSupport)
        {
        }

        [MetaSerializable]
        public enum EventStateChangeType
        {
            JoinedEvent = 0,
            EventEnded = 1,
            EventRewardCollectionEnded = 2
        }
    }
}
using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 4, 5 })]
    [AnalyticsEvent(127, "Slot for decoration has been changed", 1, null, false, true, false)]
    public class AnalyticsDecorationSlotChanged : AnalyticsServersideEventBase
    {
        [Description("Index of the decoration slot that was affected")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("decoration_slot_index")]
        public int SlotIndex;
        [Description("Previous decoration that was in the slot (null if there was nothing)")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("decoration_id_prev")]
        public string PreviousDecorationId;
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("New decoration that was put in the slot (null if slot was cleared)")]
        [JsonProperty("decoration_id_new")]
        public string NewDecorationId;
        public override AnalyticsEventType EventType { get; }
        public override string EventDescription { get; }

        public AnalyticsDecorationSlotChanged()
        {
        }
    }
}
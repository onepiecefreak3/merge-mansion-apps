using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;
using GameLogic.Mail;

namespace Analytics
{
    [AnalyticsEvent(134, "Broadcast received", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class AnalyticEventBroadcastReceived : AnalyticsServersideEventBase
    {
        public override AnalyticsEventType EventType { get; }

        [JsonProperty("broadcast_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public int BroadcastId { get; set; }

        [JsonProperty("item_type")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public string BroadcastType { get; set; }
        public override string EventDescription { get; }

        public AnalyticEventBroadcastReceived()
        {
        }

        public AnalyticEventBroadcastReceived(IBroadcastMailMessage broadcastMailMessage)
        {
        }
    }
}
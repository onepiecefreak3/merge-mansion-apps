using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using GameLogic.Player.Items;
using System;

namespace Analytics
{
    [AnalyticsEvent(181, "Portal piece chain", 1, null, false, true, false)]
    public class AnalyticsEventPortalPieceChain : AnalyticsServersideEventBase
    {
        [Description("Action that happened")]
        [JsonProperty("action")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public PortalPieceChainAnalyticsType Action;
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Board event id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("board_id")]
        [Description("Board id")]
        public string BoardId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Related item name")]
        [JsonProperty("item_name")]
        public string ItemName { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventPortalPieceChain()
        {
        }

        public AnalyticsEventPortalPieceChain(string eventId, string boardId, string itemName, PortalPieceChainAnalyticsType action)
        {
        }
    }
}
using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.Collections.Generic;
using Metaplay.Core.Player;
using System;
using GameLogic.Player;

namespace Analytics
{
    [AnalyticsEvent(142, "Players Segments", 1, null, false, true, false)]
    public class AnalyticsEventPlayersSegments : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Segments player belongs to")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("segments")]
        public List<PlayerSegmentId> Segments { get; set; }

        [JsonProperty("resolved_succesfully")]
        [Description("Did we resolve the segments succesgully")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public bool ResolvedSuccesfully { get; set; }
        public override string EventDescription { get; }

        private AnalyticsEventPlayersSegments()
        {
        }

        public AnalyticsEventPlayersSegments(PlayerModel player)
        {
        }
    }
}
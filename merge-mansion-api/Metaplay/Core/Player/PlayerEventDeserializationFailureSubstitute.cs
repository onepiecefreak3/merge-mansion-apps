using Metaplay.Core.Analytics;
using Metaplay.Core.EventLog;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Player
{
    [AnalyticsEvent(1099, "<Failed to Deserialize Event!>", 1, "This is a substitute event that is shown if the original serialized event could not be deserialized. This can happen if event data format is changed in an incompatible way.", true, false, false)]
    public class PlayerEventDeserializationFailureSubstitute : PlayerEventBase, IEntityEventPayloadDeserializationFailureSubstitute
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EntityEventDeserializationFailureInfo FailureInfo { get; set; }
        public override string EventDescription { get; }

        public PlayerEventDeserializationFailureSubstitute()
        {
        }
    }
}
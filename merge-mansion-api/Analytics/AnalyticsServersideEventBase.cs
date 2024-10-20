using Metaplay.Core.Model;
using Metaplay.Core.Player;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [MetaReservedMembers(100, 199)]
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 100, 101, 102, 103, 104, 105, 106 })]
    public abstract class AnalyticsServersideEventBase : PlayerEventBase, IMergeMansionAnalyticsEvent
    {
        [JsonIgnore]
        public abstract AnalyticsEventType EventType { get; }

        [JsonIgnore]
        public string EventName { get; }

        protected AnalyticsServersideEventBase()
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.League;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [MetaSerializable]
    [MetaReservedMembers(100, 199)]
    public abstract class AnalyticsServersideDivisionEventBase : DivisionEventBase, IMergeMansionAnalyticsEvent
    {
        [JsonIgnore]
        public abstract AnalyticsEventType EventType { get; }

        [JsonIgnore]
        public string EventName { get; }

        protected AnalyticsServersideDivisionEventBase()
        {
        }
    }
}
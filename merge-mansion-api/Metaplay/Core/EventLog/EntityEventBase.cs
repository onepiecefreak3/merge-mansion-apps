using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System;
using Metaplay.Core.Json;

namespace Metaplay.Core.EventLog
{
    [MetaAllowNoSerializedMembers]
    [MetaSerializable]
    public abstract class EntityEventBase : AnalyticsEventBase
    {
        [JsonIgnore]
        public abstract string EventDescription { get; }

        [JsonProperty("eventDescription")]
        [IncludeOnlyInJsonSerializationMode((JsonSerializationMode)3)]
        public string EventDescriptionErrorWrapper { get; }

        protected EntityEventBase()
        {
        }
    }
}
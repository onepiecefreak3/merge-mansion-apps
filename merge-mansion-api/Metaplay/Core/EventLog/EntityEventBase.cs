using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System;
using Metaplay.Core.Json;

namespace Metaplay.Core.EventLog
{
    [MetaSerializable]
    [MetaAllowNoSerializedMembers]
    public abstract class EntityEventBase : AnalyticsEventBase
    {
        [JsonIgnore]
        public abstract string EventDescription { get; }

        [IncludeOnlyInJsonSerializationMode((JsonSerializationMode)3)]
        [JsonProperty("eventDescription")]
        public string EventDescriptionErrorWrapper { get; }

        protected EntityEventBase()
        {
        }
    }
}
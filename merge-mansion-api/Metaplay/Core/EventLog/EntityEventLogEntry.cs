using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.EventLog
{
    [MetaSerializable]
    public abstract class EntityEventLogEntry<TPayload, TPayloadDeserializationFailureSubstitute> : MetaEventLogEntry
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime ModelTime { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int PayloadSchemaVersion { get; set; }

        [MetaOnMemberDeserializationFailure("CreatePayloadDeserializationFailureSubstitute")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public TPayload Payload { get; set; }

        protected EntityEventLogEntry()
        {
        }

        public EntityEventLogEntry(MetaEventLogEntry.BaseParams baseParams, MetaTime modelTime, int payloadSchemaVersion, TPayload payload)
        {
        }
    }
}
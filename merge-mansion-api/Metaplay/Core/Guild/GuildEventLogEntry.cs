using Metaplay.Core.Model;
using Metaplay.Core.EventLog;
using System;

namespace Metaplay.Core.Guild
{
    [MetaSerializable]
    public class GuildEventLogEntry : EntityEventLogEntry<GuildEventBase, GuildEventDeserializationFailureSubstitute>
    {
        private GuildEventLogEntry()
        {
        }

        public GuildEventLogEntry(MetaEventLogEntry.BaseParams baseParams, MetaTime modelTime, int payloadSchemaVersion, GuildEventBase payload)
        {
        }
    }
}
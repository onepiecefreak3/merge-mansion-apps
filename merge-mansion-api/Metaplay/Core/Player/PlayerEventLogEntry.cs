using Metaplay.Core.Model;
using Metaplay.Core.EventLog;
using System;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public class PlayerEventLogEntry : EntityEventLogEntry<PlayerEventBase, PlayerEventDeserializationFailureSubstitute>
    {
        private PlayerEventLogEntry()
        {
        }

        public PlayerEventLogEntry(MetaEventLogEntry.BaseParams baseParams, MetaTime modelTime, int payloadSchemaVersion, PlayerEventBase payload)
        {
        }
    }
}
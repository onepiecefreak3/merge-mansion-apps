using Metaplay.Core.Model;
using Metaplay.Core.EventLog;

namespace Metaplay.Core.Guild
{
    [MetaSerializable]
    public class GuildEventLog : EntityEventLog<GuildEventBase, GuildEventDeserializationFailureSubstitute, GuildEventLogEntry>
    {
        public GuildEventLog()
        {
        }
    }
}
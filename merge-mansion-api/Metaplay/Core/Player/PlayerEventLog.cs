using Metaplay.Core.Model;
using Metaplay.Core.EventLog;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public class PlayerEventLog : EntityEventLog<PlayerEventBase, PlayerEventDeserializationFailureSubstitute, PlayerEventLogEntry>
    {
        public PlayerEventLog()
        {
        }
    }
}
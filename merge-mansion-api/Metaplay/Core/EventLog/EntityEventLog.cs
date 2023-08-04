using Metaplay.Core.Model;

namespace Metaplay.Core.EventLog
{
    [MetaSerializable]
    public abstract class EntityEventLog<TPayload, TPayloadDeserializationFailureSubstitute, TEntry> : MetaEventLog<TEntry>
    {
        protected EntityEventLog()
        {
        }
    }
}
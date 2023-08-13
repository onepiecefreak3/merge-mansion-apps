using Metaplay.Core;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventId : StringId<EventId>
    {
        public EventId()
        {
        }
    }
}
using Metaplay.Core;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventTaskId : StringId<EventTaskId>
    {
        public EventTaskId()
        {
        }
    }
}
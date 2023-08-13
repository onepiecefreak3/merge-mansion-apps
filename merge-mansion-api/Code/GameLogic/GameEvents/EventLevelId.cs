using Metaplay.Core;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventLevelId : StringId<EventLevelId>
    {
        public EventLevelId()
        {
        }
    }
}
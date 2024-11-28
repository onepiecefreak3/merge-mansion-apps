using Metaplay.Core.Model;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventInstanceId : StringId<EventInstanceId>
    {
        public EventInstanceId()
        {
        }
    }
}
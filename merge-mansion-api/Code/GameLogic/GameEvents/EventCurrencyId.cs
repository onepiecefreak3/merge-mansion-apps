using Metaplay.Core;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventCurrencyId : StringId<EventCurrencyId>
    {
        public EventCurrencyId()
        {
        }
    }
}
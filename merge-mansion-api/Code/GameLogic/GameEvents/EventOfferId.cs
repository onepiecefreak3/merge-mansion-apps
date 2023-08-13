using Metaplay.Core;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventOfferId : StringId<EventOfferId>
    {
        public EventOfferId()
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.EventCharacters
{
    [MetaSerializable]
    public class EventCharacterId : StringId<EventCharacterId>
    {
        public static EventCharacterId None;
        public EventCharacterId()
        {
        }
    }
}
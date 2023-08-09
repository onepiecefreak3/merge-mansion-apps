using GameLogic;
using Metaplay.Core;

namespace Game.Logic
{
    public class CharacterDiscoveredEvent : CopyableEvent<CharacterDiscoveredEvent, DialogCharacterType>
    {
        public CharacterDiscoveredEvent()
        {
        }
    }
}
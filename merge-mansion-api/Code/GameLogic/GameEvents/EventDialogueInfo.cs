using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventDialogueInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string TextId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public DialogCharacterType LeftCharacter;
        [MetaMember(3, (MetaMemberFlags)0)]
        public DialogCharacterType RightCharacter;
        public EventDialogueInfo()
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Config;

namespace GameLogic.Dialogue
{
    [MetaSerializable]
    public class DialogueCharacterInfo : IGameConfigData<DialogCharacterType>, IGameConfigData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DialogCharacterType DialogCharacterType { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool StartDiscovered { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<DirectorGroupId> DirectorGroupIdsToForceDiscover { get; set; }

        public DialogCharacterType ConfigKey => DialogCharacterType;

        public DialogueCharacterInfo()
        {
        }

        public DialogueCharacterInfo(DialogCharacterType dialogCharacterType, bool startDiscovered, List<DirectorGroupId> directorGroupIdsToForceDiscover)
        {
        }
    }
}
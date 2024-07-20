using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Config;

namespace GameLogic.Dialogue
{
    public class DialogueCharacterSource : IConfigItemSource<DialogueCharacterInfo, DialogCharacterType>, IGameConfigSourceItem<DialogCharacterType, DialogueCharacterInfo>, IHasGameConfigKey<DialogCharacterType>
    {
        public DialogCharacterType DialogCharacterType { get; set; }
        public bool StartDiscovered { get; set; }
        public List<DirectorGroupId> DirectorGroupIdsToForceDiscover { get; set; }
        public DialogCharacterType ConfigKey { get; }

        public DialogueCharacterSource()
        {
        }
    }
}
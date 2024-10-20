using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.Config
{
    [MetaBlockedMembers(new int[] { 4 })]
    [MetaSerializable]
    public class CollectibleDialoguesInfo : IGameConfigData<CollectibleDialoguesInfoId>, IGameConfigData, IHasGameConfigKey<CollectibleDialoguesInfoId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CollectibleDialoguesInfoId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private List<ItemDialogueEntry> ItemDialogues { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private List<DecorationDialogueEntry> DecorationsDialogues { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string RequiredBoardEventId { get; set; }

        public CollectibleDialoguesInfo()
        {
        }

        public CollectibleDialoguesInfo(CollectibleDialoguesInfoId configKey, string requiredBoardEventId, string itemDialogues, string decorationsDialogues)
        {
        }
    }
}
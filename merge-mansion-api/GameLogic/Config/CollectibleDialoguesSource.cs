using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Config
{
    public class CollectibleDialoguesSource : IConfigItemSource<CollectibleDialoguesInfo, CollectibleDialoguesInfoId>, IGameConfigSourceItem<CollectibleDialoguesInfoId, CollectibleDialoguesInfo>, IHasGameConfigKey<CollectibleDialoguesInfoId>
    {
        public CollectibleDialoguesInfoId ConfigKey { get; set; }
        private string RequiredBoardEventId { get; set; }
        private string ItemDialogues { get; set; }
        private string DecorationDialogues { get; set; }

        public CollectibleDialoguesSource()
        {
        }
    }
}
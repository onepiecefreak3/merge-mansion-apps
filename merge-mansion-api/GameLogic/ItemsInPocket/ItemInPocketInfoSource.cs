using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace GameLogic.ItemsInPocket
{
    public class ItemInPocketInfoSource : IConfigItemSource<ItemInPocketInfo, ItemInPocketId>, IGameConfigSourceItem<ItemInPocketId, ItemInPocketInfo>, IHasGameConfigKey<ItemInPocketId>
    {
        public ItemInPocketId ConfigKey { get; set; }
        private string Item { get; set; }
        private bool IsNecessaryValidCoordinateToRunFromPocket { get; set; }
        private bool CanMoveToBoard { get; set; }
        private int PriorityInPocket { get; set; }
        private List<string> ActionsToRunFromPocket { get; set; }

        public ItemInPocketInfoSource()
        {
        }
    }
}
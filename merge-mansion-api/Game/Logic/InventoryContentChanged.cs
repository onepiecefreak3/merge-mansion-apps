using Metaplay.Core;
using System;
using Merge;

namespace Game.Logic
{
    public class InventoryContentChanged : CopyableEvent<InventoryContentChanged, int, MergeBoardId, int, PlayerInventoryChangeEventType>
    {
        public InventoryContentChanged()
        {
        }
    }
}
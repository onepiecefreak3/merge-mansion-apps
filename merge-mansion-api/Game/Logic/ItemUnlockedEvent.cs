using Metaplay.Core;
using System;

namespace Game.Logic
{
    public class ItemUnlockedEvent : CopyableEvent<ItemUnlockedEvent, int>
    {
        public ItemUnlockedEvent()
        {
        }
    }
}
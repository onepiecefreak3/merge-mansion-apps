using Metaplay.Core;
using System;

namespace Game.Logic
{
    public class ItemDiscoveredEvent : CopyableEvent<ItemDiscoveredEvent, int>
    {
        public ItemDiscoveredEvent()
        {
        }
    }
}
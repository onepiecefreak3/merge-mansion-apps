using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(2)]
    public class ProgressionEventExtraInventorySlotsPerk : ProgressionEventPerk
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int SlotCount { get; set; }

        public ProgressionEventExtraInventorySlotsPerk()
        {
        }

        public ProgressionEventExtraInventorySlotsPerk(int slotCount)
        {
        }
    }
}
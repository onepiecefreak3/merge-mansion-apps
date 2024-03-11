using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(32)]
    public class AtLeastNInventorySlotsRequirement : PlayerRequirement
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int SlotCount { get; set; }

        private AtLeastNInventorySlotsRequirement()
        {
        }

        public AtLeastNInventorySlotsRequirement(int slotCount)
        {
        }
    }
}
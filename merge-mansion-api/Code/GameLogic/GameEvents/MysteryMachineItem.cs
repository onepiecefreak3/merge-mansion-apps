using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(1)]
    public class MysteryMachineItem : IMysteryMachineItem
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int ItemId { get; set; }

        private MysteryMachineItem()
        {
        }

        public MysteryMachineItem(int itemId)
        {
        }
    }
}
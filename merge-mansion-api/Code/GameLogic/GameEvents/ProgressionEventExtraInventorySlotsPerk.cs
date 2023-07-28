using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
    public class ProgressionEventExtraInventorySlotsPerk : ProgressionEventPerk
    {
        [MetaMember(1, 0)]
        public int SlotCount { get; set; }
    }
}

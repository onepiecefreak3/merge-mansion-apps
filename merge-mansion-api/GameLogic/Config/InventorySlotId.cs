using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class InventorySlotId : StringId<InventorySlotId>
    {
        public InventorySlotId()
        {
        }
    }
}
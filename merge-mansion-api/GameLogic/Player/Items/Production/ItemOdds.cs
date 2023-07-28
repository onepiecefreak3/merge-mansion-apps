using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Production
{
    [MetaSerializable]
    public class ItemOdds
    {
        [MetaMember(1)] 
        public MetaRef<ItemDefinition> Type { get; set; }  // 0x10

        [MetaMember(2)]
        public int Weight { get; set; } // 0x18
    }
}

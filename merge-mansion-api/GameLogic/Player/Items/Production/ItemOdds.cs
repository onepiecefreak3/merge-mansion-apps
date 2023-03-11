using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Production
{
    public class ItemOdds
    {
        [MetaMember(1)] 
        public MetaRef<ItemDefinition> Type { get; set; }  // 0x10

        [MetaMember(2)]
        public int Weight { get; set; } // 0x18
    }
}

using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Production
{
    public class ItemOdds
    {
        [MetaMember(1)]
        public MetaRef<ItemDefinition> Type { get; set; }
        [MetaMember(2)]
        public int Weight { get; set; }
    }
}

using Metaplay.GameLogic.Merge;
using Metaplay.GameLogic.Player.Director.Config;
using Metaplay.GameLogic.Player.Items;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Hotspots.Actions
{
    [MetaSerializableDerived(2)]
    public class ReplaceItemsOnBoard : IDirectorAction
    {
        [MetaMember(1, 0)]
        private MergeBoardId MergeBoardId { get; set; }
        [MetaMember(2, 0)]
        private MetaRef<ItemDefinition> ReplacementItem { get; set; }
        [MetaMember(3, 0)]
        private string Tag { get; set; }
        [MetaMember(4, 0)]
        private MetaDuration ReplaceDuration { get; set; }
	}
}

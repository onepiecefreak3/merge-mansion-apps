using GameLogic.Merge;
using GameLogic.Player.Director.Config;
using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Hotspots.Actions
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
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

using GameLogic.Merge;
using GameLogic.Player.Director.Config;
using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;
using Merge;
using System;
using System.Runtime.Serialization;

namespace GameLogic.Hotspots.Actions
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

        private ReplaceItemsOnBoard()
        {
        }

        public ReplaceItemsOnBoard(MergeBoardId mergeBoardId, MetaRef<ItemDefinition> replacementItem, string tag, MetaDuration replaceDuration)
        {
        }

        [IgnoreDataMember]
        public bool IsVisualAction { get; }
    }
}
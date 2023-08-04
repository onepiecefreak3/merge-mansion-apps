using GameLogic.Merge;
using GameLogic.Player.Director.Config;
using Metaplay.Core;
using Metaplay.Core.Model;
using Merge;
using System;

namespace GameLogic.Hotspots.Actions
{
    [MetaSerializableDerived(10)]
    [MetaSerializable]
    public class SellItems : IDirectorAction
    {
        [MetaMember(1, 0)]
        private MergeBoardId MergeBoardId { get; set; }

        [MetaMember(2, 0)]
        private string Tag { get; set; }

        [MetaMember(3, 0)]
        private MetaDuration SellDuration { get; set; }

        private SellItems()
        {
        }

        public SellItems(MergeBoardId mergeBoardId, string tag, MetaDuration sellDuration)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Config.Costs;
using Metaplay.GameLogic.ConfigPrefabs;
using Metaplay.GameLogic.Merge;
using Metaplay.GameLogic.Player.Items.Bubble;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class BoardInfo : IGameConfigData<MergeBoardId>
    {
        [MetaMember(1, 0)]
        public MergeBoardId BoardId { get; set; }
        [MetaMember(2, 0)]
        public string DisplayName { get; set; }
        [MetaMember(3, 0)]
        public string Description { get; set; }
        [MetaMember(4, 0)]
        public List<BoardCell> BoardLayout { get; set; }
        [MetaMember(5, 0)]
        public int Width { get; set; }
        [MetaMember(6, 0)]
        public int Height { get; set; }
        [MetaMember(7, 0)]
        public ICost ItemSellCost { get; set; }
        [MetaMember(8, 0)]
        public ConfigPrefabId BoardPrefabId { get; set; }
        [MetaMember(9, 0)]
        private MetaRef<BubblesSetup> BubbleSetup { get; set; }

        public MergeBoardId ConfigKey => BoardId;
    }
}

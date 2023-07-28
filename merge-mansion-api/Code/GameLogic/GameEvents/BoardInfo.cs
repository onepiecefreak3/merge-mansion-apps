using System.Collections.Generic;
using GameLogic.Config.Costs;
using GameLogic.ConfigPrefabs;
using GameLogic.Merge;
using GameLogic.Player.Items.Bubble;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
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

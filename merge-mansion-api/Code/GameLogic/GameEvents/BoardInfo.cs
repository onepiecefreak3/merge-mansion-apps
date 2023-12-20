using System.Collections.Generic;
using GameLogic.Config.Costs;
using GameLogic.ConfigPrefabs;
using GameLogic.Merge;
using GameLogic.Player.Items.Bubble;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Merge;
using System;
using GameLogic.Player;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class BoardInfo : IGameConfigData<MergeBoardId>, IGameConfigData, IGameConfigKey<MergeBoardId>
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

        [MetaMember(10, (MetaMemberFlags)0)]
        public string BoardToggleSfxOverride { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public string BoardMusicOverride { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public int DisableAutospawns { get; set; }
        public IBubbleLogic BubbleLogic { get; }

        public BoardInfo()
        {
        }

        public BoardInfo(MergeBoardId boardId, string displayName, string description, List<ValueTuple<int, ItemVisibility>> boardLayout, ICost itemSellCost, ConfigPrefabId boardPrefabId, MetaRef<BubblesSetup> bubblesSetup, string boardToggleSfxOverride, string boardMusicOverride, string disableAutospawns)
        {
        }

        [MetaMember(13, (MetaMemberFlags)0)]
        public EnergyType EnergyType { get; set; }

        public BoardInfo(MergeBoardId boardId, string displayName, string description, List<ValueTuple<int, ItemVisibility>> boardLayout, ICost itemSellCost, ConfigPrefabId boardPrefabId, MetaRef<BubblesSetup> bubblesSetup, string boardToggleSfxOverride, string boardMusicOverride, string disableAutospawns, string energyType)
        {
        }

        [MetaMember(14, (MetaMemberFlags)0)]
        public int CobwebClearPoints { get; set; }

        public BoardInfo(MergeBoardId boardId, string displayName, string description, List<ValueTuple<int, ItemVisibility>> boardLayout, ICost itemSellCost, ConfigPrefabId boardPrefabId, MetaRef<BubblesSetup> bubblesSetup, string boardToggleSfxOverride, string boardMusicOverride, string disableAutospawns, string energyType, string cobwebClearPoints)
        {
        }
    }
}
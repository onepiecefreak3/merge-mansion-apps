using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class DigEventBoards : IGameConfigData<DigEventBoardId>, IGameConfigData, IHasGameConfigKey<DigEventBoardId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DigEventBoardId BoardId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int BoardWidth { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int BoardHeight { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int CellSize { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<DigEventItemId> Treasures { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        private PlayerReward BoardReward { get; set; }

        public DigEventBoardId ConfigKey => BoardId;

        public DigEventBoards()
        {
        }

        public DigEventBoards(DigEventBoardId configKey, int boardWidth, int boardHeight, int cellSize, List<DigEventItemId> boardItems, PlayerReward boardReward)
        {
        }
    }
}
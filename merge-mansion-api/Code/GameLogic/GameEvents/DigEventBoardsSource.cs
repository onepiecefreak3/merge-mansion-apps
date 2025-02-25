using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    public class DigEventBoardsSource : IConfigItemSource<DigEventBoards, DigEventBoardId>, IGameConfigSourceItem<DigEventBoardId, DigEventBoards>, IHasGameConfigKey<DigEventBoardId>
    {
        public DigEventBoardId ConfigKey { get; set; }
        private int BoardWidth { get; set; }
        private int BoardHeight { get; set; }
        private int CellSize { get; set; }
        private List<DigEventItemId> BoardItems { get; set; }
        private string RewardType { get; set; }
        private string RewardId { get; set; }
        private string RewardAux0 { get; set; }
        private string RewardAux1 { get; set; }
        private int RewardAmount { get; set; }

        public DigEventBoardsSource()
        {
        }
    }
}
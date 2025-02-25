using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    public class DigEventInfoSource : IConfigItemSource<DigEventInfo, DigEventId>, IGameConfigSourceItem<DigEventId, DigEventInfo>, IHasGameConfigKey<DigEventId>
    {
        public DigEventId ConfigKey { get; set; }
        public bool MainHud { get; set; }
        public List<DigEventBoardId> MainBoards { get; set; }
        public List<DigEventBoardId> InfiniteBoards { get; set; }
        public int SpecialItemsAmount { get; set; }
        public List<DigEventMuseumShelfId> Museum { get; set; }
        public bool AnyItemOnMuseumShelfs { get; set; }
        public bool MuseumStartsEmpty { get; set; }
        public int ShinyItemsAmount { get; set; }
        public List<DigEventBoardId> ShinyBoards { get; set; }
        public int TapMultiplier { get; set; }
        private string RewardType { get; set; }
        private string RewardId { get; set; }
        private string RewardAux0 { get; set; }
        private string RewardAux1 { get; set; }
        private int RewardAmount { get; set; }
        private string SinkItem { get; set; }

        public DigEventInfoSource()
        {
        }
    }
}
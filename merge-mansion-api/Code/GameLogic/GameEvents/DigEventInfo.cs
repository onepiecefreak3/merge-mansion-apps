using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class DigEventInfo : IGameConfigData<DigEventId>, IGameConfigData, IHasGameConfigKey<DigEventId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public DigEventId EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool MainHud { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<DigEventBoardId> MainBoards { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<DigEventBoardId> InfiniteBoards { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int SpecialItemsAmount { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<DigEventMuseumShelfId> Museum { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public bool AnyItemOnMuseumShelfs { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public bool MuseumStartsEmpty { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public int ShinyItemsAmount { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public List<DigEventBoardId> ShinyBoards { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public int TapMultiplier { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public PlayerReward EventReward { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public string SinkItem { get; set; }

        public DigEventId ConfigKey => EventId;

        public DigEventInfo()
        {
        }

        public DigEventInfo(DigEventId configKey, bool mainHud, List<DigEventBoardId> mainBoards, List<DigEventBoardId> infiniteBoards, int specialItemsAmount, List<DigEventMuseumShelfId> museum, bool anyItemOnMuseumShelfs, bool museumStartsEmpty, int shinyItemsAmount, List<DigEventBoardId> shinyBoards, int tapMultiplier, PlayerReward eventReward, string sinkItem)
        {
        }
    }
}
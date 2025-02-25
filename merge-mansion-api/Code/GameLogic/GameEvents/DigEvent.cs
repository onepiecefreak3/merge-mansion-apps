using Metaplay.Core.Model;
using System.Collections.Generic;
using System;
using GameLogic;
using GameLogic.Player;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 6 })]
    public class DigEvent
    {
        public List<DigEventTreasureItem> TreasureConfigs;
        [MetaMember(9, (MetaMemberFlags)0)]
        private int DigEventGridObjectNextId;
        public Dictionary<int, DigEventGridObject> objectLookup;
        [MetaMember(1, (MetaMemberFlags)0)]
        public string DigEventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public long DigEventEnergy { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public DigEventGridCell[] TopLayerGridCells { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public DigEventGridCell[] ObjectLayerGridCells { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public DigEventBoardData BoardData { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public int BoardsSinceLastShiny { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public List<DigEventGoalState> GoalStates { get; set; }
        public DigEventMinigameData MinigameData { get; set; }
        public int CollectedTreasures { get; }
        public int TotalTreasures { get; }
        public HashSet<string> RoundTreasures { get; set; }

        public DigEvent()
        {
        }

        public DigEvent(PlayerModel player, string digEventId, long digEventEnergy)
        {
        }
    }
}
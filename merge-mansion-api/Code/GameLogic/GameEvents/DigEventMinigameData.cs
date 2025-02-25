using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class DigEventMinigameData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int DigEventLevel { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public ValueTuple<int, int> CurrentBoardProgress { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public HashSet<int> ClaimedLevelRewards { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public string CurrentDigEventId { get; set; }

        public DigEventMinigameData()
        {
        }
    }
}
using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class DigEventGoalState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string TreasureName;
        [MetaMember(2, (MetaMemberFlags)0)]
        public bool IsCollected;
        public DigEventGoalState()
        {
        }

        public DigEventGoalState(string treasureName, bool isCollected)
        {
        }
    }
}
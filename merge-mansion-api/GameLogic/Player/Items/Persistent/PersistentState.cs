using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Persistent
{
    [MetaSerializable]
    public class PersistentState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool HasItemStates { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int DecayCycles { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int ItemStates { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public ItemDefinition ResetToItem { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int StartCycles { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int CurrentState { get; set; }

        public PersistentState()
        {
        }

        public PersistentState(bool hasItemStates, int decayCycles, int itemStates, ItemDefinition resetToItem, int startCycles, int currentState)
        {
        }
    }
}
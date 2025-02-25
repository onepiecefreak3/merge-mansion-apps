using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace GameLogic
{
    [MetaSerializable]
    public class DigEventGridCell
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int x;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int y;
        [MetaMember(3, (MetaMemberFlags)0)]
        public bool isRevealed;
        [MetaMember(4, (MetaMemberFlags)0)]
        public string name;
        [MetaMember(5, (MetaMemberFlags)0)]
        public string digObjectTreasureName;
        [MetaMember(6, (MetaMemberFlags)0)]
        public int digObjectRotation;
        [MetaMember(7, (MetaMemberFlags)0)]
        public List<ValueTuple<int, int>> digObjectOccupiedCells;
        [MetaMember(8, (MetaMemberFlags)0)]
        public int digObjectId;
        public DigEventGridCell()
        {
        }
    }
}
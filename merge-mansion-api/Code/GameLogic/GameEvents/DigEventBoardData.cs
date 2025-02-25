using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public struct DigEventBoardData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int GridWidth;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int GridHeight;
        [MetaMember(3, (MetaMemberFlags)0)]
        public int CellSize;
        [MetaMember(4, (MetaMemberFlags)0)]
        public int CellSpacing;
    }
}
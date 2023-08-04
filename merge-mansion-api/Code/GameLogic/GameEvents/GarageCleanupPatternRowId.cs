using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public struct GarageCleanupPatternRowId
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GarageCleanupPatternId PatternId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Row { get; set; }
    }
}
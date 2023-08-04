using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public struct GarageCleanupBoardRowId
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GarageCleanupBoardId BoardId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Row { get; set; }
    }
}
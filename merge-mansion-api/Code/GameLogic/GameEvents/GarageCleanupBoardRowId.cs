using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public struct GarageCleanupBoardRowId : IEquatable<GarageCleanupBoardRowId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GarageCleanupBoardId BoardId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Row { get; set; }

        public bool Equals(GarageCleanupBoardRowId other)
        {
            return BoardId.Equals(other.BoardId) && Row == other.Row;
        }

        public override bool Equals(object obj)
        {
            return obj is GarageCleanupBoardRowId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BoardId, Row);
        }
    }
}
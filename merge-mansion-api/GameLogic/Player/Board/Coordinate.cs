using Metaplay.Core.Model;
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace GameLogic.Player.Board
{
    [MetaSerializable]
    public struct Coordinate
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int X { get; set; }

        [MetaMember(2, 0)]
        public int Y { get; set; }

        public static Coordinate Invalid;
        public static Coordinate Zero;
        public bool IsInvalid { get; }

        [IgnoreDataMember]
        public IEnumerable<Coordinate> CrossNeighbours { get; }

        [IgnoreDataMember]
        public IEnumerable<Coordinate> Clockwise3x3 { get; }

        [IgnoreDataMember]
        public IEnumerable<Coordinate> ClockwiseLarger3x3 { get; }
    }
}
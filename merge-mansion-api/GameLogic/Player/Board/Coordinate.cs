using Metaplay.Core.Model;

namespace GameLogic.Player.Board
{
    public struct Coordinate
    {
        [MetaMember(1, 0)]
        public int X { get; set; }
        [MetaMember(2, 0)]
        public int Y { get; set; }
    }
}

using System;
using System.Runtime.CompilerServices;

namespace GameLogic.Player.Board
{
    public interface IBoardQuery
    {
        ValueTuple<int, int> BoardDimensions { get; }

        bool IsValid(Coordinate coordinate);
        bool IsEmpty(Coordinate coordinate);
    }
}
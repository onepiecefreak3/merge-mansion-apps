using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.GameLogic.Player.Board
{
    public interface IBoardQuery
    {
        ValueTuple<int, int> BoardDimensions { get; }

        bool IsValid(Coordinate coordinate);
        bool IsEmpty(Coordinate coordinate);
    }
}

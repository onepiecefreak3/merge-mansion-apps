using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Board
{
    public struct Coordinate
    {
        [MetaMember(1, 0)]
        public int X { get; set; }
        [MetaMember(2, 0)]
        public int Y { get; set; }
    }
}

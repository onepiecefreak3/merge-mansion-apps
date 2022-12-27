using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Merge;
using Metaplay.GameLogic.Player.Items;

namespace Metaplay.GameLogic.Player.Board
{
    public interface IBoard : IBoardQuery
    {
        MergeBoardId BoardIdentifier { get; }
        IEnumerable<MergeItem> MergeItems { get; }
        IEnumerable<Coordinate> Coordinates { get; }
        BoardBubbleState BubbleState { get; }

        MergeItem GetItem(Coordinate coordinate);
    }
}

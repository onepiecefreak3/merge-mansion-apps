using System.Collections.Generic;
using GameLogic.Merge;
using GameLogic.Player.Items;

namespace GameLogic.Player.Board
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

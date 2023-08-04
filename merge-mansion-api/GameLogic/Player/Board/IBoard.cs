using System.Collections.Generic;
using GameLogic.Merge;
using GameLogic.Player.Items;
using Merge;

namespace GameLogic.Player.Board
{
    public interface IBoard : IBoardQuery
    {
        MergeBoardId BoardIdentifier { get; }

        IEnumerable<MergeItem> MergeItems { get; }

        IEnumerable<Coordinate> Coordinates { get; }

        BoardBubbleState BubbleState { get; }

        MergeItem GetItem(Coordinate coordinate);
        List<MergeItem> MergeItemsNonAlloc { get; }

        MergeItem Item { get; }
    }
}
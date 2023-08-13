using System.Collections.Generic;
using GameLogic.Merge;
using GameLogic.Player.Items;
using Merge;
using System.Reflection;

namespace GameLogic.Player.Board
{
    [DefaultMember("Item")]
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
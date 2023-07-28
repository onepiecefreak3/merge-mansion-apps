using System;
using System.Collections.Generic;
using GameLogic.Merge;
using GameLogic.Player.Items;

namespace GameLogic.Player.Board
{
    public sealed class MergeBoard : IBoard
    {
        public (int, int) BoardDimensions { get; }

        public MergeBoardId BoardIdentifier { get; }
        public IEnumerable<MergeItem> MergeItems { get; }
        public IEnumerable<Coordinate> Coordinates { get; }
        public BoardBubbleState BubbleState { get; }

        public MergeItem GetItem(Coordinate coordinate)
        {
            throw new NotImplementedException();
        }

        public bool IsValid(Coordinate coordinate)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty(Coordinate coordinate)
        {
            throw new NotImplementedException();
        }

        // Process merge for items
        //public void ProcessMerge(Coordinate fromPosition, Coordinate toPosition, MetaTime timeForMergeOrMove,
        //    IPlayer player, IBubbleSpawner bubbleSpawner, IProgressionEventItemSpawner progressionEventItemSpawner,
        //    ICollection<MergeBoardAct> collectedActs)
        //{
        //    var fromItem = GetItem(fromPosition);
        //    var toItem = GetItem(toPosition);

        //    var fromMergeFeatures = fromItem.Definition.MergeFeatures;
        //    fromItem.Definition.IsArtifactItem();

        //    var mergedItem = fromMergeFeatures.Mechanic.Merge(player, fromItem, toItem, timeForMergeOrMove);
        //}
    }
}

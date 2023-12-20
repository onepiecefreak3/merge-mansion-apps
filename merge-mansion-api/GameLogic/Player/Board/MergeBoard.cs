using System;
using System.Collections.Generic;
using GameLogic.Merge;
using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Math;
using System.Runtime.Serialization;
using Metaplay.Core.Model;
using GameLogic.Player.Board.Placement;
using Merge;
using GameLogic.Random;
using System.Reflection;

namespace GameLogic.Player.Board
{
    [DefaultMember("Item")]
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 4 })]
    public class MergeBoard : IBoard, IBoardQuery
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

        private SortedDictionary<MetaTime, ValueTuple<ItemActionType, MergeItem, Coordinate>> timeResolveDictionary;
        private Dictionary<Coordinate, F32> boostOfCoordinate;
        [IgnoreDataMember]
        private ICollection<Coordinate> coordinates;
        [MetaMember(1, (MetaMemberFlags)0)]
        private List<MergeItem> BoardItems { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private MetaTime BoardCreationTime { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaTime LastModificationTime { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        private int Width { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        private int Height { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public bool HasEnded { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public long MergeCount { get; set; }

        [IgnoreDataMember]
        public List<MergeItem> MergeItemsNonAlloc { get; }

        [IgnoreDataMember]
        public IPlacement DefaultPlacement { get; }

        [IgnoreDataMember]
        public MergeItem Item { get; set; }

        [IgnoreDataMember]
        public IEnumerable<ValueTuple<Coordinate, MergeItem>> Items { get; }

        public MergeBoard()
        {
        }

        public MergeBoard(MergeBoardId identifier, int boardWidth, int boardHeight, MetaTime creationTime)
        {
        }

        public MergeBoard(IPlayer player, MergeBoardId identifier, int boardWidth, int boardHeight, MetaTime creationTime, IEnumerable<ValueTuple<ItemDefinition, ItemVisibility>> items, IGenerationContext generationContext)
        {
        }

        [MetaMember(11, (MetaMemberFlags)0)]
        public List<MetaDuration> PendingTimeSkips { get; set; }
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
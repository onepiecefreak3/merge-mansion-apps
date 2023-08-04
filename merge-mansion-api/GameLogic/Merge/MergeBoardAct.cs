using GameLogic.Player.Board;
using GameLogic.Player.Items;
using Metaplay.Core;

namespace GameLogic.Merge
{
    public readonly struct MergeBoardAct
    {
        public readonly BoardStepResult BoardStepResult;
        public readonly Coordinate FromCoordinate;
        public readonly Coordinate ToCoordinate;
        public readonly ItemDefinition Item;
        public readonly MetaTime Timestamp;
        public readonly MergeBoardAct.ItemActSource ActSource;
        public readonly MergeItem ResultItem;
        public enum ItemActSource
        {
            Unknown = 0,
            FromPocket = 1,
            FromMerge = 2,
            FromSpawner = 3,
            FromChest = 4,
            FromDecay = 5,
            FromInventory = 6
        }
    }
}
using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using Merge;
using System.Runtime.Serialization;
using GameLogic.Player.Items;
using Metaplay.Core;

namespace GameLogic.Player
{
    [MetaBlockedMembers(new int[] { 1, 2 })]
    [MetaSerializable]
    public class BoardInventory
    {
        [MetaMember(3, (MetaMemberFlags)0)]
        public int Size { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private List<BoardInventory.InventoryEntry> Entries { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MergeBoardId BoardId { get; set; }
        public int ItemCount { get; }
        public bool IsFull { get; }

        [IgnoreDataMember]
        public IEnumerable<MergeItem> MergeItems { get; }

        public BoardInventory()
        {
        }

        public BoardInventory(int initialSize)
        {
        }

        public BoardInventory(MergeBoardId boardId, int initialSize)
        {
        }

        [MetaSerializable]
        public class InventoryEntry
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public MergeItem Item { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public MetaTime Timestamp { get; set; }

            public InventoryEntry()
            {
            }
        }

        [MetaMember(6, (MetaMemberFlags)0)]
        public bool IsLocked { get; set; }
        public bool IsEmpty { get; }
    }
}
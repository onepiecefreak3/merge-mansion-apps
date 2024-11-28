using GameLogic.Merge;
using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class BoardCell
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public ItemVisibility ItemVisibility { get; set; }

        [MetaMember(1, (MetaMemberFlags)0)]
        public int ItemId { get; set; }

        public BoardCell()
        {
        }

        public BoardCell(int itemId, ItemVisibility itemVisibility)
        {
        }
    }
}
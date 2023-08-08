using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using System;
using Merge;

namespace Game.Logic
{
    [AnalyticsEvent(11, "Item moved from pocket to board", 1, null, true, false, false)]
    public class PlayerMovedItemFromPocketToBoard : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Item { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MergeBoardId BoardId { get; set; }
        public override string EventDescription { get; }

        public PlayerMovedItemFromPocketToBoard()
        {
        }

        public PlayerMovedItemFromPocketToBoard(int item, MergeBoardId boardId)
        {
        }
    }
}
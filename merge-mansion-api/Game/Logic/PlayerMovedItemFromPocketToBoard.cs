using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using System;
using Merge;
using Analytics;

namespace Game.Logic
{
    [AnalyticsEvent(11, "Item moved from pocket to board", 1, null, true, true, false)]
    [AnalyticsEventKeywords(new string[] { "item", "pocket" })]
    public class PlayerMovedItemFromPocketToBoard : AnalyticsServersideEventBase
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

        public override AnalyticsEventType EventType { get; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string ItemName { get; set; }

        public PlayerMovedItemFromPocketToBoard(int item, MergeBoardId boardId, string itemName)
        {
        }
    }
}
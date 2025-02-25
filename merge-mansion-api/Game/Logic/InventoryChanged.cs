using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using System;
using Merge;
using Analytics;

namespace Game.Logic
{
    [AnalyticsEventKeywords(new string[] { "item" })]
    [AnalyticsEvent(23, "Inventory changed", 1, null, true, true, false)]
    public class InventoryChanged : AnalyticsServersideEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ItemType { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MergeBoardId BoardId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Count { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public PlayerInventoryChangeEventType ChangeType { get; set; }
        public override string EventDescription { get; }

        private InventoryChanged()
        {
        }

        public InventoryChanged(string itemType, MergeBoardId boardId, int count, PlayerInventoryChangeEventType changeType)
        {
        }

        public override AnalyticsEventType EventType { get; }
    }
}
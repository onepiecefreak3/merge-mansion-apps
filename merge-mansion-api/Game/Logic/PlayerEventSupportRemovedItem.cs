using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using System;
using Merge;

namespace Game.Logic
{
    [AnalyticsEvent(10, "Support removed item", 1, null, true, false, false)]
    [AnalyticsEventKeywords(new string[] { "item" })]
    public class PlayerEventSupportRemovedItem : PlayerEventBase
    {
        [Obsolete("Item information now stored in ItemType. ItemId kept for backwards compatibility")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public int ItemId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MergeBoardId BoardId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public bool FromInventory { get; set; }
        public override string EventDescription { get; }

        public PlayerEventSupportRemovedItem()
        {
        }

        public PlayerEventSupportRemovedItem(int itemId, MergeBoardId boardId, bool fromInventory)
        {
        }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool FromPocket { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string ItemType { get; set; }

        public PlayerEventSupportRemovedItem(int itemId, MergeBoardId boardId, bool fromInventory, bool fromPocket)
        {
        }

        public PlayerEventSupportRemovedItem(string itemType, MergeBoardId boardId, bool fromInventory, bool fromPocket)
        {
        }

        [MetaMember(6, (MetaMemberFlags)0)]
        public bool FromProducerInventory { get; set; }

        public PlayerEventSupportRemovedItem(int itemId, MergeBoardId boardId, bool fromInventory, bool fromPocket, bool fromProducerInventory)
        {
        }

        public PlayerEventSupportRemovedItem(string itemType, MergeBoardId boardId, bool fromInventory, bool fromPocket, bool fromProducerInventory)
        {
        }

        public PlayerEventSupportRemovedItem(int itemId, string itemType, MergeBoardId boardId, bool fromInventory, bool fromPocket, bool fromProducerInventory)
        {
        }
    }
}
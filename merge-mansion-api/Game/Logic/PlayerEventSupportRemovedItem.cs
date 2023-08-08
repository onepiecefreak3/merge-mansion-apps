using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using System;
using Merge;

namespace Game.Logic
{
    [AnalyticsEvent(10, "Support removed item", 1, null, true, false, false)]
    public class PlayerEventSupportRemovedItem : PlayerEventBase
    {
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
    }
}
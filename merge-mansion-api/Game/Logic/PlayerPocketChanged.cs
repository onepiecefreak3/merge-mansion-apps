using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using System;
using Merge;
using GameLogic.Player;
using Analytics;

namespace Game.Logic
{
    [AnalyticsEventKeywords(new string[] { "item", "pocket" })]
    [AnalyticsEvent(12, "Pocket changed", 1, null, true, true, false)]
    public class PlayerPocketChanged : AnalyticsServersideEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [Obsolete("Item information now stored in ItemName. Item Id kept for backwards compatibility")]
        public int Item { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MergeBoardId BoardId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Count { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public PlayerPocketChangeEventType ChangeType { get; set; }
        public override string EventDescription { get; }

        public PlayerPocketChanged()
        {
        }

        public PlayerPocketChanged(int item, MergeBoardId boardId, int count, PlayerPocketChangeEventType changeType)
        {
        }

        public override AnalyticsEventType EventType { get; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string ItemName { get; set; }

        public PlayerPocketChanged(int itemId, string itemName, MergeBoardId boardId, int count, PlayerPocketChangeEventType changeType)
        {
        }
    }
}
using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using System;
using GameLogic.Player;
using GameLogic;

namespace Game.Logic
{
    [AnalyticsEvent(5, "Gained/gifted item", 1, null, true, false, false)]
    [AnalyticsEventKeywords(new string[] { "item" })]
    public class PlayerEventGainedItem : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [Obsolete("Used for compatibility with old event data")]
        public int ItemId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public bool IsSupportGiven;
        [MetaMember(3, (MetaMemberFlags)0)]
        public CurrencySource Source;
        [MetaMember(4, (MetaMemberFlags)0)]
        public AnalyticsContext AnalyticsContext;
        public override string EventDescription { get; }

        public PlayerEventGainedItem()
        {
        }

        public PlayerEventGainedItem(int itemId)
        {
        }

        public PlayerEventGainedItem(int itemId, bool supportGiven, CurrencySource source, AnalyticsContext context)
        {
        }

        [MetaMember(5, (MetaMemberFlags)0)]
        public string ItemType;
        public PlayerEventGainedItem(string itemType, bool supportGiven, CurrencySource source, AnalyticsContext context)
        {
        }
    }
}
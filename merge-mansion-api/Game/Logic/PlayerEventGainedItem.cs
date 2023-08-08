using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using System;
using GameLogic.Player;

namespace Game.Logic
{
    [AnalyticsEvent(5, "Gained/gifted item", 1, null, true, false, false)]
    public class PlayerEventGainedItem : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
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
    }
}
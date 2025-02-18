using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using GameLogic.CardCollection;
using System;

namespace Game.Logic
{
    [AnalyticsEventKeywords(new string[] { "event", "discovery" })]
    [AnalyticsEvent(27, "Opened wild card", 1, null, true, false, false)]
    public class PlayerOpenedWildCard : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardCollectionCardId WildCardId { get; set; }
        public override string EventDescription { get; }

        public PlayerOpenedWildCard()
        {
        }

        public PlayerOpenedWildCard(CardCollectionCardId wildCardId)
        {
        }
    }
}
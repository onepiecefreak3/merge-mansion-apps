using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using GameLogic.CardCollection;
using System;

namespace Game.Logic
{
    [AnalyticsEvent(26, "Opened card pack", 1, null, true, false, false)]
    public class PlayerOpenedCardPack : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardCollectionPackId CardCollectionPackId { get; set; }
        public override string EventDescription { get; }

        public PlayerOpenedCardPack()
        {
        }

        public PlayerOpenedCardPack(CardCollectionPackId cardCollectionPackId)
        {
        }
    }
}
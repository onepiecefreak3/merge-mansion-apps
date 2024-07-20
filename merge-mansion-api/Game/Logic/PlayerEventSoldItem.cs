using System;
using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using Metaplay.Core.Model;
using GameLogic;

namespace Game.Logic
{
    [AnalyticsEvent(2, "Item sold", 1, null, true, false, false)]
    [Obsolete("Item sold no longer used, combined with coins gained", false)]
    public class PlayerEventSoldItem : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public Currencies Currency;
        [MetaMember(2, (MetaMemberFlags)0)]
        public long Amount;
        [MetaMember(3, (MetaMemberFlags)0)]
        public int SoldItemType;
        public override string EventDescription { get; }

        public PlayerEventSoldItem()
        {
        }

        public PlayerEventSoldItem(Currencies currency, long amount, int soldItemType)
        {
        }
    }
}
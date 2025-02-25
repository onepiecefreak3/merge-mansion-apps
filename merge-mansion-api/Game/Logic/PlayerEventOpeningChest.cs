using Metaplay.Core.Model;
using Metaplay.Core.Analytics;
using Metaplay.Core.Player;
using System;
using Metaplay.Core;

namespace Game.Logic
{
    [AnalyticsEventKeywords(new string[] { "chest" })]
    [AnalyticsEvent(28, "Player opening chest", 1, null, true, false, false)]
    [MetaBlockedMembers(new int[] { 3 })]
    public class PlayerEventOpeningChest : PlayerEventBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ItemType { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaDuration TimeToOpen { get; set; }
        public override string EventDescription { get; }

        private PlayerEventOpeningChest()
        {
        }

        public PlayerEventOpeningChest(string itemId, MetaDuration duration)
        {
        }
    }
}
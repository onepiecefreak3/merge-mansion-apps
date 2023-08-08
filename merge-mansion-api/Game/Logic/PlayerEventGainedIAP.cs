using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using Metaplay.Core.InAppPurchase;
using System;

namespace Game.Logic
{
    [AnalyticsEvent(6, "Gifted IAP", 1, null, true, false, false)]
    [MetaBlockedMembers(new int[] { 1 })]
    public class PlayerEventGainedIAP : PlayerEventBase
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public InAppProductId ProductId;
        public override string EventDescription { get; }

        public PlayerEventGainedIAP()
        {
        }

        public PlayerEventGainedIAP(InAppProductId productId)
        {
        }
    }
}
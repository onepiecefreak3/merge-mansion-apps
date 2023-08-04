using Metaplay.Core.Model;
using Metaplay.Core.InAppPurchase;
using System;

namespace GameLogic.IAP
{
    [MetaSerializableDerived(1)]
    public class MergeMansionInAppPurchaseEvent : InAppPurchaseEvent
    {
        [MetaMember(17, (MetaMemberFlags)0)]
        public string OfferId { get; set; }

        public MergeMansionInAppPurchaseEvent()
        {
        }
    }
}
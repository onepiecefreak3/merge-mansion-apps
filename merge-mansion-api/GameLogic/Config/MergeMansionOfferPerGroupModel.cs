using Metaplay.Core.Model;
using Metaplay.Core.Offers;
using Metaplay.Core;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(101)]
    public class MergeMansionOfferPerGroupModel : MetaOfferPerGroupStateBase
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime? FirstPurchaseTimestamp { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool PurchasableNoted { get; set; }

        public MergeMansionOfferPerGroupModel()
        {
        }
    }
}
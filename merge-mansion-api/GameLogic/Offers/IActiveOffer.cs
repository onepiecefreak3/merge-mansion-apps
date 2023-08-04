using GameLogic.Config;
using System;

namespace GameLogic.Offers
{
    public interface IActiveOffer
    {
        IActiveOfferGroup ParentGroup { get; }

        IOfferVisuals Visuals { get; }

        MergeMansionOfferInfo Info { get; }

        int AvailablePurchases { get; }

        bool CanBePurchased { get; }
    }
}
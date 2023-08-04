using System;

namespace GameLogic.Config
{
    public interface IOfferVisuals
    {
        string TitleLocalizationId { get; }

        string SaleBadgeLocalizationId { get; }

        string OfferPaneId { get; }

        string BackgroundId { get; }

        string TitleColorHex { get; }

        string BackgroundColorHex { get; }

        string BackgroundGradientHex { get; }

        string LeftCharacterId { get; }

        string RightCharacterId { get; }
    // STUB
    }
}
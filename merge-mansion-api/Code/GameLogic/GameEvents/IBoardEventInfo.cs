using Metaplay.Core;
using Metaplay.Core.Offers;
using GameLogic.Story;
using GameLogic.Player.Requirements;
using GameLogic.Decorations;
using Metaplay.Core.Activables;
using GameLogic.Config;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace Code.GameLogic.GameEvents
{
    public interface IBoardEventInfo
    {
        IStringId Id { get; }

        OfferPlacementId BoardShopPlacementId { get; }

        OfferPlacementId BoardShopFlashPlacementId { get; }

        StoryDefinitionId EnterBoardDialogue { get; }

        PlayerRequirement UnlockRequirement { get; }

        DecorationInfo ActiveDecoration { get; }

        ExtendableEventParams ExtendableEventParams { get; }

        MetaRef<InAppProductInfo> ExtensionInAppProduct { get; }

        MetaDuration ExtensionPurchaseSafetyMargin { get; }

        List<PlayerReward> ExtensionRewards { get; }
    }
}
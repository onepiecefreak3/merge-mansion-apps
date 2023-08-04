using Metaplay.Core.Localization;
using Metaplay.Core.InAppPurchase;
using Metaplay.Core.Player;
using Metaplay.Core.Offers;
using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    public interface ISharedGameConfig : IGameConfig, IGameConfigDataResolver, IGameConfigDataRegistry
    {
        // RVA: -1 Offset: -1 Slot: 0
        GameConfigLibrary<LanguageId, LanguageInfo> Languages { get; }

        IGameConfigLibrary<InAppProductId, InAppProductInfoBase> InAppProducts { get; }

        IGameConfigLibrary<PlayerSegmentId, PlayerSegmentInfoBase> PlayerSegments { get; }

        IGameConfigLibrary<MetaOfferId, MetaOfferInfoBase> MetaOffers { get; }

        IGameConfigLibrary<MetaOfferId, MetaOfferInfoBase> MetaOffersTiered { get; }

        IGameConfigLibrary<MetaOfferGroupId, MetaOfferGroupInfoBase> MetaOfferGroups { get; }

        Dictionary<OfferPlacementId, List<MetaOfferGroupInfoBase>> MetaOfferGroupsPerPlacementInMostImportantFirstOrder { get; }

        Dictionary<MetaOfferId, List<MetaOfferGroupInfoBase>> MetaOfferContainingGroups { get; }
    //public abstract IGameConfigLibrary<InAppProductId, InAppProductInfoBase> InAppProducts { get; }
    //public abstract IGameConfigLibrary<PlayerSegmentId, PlayerSegmentInfoBase> PlayerSegments { get; }
    //public abstract IGameConfigLibrary<MetaOfferId, MetaOfferInfoBase> MetaOffers { get; }
    //public abstract IGameConfigLibrary<MetaOfferId, MetaOfferInfoBase> MetaOffersTiered { get; }
    //public abstract IGameConfigLibrary<MetaOfferGroupId, MetaOfferGroupInfoBase> MetaOfferGroups { get; }
    //public abstract OrderedDictionary<OfferPlacementId, List<MetaOfferGroupInfoBase>> MetaOfferGroupsPerPlacementInMostImportantFirstOrder { get; }
    //public abstract OrderedDictionary<MetaOfferId, List<MetaOfferGroupInfoBase>> MetaOfferContainingGroups { get; }
    //// Methods
    //// RVA: -1 Offset: -1 Slot: 1
    //public abstract IGameConfigLibrary<InAppProductId, InAppProductInfoBase> get_InAppProducts();
    //// RVA: -1 Offset: -1 Slot: 2
    //public abstract IGameConfigLibrary<PlayerSegmentId, PlayerSegmentInfoBase> get_PlayerSegments();
    //// RVA: -1 Offset: -1 Slot: 3
    //public abstract IGameConfigLibrary<MetaOfferId, MetaOfferInfoBase> get_MetaOffers();
    //// RVA: -1 Offset: -1 Slot: 4
    //public abstract IGameConfigLibrary<MetaOfferId, MetaOfferInfoBase> get_MetaOffersTiered();
    //// RVA: -1 Offset: -1 Slot: 5
    //public abstract IGameConfigLibrary<MetaOfferGroupId, MetaOfferGroupInfoBase> get_MetaOfferGroups();
    //// RVA: -1 Offset: -1 Slot: 6
    //public abstract OrderedDictionary<OfferPlacementId, List<MetaOfferGroupInfoBase>> get_MetaOfferGroupsPerPlacementInMostImportantFirstOrder();
    //// RVA: -1 Offset: -1 Slot: 7
    //public abstract OrderedDictionary<MetaOfferId, List<MetaOfferGroupInfoBase>> get_MetaOfferContainingGroups();
    }
}
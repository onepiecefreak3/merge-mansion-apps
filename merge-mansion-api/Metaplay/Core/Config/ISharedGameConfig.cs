using System.Collections.Generic;
using Metaplay.Metaplay.Core.InAppPurchase;
using Metaplay.Metaplay.Core.Localization;
using Metaplay.Metaplay.Core.Player;

namespace Metaplay.Metaplay.Core.Config
{
    public interface ISharedGameConfig : IGameConfig
    {
        //// Properties
        //LanguageInfo DefaultLanguage { get; }
        //IEnumerable<PlayerSegmentInfoBase> PlayerSegments { get; }
        //IEnumerable<InAppProductInfoBase> InAppProducts { get; }
        //IEnumerable<MetaOfferInfoBase> MetaOffers { get; }
        //IEnumerable<MetaOfferGroupInfoBase> MetaOfferGroups { get; }
        //Dictionary<OfferPlacementId, List<MetaOfferGroupInfoBase>> MetaOfferGroupsPerPlacementInMostImportantFirstOrder { get; }
        //      Dictionary<MetaOfferId, List<MetaOfferGroupInfoBase>> MetaOfferContainingGroups { get; }

        //// Methods

        //// RVA: -1 Offset: -1 Slot: 0
        ////public abstract LanguageInfo get_DefaultLanguage();

        // RVA: -1 Offset: -1 Slot: 1
        LanguageInfo TryGetLanguageInfo(LanguageId language);

        //// RVA: -1 Offset: -1 Slot: 2
        ////public abstract IEnumerable<PlayerSegmentInfoBase> get_PlayerSegments();

        //// RVA: -1 Offset: -1 Slot: 3
        //bool TryGetPlayerSegmentInfo(PlayerSegmentId id, out PlayerSegmentInfoBase info);

        //// RVA: -1 Offset: -1 Slot: 4
        ////public abstract IEnumerable<InAppProductInfoBase> get_InAppProducts();

        //// RVA: -1 Offset: -1 Slot: 5
        //bool TryGetInAppProductInfo(InAppProductId id, out InAppProductInfoBase info);

        //// RVA: -1 Offset: -1 Slot: 6
        ////public abstract IEnumerable<MetaOfferInfoBase> get_MetaOffers();

        //// RVA: -1 Offset: -1 Slot: 7
        //bool TryGetMetaOffer(MetaOfferId id, out MetaOfferInfoBase info);

        //// RVA: -1 Offset: -1 Slot: 8
        ////public abstract IEnumerable<MetaOfferGroupInfoBase> get_MetaOfferGroups();

        //// RVA: -1 Offset: -1 Slot: 9
        //bool TryGetMetaOfferGroup(MetaOfferGroupId id, out MetaOfferGroupInfoBase info);

        //// RVA: -1 Offset: -1 Slot: 10
        ////public abstract OrderedDictionary<OfferPlacementId, List<MetaOfferGroupInfoBase>> get_MetaOfferGroupsPerPlacementInMostImportantFirstOrder();

        //// RVA: -1 Offset: -1 Slot: 11
        ////public abstract OrderedDictionary<MetaOfferId, List<MetaOfferGroupInfoBase>> get_MetaOfferContainingGroups();
    }
}

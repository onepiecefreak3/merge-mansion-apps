using Metaplay.Core.Localization;
using Metaplay.Core.InAppPurchase;
using Metaplay.Core.Player;
using Metaplay.Core.Offers;
using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    public class SharedGameConfigBase : GameConfigBase, ISharedGameConfig, IGameConfig, IGameConfigDataResolver
    {
        private static IGameConfigLibrary<LanguageId, LanguageInfo> _defaultLanguages;
        private static IGameConfigLibrary<InAppProductId, InAppProductInfoBase> _defaultInAppProducts;
        private static IGameConfigLibrary<PlayerSegmentId, PlayerSegmentInfoBase> _defaultPlayerSegments;
        private static IGameConfigLibrary<MetaOfferId, MetaOfferInfoBase> _defaultOffers;
        private static IGameConfigLibrary<MetaOfferId, MetaOfferInfoBase> _defaultOffersTiered;
        private static IGameConfigLibrary<MetaOfferGroupId, MetaOfferGroupInfoBase> _defaultOfferGroups;
        private IGameConfigLibrary<LanguageId, LanguageInfo> _languagesIntegration;
        private IGameConfigLibrary<InAppProductId, InAppProductInfoBase> _inAppProductsIntegration;
        private IGameConfigLibrary<PlayerSegmentId, PlayerSegmentInfoBase> _playerSegmentsIntegration;
        private IGameConfigLibrary<MetaOfferId, MetaOfferInfoBase> _offersIntegration;
        private IGameConfigLibrary<MetaOfferId, MetaOfferInfoBase> _offersTieredIntegration;
        private IGameConfigLibrary<MetaOfferGroupId, MetaOfferGroupInfoBase> _offerGroupsIntegration;
        GameConfigLibrary<LanguageId, LanguageInfo> Metaplay.Core.Config.ISharedGameConfig.Languages { get; }

        IGameConfigLibrary<InAppProductId, InAppProductInfoBase> Metaplay.Core.Config.ISharedGameConfig.InAppProducts { get; }

        IGameConfigLibrary<PlayerSegmentId, PlayerSegmentInfoBase> Metaplay.Core.Config.ISharedGameConfig.PlayerSegments { get; }

        IGameConfigLibrary<MetaOfferId, MetaOfferInfoBase> Metaplay.Core.Config.ISharedGameConfig.MetaOffers { get; }

        IGameConfigLibrary<MetaOfferId, MetaOfferInfoBase> Metaplay.Core.Config.ISharedGameConfig.MetaOffersTiered { get; }

        IGameConfigLibrary<MetaOfferGroupId, MetaOfferGroupInfoBase> Metaplay.Core.Config.ISharedGameConfig.MetaOfferGroups { get; }
        public Dictionary<OfferPlacementId, List<MetaOfferGroupInfoBase>> MetaOfferGroupsPerPlacementInMostImportantFirstOrder { get; set; }
        public Dictionary<MetaOfferId, List<MetaOfferGroupInfoBase>> MetaOfferContainingGroups { get; set; }

        public SharedGameConfigBase()
        {
        }
    }
}
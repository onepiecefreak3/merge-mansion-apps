using Metaplay.Core.InAppPurchase;
using Metaplay.Core.Localization;
using Metaplay.Core.Offers;
using Metaplay.Core.Player;
using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    public class SharedGameConfigTemplate<TInAppProductInfo, TPlayerSegmentInfo, TMetaOfferInfo, TMetaOfferGroupInfo> : GameConfigBase, ISharedGameConfig, IGameConfig, IGameConfigDataResolver, IGameConfigDataRegistry
    {
        [GameConfigEntry("Languages")]
        public IGameConfigLibrary<LanguageId, LanguageInfo> Languages { get; set; }

        [GameConfigEntry("InAppProducts", requireArchiveEntry: false)]
        public GameConfigLibrary<InAppProductId, TInAppProductInfo> InAppProducts { get; set; }

        [GameConfigEntry("PlayerSegments", requireArchiveEntry: false)]
        public GameConfigLibrary<PlayerSegmentId, TPlayerSegmentInfo> PlayerSegments { get; set; }

        [GameConfigEntry("Offers", requireArchiveEntry: false)]
        public GameConfigLibrary<MetaOfferId, TMetaOfferInfo> Offers { get; set; }

        [GameConfigEntry("OfferGroups", requireArchiveEntry: false)]
        public GameConfigLibrary<MetaOfferGroupId, TMetaOfferGroupInfo> OfferGroups { get; set; }

        [GameConfigEntryTransform(typeof(MetaOfferSourceConfigItemBase))]
        [GameConfigEntry("TieredOfferItems", true, false, true)]
        public GameConfigLibrary<MetaOfferId, TMetaOfferInfo> TieredOfferItems { get; set; }

        public LanguageInfo TryGetLanguageInfo(LanguageId language)
        {
            if (language == null)
                return null;
            var languageInfo = (LanguageInfo)Languages.GetInfoByKey(language);
            if (languageInfo == null)
                return null;
            return languageInfo;
        }

        IGameConfigLibrary<InAppProductId, InAppProductInfoBase> Metaplay.Core.Config.ISharedGameConfig.InAppProducts { get; }

        IGameConfigLibrary<PlayerSegmentId, PlayerSegmentInfoBase> Metaplay.Core.Config.ISharedGameConfig.PlayerSegments { get; }

        IGameConfigLibrary<MetaOfferId, MetaOfferInfoBase> Metaplay.Core.Config.ISharedGameConfig.MetaOffers { get; }

        IGameConfigLibrary<MetaOfferId, MetaOfferInfoBase> Metaplay.Core.Config.ISharedGameConfig.MetaOffersTiered { get; }

        IGameConfigLibrary<MetaOfferGroupId, MetaOfferGroupInfoBase> Metaplay.Core.Config.ISharedGameConfig.MetaOfferGroups { get; }
        public Dictionary<OfferPlacementId, List<MetaOfferGroupInfoBase>> MetaOfferGroupsPerPlacementInMostImportantFirstOrder { get; set; }
        public Dictionary<MetaOfferId, List<MetaOfferGroupInfoBase>> MetaOfferContainingGroups { get; set; }

        public SharedGameConfigTemplate()
        {
        }
    }
}
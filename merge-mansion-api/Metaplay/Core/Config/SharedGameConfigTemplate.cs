using Metaplay.Core.InAppPurchase;
using Metaplay.Core.Localization;
using Metaplay.Core.Offers;
using Metaplay.Core.Player;

namespace Metaplay.Core.Config
{
    public class SharedGameConfigTemplate<TInAppProductInfo, TPlayerSegmentInfo, TMetaOfferInfo, TMetaOfferGroupInfo> : GameConfigBase, ISharedGameConfig
    {
        [GameConfigEntry("Languages")]
        public GameConfigLibrary<LanguageId, LanguageInfo> Languages { get; set; }
        [GameConfigEntry("InAppProducts", requireArchiveEntry: false)]
        public GameConfigLibrary<InAppProductId, TInAppProductInfo> InAppProducts { get; set; }
        [GameConfigEntry("PlayerSegments", requireArchiveEntry: false)]
        public GameConfigLibrary<PlayerSegmentId, TPlayerSegmentInfo> PlayerSegments { get; set; }
        [GameConfigEntry("Offers", requireArchiveEntry: false)]
        public GameConfigLibrary<MetaOfferId, TMetaOfferInfo> Offers { get; set; }
        [GameConfigEntry("OfferGroups", requireArchiveEntry: false)]
        public GameConfigLibrary<MetaOfferGroupId, TMetaOfferGroupInfo> OfferGroups { get; set; }

        public LanguageInfo TryGetLanguageInfo(LanguageId language)
        {
            if (language == null)
                return null;

            if (!Languages.TryGetValue(language, out var languageInfo))
                return null;

            return languageInfo;
        }
    }
}

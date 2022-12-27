using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.InAppPurchase;
using Metaplay.Metaplay.Core.Localization;
using Metaplay.Metaplay.Core.Player;

namespace Metaplay.Metaplay.Core.Config
{
    public class SharedGameConfigTemplate<TInAppProductInfo, TPlayerSegmentInfo, TMetaOfferInfo, TMetaOfferGroupInfo> : GameConfigBase, ISharedGameConfig
    {
        public GameConfigLibrary<LanguageId, LanguageInfo> Languages { get; set; }
        public GameConfigLibrary<InAppProductId, TInAppProductInfo> InAppProducts { get; set; }
        public GameConfigLibrary<PlayerSegmentId, TPlayerSegmentInfo> PlayerSegments { get; set; }

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

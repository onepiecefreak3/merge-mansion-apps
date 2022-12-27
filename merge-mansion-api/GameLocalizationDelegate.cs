using System.Collections.Generic;
using Metaplay.Metaplay.Core.Localization;
using Metaplay.Metaplay.Unity;
using Metaplay.Metaplay.Unity.DefaultIntegration;

namespace Metaplay
{
    internal class GameLocalizationDelegate : DefaultMetaplayLocalizationDelegate
    {
        public override LocalizationManagerAutoBehaviorFlag AutoFlags => (LocalizationManagerAutoBehaviorFlag)5;

        public override LanguageId GetAppStartDefaultLanguage(HashSet<LanguageId> availableLanguages)
        {
            var detectLang = LocMan.DetectLanguage();
            var langString = LocToString.Stringify(detectLang);
            var langId = LanguageId.FromString(langString);

            if (availableLanguages.Contains(langId))
                return langId;

            return null;
        }
    }
}

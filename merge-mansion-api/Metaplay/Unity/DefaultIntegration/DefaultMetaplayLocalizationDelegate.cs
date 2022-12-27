using System;
using System.Collections.Generic;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Localization;

namespace Metaplay.Metaplay.Unity.DefaultIntegration
{
    public class DefaultMetaplayLocalizationDelegate : IMetaplayClientLocalizationDelegate
    {
        // 0x10
        public ISessionContextProvider SessionContext { get; set; }

        public virtual LocalizationStorageFormat BuiltinFormat => LocalizationStorageFormat.Binary;
        public virtual LocalizationManagerAutoBehaviorFlag AutoFlags => (LocalizationManagerAutoBehaviorFlag)7;

        public virtual LanguageId GetAppStartDefaultLanguage(HashSet<LanguageId> availableLanguages)
        {
            var deviceLang = DeviceLanguage.TryGetDeviceLanguageId();
            if (deviceLang != null && availableLanguages.Contains(deviceLang))
                return deviceLang;

            var defLang = LanguageId.FromString("en");
            if (!availableLanguages.Contains(defLang))
                return null;

            return defLang;
        }

        public bool ValidateLanguage(LocalizationLanguage newLanguage)
        {
            return true;
        }

        public void OnActiveLanguageChanged()
        {
        }

        public void OnLanguagesChanged()
        {
        }

        public void EnqueueSelectLanguageAction(LanguageInfo languageInfo, ContentHash localizationVersion)
        {
            throw new NotImplementedException();
        }
    }
}

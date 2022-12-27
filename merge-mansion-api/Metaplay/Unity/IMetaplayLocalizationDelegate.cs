using System.Collections.Generic;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Localization;

namespace Metaplay.Metaplay.Unity
{
    public interface IMetaplayLocalizationDelegate
    {
        // RVA: -1 Offset: -1 Slot: 0
        LocalizationStorageFormat BuiltinFormat { get; }

        // RVA: -1 Offset: -1 Slot: 1
        LocalizationManagerAutoBehaviorFlag AutoFlags { get; }

        // RVA: -1 Offset: -1 Slot: 2
        LanguageId GetAppStartDefaultLanguage(HashSet<LanguageId> availableLanguages);

        // RVA: -1 Offset: -1 Slot: 3
        bool ValidateLanguage(LocalizationLanguage newLanguage);

        // RVA: -1 Offset: -1 Slot: 4
        void OnActiveLanguageChanged();

        // RVA: -1 Offset: -1 Slot: 5
        void OnLanguagesChanged();

        // RVA: -1 Offset: -1 Slot: 6
        void EnqueueSelectLanguageAction(LanguageInfo languageInfo, ContentHash localizationVersion);
	}
}

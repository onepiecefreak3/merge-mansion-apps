using System.Collections.Generic;
using Metaplay.Metaplay.Core.Localization;

namespace Metaplay
{
    public static class LocCommon
    {
        // 0x0
        public static readonly Dictionary<LocalizationLanguageMetacore, (string filename, string localName, LanguageId languageId)> languageConfigs =
            new Dictionary<LocalizationLanguageMetacore, (string filename, string localName, LanguageId languageId)>
            {
                [LocalizationLanguageMetacore.English] = ("English", "English", LanguageId.FromString(LocToString.Stringify(LocalizationLanguageMetacore.English))),
                [LocalizationLanguageMetacore.French] = ("French", "Français", LanguageId.FromString(LocToString.Stringify(LocalizationLanguageMetacore.French))),
                [LocalizationLanguageMetacore.German] = ("German", "Deutsch", LanguageId.FromString(LocToString.Stringify(LocalizationLanguageMetacore.German))),
                [LocalizationLanguageMetacore.Spanish] = ("Spanish", "Español", LanguageId.FromString(LocToString.Stringify(LocalizationLanguageMetacore.Spanish))),
                [LocalizationLanguageMetacore.Italian] = ("Italian", "Italiano", LanguageId.FromString(LocToString.Stringify(LocalizationLanguageMetacore.Italian))),
                [LocalizationLanguageMetacore.Portuguese] = ("BrazilianPortuguese", "Português", LanguageId.FromString(LocToString.Stringify(LocalizationLanguageMetacore.Portuguese))),
                [LocalizationLanguageMetacore.Russian] = ("Russian", "Русский", LanguageId.FromString(LocToString.Stringify(LocalizationLanguageMetacore.Russian))),
                [LocalizationLanguageMetacore.Japanese] = ("Japanese", "やまと", LanguageId.FromString(LocToString.Stringify(LocalizationLanguageMetacore.Japanese))),
                [LocalizationLanguageMetacore.Korean] = ("Korean", "한국어", LanguageId.FromString(LocToString.Stringify(LocalizationLanguageMetacore.Korean)))
            };
    }
}

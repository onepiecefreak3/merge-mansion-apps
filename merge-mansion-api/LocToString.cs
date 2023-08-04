using System.Collections.Generic;

public static class LocToString
{
    // 0x0
    private static readonly Dictionary<LocalizationLanguageMetacore, string> enumTo2CharCode = new()
    {
        [LocalizationLanguageMetacore.English] = "en",
        [LocalizationLanguageMetacore.French] = "fr",
        [LocalizationLanguageMetacore.German] = "de",
        [LocalizationLanguageMetacore.Spanish] = "es",
        [LocalizationLanguageMetacore.Italian] = "it",
        [LocalizationLanguageMetacore.Portuguese] = "pt",
        [LocalizationLanguageMetacore.Russian] = "ru",
        [LocalizationLanguageMetacore.Japanese] = "ja",
        [LocalizationLanguageMetacore.Korean] = "ko"
    };

    public static string Stringify(LocalizationLanguageMetacore localizationLanguage)
    {
        return enumTo2CharCode[localizationLanguage];
    }
}
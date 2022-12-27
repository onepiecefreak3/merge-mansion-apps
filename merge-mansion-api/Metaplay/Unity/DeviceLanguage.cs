using Metaplay.Metaplay.Core.Localization;
using Metaplay.UnityEngine;

namespace Metaplay.Metaplay.Unity
{
    public static class DeviceLanguage
    {
        private static readonly LanguageToIdMapping[] LanguageMappings =
        {
            new LanguageToIdMapping(SystemLanguage.Afrikaans,"af"),
            new LanguageToIdMapping(SystemLanguage.Arabic,"ar"),
            new LanguageToIdMapping(SystemLanguage.Basque,"eu"),
            new LanguageToIdMapping(SystemLanguage.Belarusian,"be"),
            new LanguageToIdMapping(SystemLanguage.Bulgarian,"bg"),
            new LanguageToIdMapping(SystemLanguage.Catalan,"ca"),
            new LanguageToIdMapping(SystemLanguage.Czech,"cs"),
            new LanguageToIdMapping(SystemLanguage.Danish,"da"),
            new LanguageToIdMapping(SystemLanguage.Dutch,"nl"),
            new LanguageToIdMapping(SystemLanguage.English,"en"),
            new LanguageToIdMapping(SystemLanguage.Estonian,"et"),
            new LanguageToIdMapping(SystemLanguage.Faroese,"fo"),
            new LanguageToIdMapping(SystemLanguage.Finnish,"fi"),
            new LanguageToIdMapping(SystemLanguage.French,"fr"),
            new LanguageToIdMapping(SystemLanguage.German,"de"),
            new LanguageToIdMapping(SystemLanguage.Greek,"el"),
            new LanguageToIdMapping(SystemLanguage.Hebrew,"he"),
            new LanguageToIdMapping(SystemLanguage.Icelandic,"hu"),
            new LanguageToIdMapping(SystemLanguage.Indonesian,"is"),
            new LanguageToIdMapping(SystemLanguage.Italian,"id"),
            new LanguageToIdMapping(SystemLanguage.Japanese,"it"),
            new LanguageToIdMapping(SystemLanguage.Korean,"ja"),
            new LanguageToIdMapping(SystemLanguage.Latvian,"ko"),
            new LanguageToIdMapping(SystemLanguage.Lithuanian,"lv"),
            new LanguageToIdMapping(SystemLanguage.Norwegian,"lt"),
            new LanguageToIdMapping(SystemLanguage.Polish,"no"),
            new LanguageToIdMapping(SystemLanguage.Portuguese,"pt"),
            new LanguageToIdMapping(SystemLanguage.Romanian,"ro"),
            new LanguageToIdMapping(SystemLanguage.Russian,"ru"),
            new LanguageToIdMapping(SystemLanguage.SerboCroatian,"sh"),
            new LanguageToIdMapping(SystemLanguage.Slovak,"sk"),
            new LanguageToIdMapping(SystemLanguage.Slovenian,"sl"),
            new LanguageToIdMapping(SystemLanguage.Spanish,"es"),
            new LanguageToIdMapping(SystemLanguage.Swedish,"sv"),
            new LanguageToIdMapping(SystemLanguage.Thai,"th"),
            new LanguageToIdMapping(SystemLanguage.Turkish,"tr"),
            new LanguageToIdMapping(SystemLanguage.Ukrainian,"uk"),
            new LanguageToIdMapping(SystemLanguage.Vietnamese,"vi"),
            new LanguageToIdMapping(SystemLanguage.ChineseSimplified,"zh-Hans"),
            new LanguageToIdMapping(SystemLanguage.ChineseTraditional,"zh-Hant")
        }; // 0x0

        public static LanguageId TryGetDeviceLanguageId()
        {
            for (var i = 0; i < LanguageMappings.Length; i++)
            {
                if (LanguageMappings[i].Language == Application.SystemLanguage)
                    return LanguageId.FromString(LanguageMappings[i].LanguageId);
            }

            return null;
        }

        private readonly struct LanguageToIdMapping
        {
            public readonly SystemLanguage Language; // 0x0
            public readonly string LanguageId; // 0x8

            public LanguageToIdMapping(SystemLanguage language, string languageId)
            {
                Language = language;
                LanguageId = languageId;
            }
        }
    }
}

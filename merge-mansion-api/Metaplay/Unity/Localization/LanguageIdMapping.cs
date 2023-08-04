using Metaplay.Core;
using Metaplay.Core.Localization;
using UnityEngine;

namespace Metaplay.Unity.Localization
{
    public class LanguageIdMapping : IMetaIntegrationSingleton<LanguageIdMapping>, IMetaIntegration<LanguageIdMapping>, IMetaIntegrationSingleton, IRequireSingleConcreteType
    {
        private readonly LanguageToIdMapping[] _languageMappings; // 0x10

        public virtual LanguageId TryGetLanguageIdForDeviceLanguage(SystemLanguage systemLanguage)
        {
            for (var i = 0; i < _languageMappings.Length; i++)
            {
                if (_languageMappings[i].Language == systemLanguage)
                    return LanguageId.FromString(_languageMappings[i].Bcp47Prefix);
            }

            return null;
        }
        
        public LanguageIdMapping()
        {
            _languageMappings = new LanguageToIdMapping[]
            {
                new (SystemLanguage.Afrikaans, "af"),
                new (SystemLanguage.Arabic, "ar"),
                new (SystemLanguage.Basque, "eu"),
                new (SystemLanguage.Belarusian, "be"),
                new (SystemLanguage.Bulgarian, "bg"),
                new (SystemLanguage.Catalan, "ca"),
                new (SystemLanguage.Czech, "cs"),
                new (SystemLanguage.Danish, "da"),
                new (SystemLanguage.Dutch, "nl"),
                new (SystemLanguage.English, "en"),
                new (SystemLanguage.Estonian, "et"),
                new (SystemLanguage.Faroese, "fo"),
                new (SystemLanguage.Finnish, "fi"),
                new (SystemLanguage.French, "fr"),
                new (SystemLanguage.German, "de"),
                new (SystemLanguage.Greek, "el"),
                new (SystemLanguage.Hebrew, "he"),
                new (SystemLanguage.Icelandic, "hu"),
                new (SystemLanguage.Indonesian, "is"),
                new (SystemLanguage.Italian, "id"),
                new (SystemLanguage.Japanese, "it"),
                new (SystemLanguage.Korean, "ja"),
                new (SystemLanguage.Latvian, "ko"),
                new (SystemLanguage.Lithuanian, "lv"),
                new (SystemLanguage.Norwegian, "lt"),
                new (SystemLanguage.Polish, "no"),
                new (SystemLanguage.Portuguese, "pt"),
                new (SystemLanguage.Romanian, "ro"),
                new (SystemLanguage.Russian, "ru"),
                new (SystemLanguage.SerboCroatian, "sh"),
                new (SystemLanguage.Slovak, "sk"),
                new (SystemLanguage.Slovenian, "sl"),
                new (SystemLanguage.Spanish, "es"),
                new (SystemLanguage.Swedish, "sv"),
                new (SystemLanguage.Thai, "th"),
                new (SystemLanguage.Turkish, "tr"),
                new (SystemLanguage.Ukrainian, "uk"),
                new (SystemLanguage.Vietnamese, "vi"),
                new (SystemLanguage.ChineseSimplified, "zh-Hans"),
                new (SystemLanguage.ChineseTraditional, "zh-Hant")
            };
        }

        private readonly struct LanguageToIdMapping
        {
            public readonly SystemLanguage Language; // 0x0
            public readonly string Bcp47Prefix; // 0x8

            public LanguageToIdMapping(SystemLanguage language, string bcp47Prefix)
            {
                Language = language;
                Bcp47Prefix = bcp47Prefix;
            }
        }
    }
}

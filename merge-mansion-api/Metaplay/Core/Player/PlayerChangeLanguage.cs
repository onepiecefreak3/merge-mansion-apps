using Metaplay.Metaplay.Core.Localization;

namespace Metaplay.Metaplay.Core.Player
{
    public class PlayerChangeLanguage : PlayerActionCore<IPlayerModelBase>
    {
        public LanguageInfo Language { get; set; } // 0x18
        public ContentHash LocalizationVersion { get; set; } // 0x20

        public PlayerChangeLanguage(LanguageInfo language, ContentHash localizationVersion)
        {
            Language = language;
            LocalizationVersion = localizationVersion;
        }
    }
}

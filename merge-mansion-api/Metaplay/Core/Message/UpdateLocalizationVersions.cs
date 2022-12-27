using System.Collections.Generic;
using Metaplay.Metaplay.Core.Localization;

namespace Metaplay.Metaplay.Core.Message
{
    [MetaMessage(9, MessageDirection.ServerToClient, false)]
    public class UpdateLocalizationVersions : MetaMessage
    {
        public Dictionary<LanguageId, ContentHash> LocalizationVersions { get; set; } // 0x10

        private UpdateLocalizationVersions() { }
        public UpdateLocalizationVersions(Dictionary<LanguageId, ContentHash> localizationVersions) { }
    }
}

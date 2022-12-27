using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Localization
{
    public class LanguageInfo : IGameConfigData<LanguageId>
    {
        [MetaMember(1, 0)]
        public LanguageId LanguageId { get; set; }
        [MetaMember(2, 0)]
        public string DisplayName { get; set; }

        public LanguageId ConfigKey => LanguageId;
    }
}

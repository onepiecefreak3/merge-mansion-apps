using Metaplay.Core.Config;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Localization
{
    [MetaSerializable]
    public class LanguageInfo : IGameConfigData<LanguageId>, IGameConfigData
    {
        [MetaMember(1, 0)]
        public LanguageId LanguageId { get; set; }

        [MetaMember(2, 0)]
        public string DisplayName { get; set; }
        public LanguageId ConfigKey => LanguageId;

        public LanguageInfo()
        {
        }

        public LanguageInfo(LanguageId id, string name)
        {
        }
    }
}
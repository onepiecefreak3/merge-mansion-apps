using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GameLogic.Config.Shop
{
    [MetaSerializable]
    public class ShopLayout : IGameConfigData<ShopLayoutId>, IGameConfigData, IGameConfigKey<ShopLayoutId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ShopLayoutId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private List<ShopSectionId> SectionsList { get; set; }

        [IgnoreDataMember]
        public IEnumerable<ShopSectionId> Sections { get; }

        public ShopLayout()
        {
        }

        public ShopLayout(ShopLayoutId configKey, List<ShopSectionId> sectionsList)
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace GameLogic.Config.Shop
{
    [MetaSerializable]
    public class ShopLayout : IGameConfigData<ShopLayoutId>, IGameConfigData, IHasGameConfigKey<ShopLayoutId>
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

        [MetaMember(3, (MetaMemberFlags)0)]
        private List<ShopSectionId> MoreSectionsList { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool UseListView { get; set; }

        [IgnoreDataMember]
        public bool HasMoreSections { get; }

        [IgnoreDataMember]
        public IEnumerable<ShopSectionId> MoreSections { get; }

        public ShopLayout(ShopLayoutId configKey, List<ShopSectionId> sectionsList, List<ShopSectionId> moreSectionsList, bool useListView)
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace Code.GameLogic.Hotspots
{
    [MetaSerializable]
    public class CustomHotspotTablesInfo : IGameConfigData<CustomHotspotTableId>, IGameConfigData, IHasGameConfigKey<CustomHotspotTableId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CustomHotspotTableId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string Theme { get; set; }

        public CustomHotspotTablesInfo()
        {
        }

        public CustomHotspotTablesInfo(CustomHotspotTableId id, string theme)
        {
        }
    }
}
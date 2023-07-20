using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.ConfigPrefabs;
using Metaplay.GameLogic.Merge;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventCurrencyInfo : IGameConfigData<EventCurrencyId>
    {
        [MetaMember(1, 0)]
        public EventCurrencyId EventCurrencyId { get; set; }
        [MetaMember(2, 0)]
        public string DisplayName { get; set; }
        [MetaMember(3, 0)]
        public string Description { get; set; }
        [MetaMember(4, 0)]
        public MergeBoardId EventBoardId { get; set; }
        [MetaMember(5, 0)]
        public string NameLocId { get; set; }
        [MetaMember(6, 0)]
        public string DescLocId { get; set; }
        [MetaMember(7, 0)]
        public ConfigAssetPackId AssetPackId { get; set; }

        public EventCurrencyId ConfigKey => EventCurrencyId;
    }
}

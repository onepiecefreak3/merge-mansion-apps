using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Config;
using Metaplay.GameLogic.ConfigPrefabs;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Activables;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class ShopEventInfo: IGameConfigData<EventId>
    {
        [MetaMember(1, 0)]
        public EventId EventId { get; set; }
        [MetaMember(2, 0)]
        public string DisplayName { get; set; }
        [MetaMember(3, 0)]
        public string Description { get; set; }
        [MetaMember(4, 0)]
        public MetaActivableParams ActivableParams { get; set; }
        [MetaMember(5, 0)]
        public MetaRef<EventCurrencyInfo> EventCurrencyInfo { get; set; }
        [MetaMember(10, 0)]
        public List<MetaRef<EventOfferInfo>> EventShopOfferInfos { get; set; }
        [MetaMember(11, 0)]
        public MetaRef<EventLevels> Levels { get; set; }
        [MetaMember(16, 0)]
        public List<MetaRef<BoardEventInfo>> HintedBoardEventInfos { get; set; }
        [MetaMember(18, 0)]
        public ExtendableEventParams ExtendableEventParams { get; set; }
        [MetaMember(19, 0)]
        public MetaDuration ExtensionPurchaseSafetyMargin { get; set; }
        [MetaMember(20, 0)]
        public MetaRef<InAppProductInfo> ExtensionInAppProduct { get; set; }
        [MetaMember(22, 0)]
        public ConfigPrefabId EndPopupId { get; set; }
        [MetaMember(23, 0)]
        public ConfigPrefabId ShopPopupId { get; set; }
        [MetaMember(28, 0)]
        public ConfigPrefabId HudButtonId { get; set; }

        public EventId ConfigKey => EventId;
    }
}

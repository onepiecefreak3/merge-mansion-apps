using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.Schedule;
using Metaplay.Core.Player;

namespace GameLogic.Config.DecorationShop
{
    public class DecorationShopSource : IConfigItemSource<DecorationShopInfo, DecorationShopId>, IGameConfigSourceItem<DecorationShopId, DecorationShopInfo>, IHasGameConfigKey<DecorationShopId>
    {
        public DecorationShopId ConfigKey { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private string NameLocId { get; set; }
        private List<MetaRef<DecorationShopSetInfo>> Sets { get; set; }
        private List<MetaRef<PlayerSegmentInfo>> Segments { get; set; }
        private bool IsEnabled { get; set; }
        private MetaScheduleBase Schedule { get; set; }
        private string UnlockRequirementType { get; set; }
        private string UnlockRequirementId { get; set; }
        private string UnlockRequirementAmount { get; set; }
        private string UnlockRequirementAux0 { get; set; }

        public DecorationShopSource()
        {
        }

        private int Priority { get; set; }
    }
}
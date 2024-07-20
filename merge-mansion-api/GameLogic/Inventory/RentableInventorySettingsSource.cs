using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.Inventory
{
    public class RentableInventorySettingsSource : IConfigItemSource<RentableInventorySettings, RentableInventorySettingsId>, IGameConfigSourceItem<RentableInventorySettingsId, RentableInventorySettings>, IHasGameConfigKey<RentableInventorySettingsId>
    {
        public List<long> BatchPrices;
        public Currencies BatchPriceCurrency;
        public int BatchSlotCount;
        public int BatchExpireTime;
        public int MaximumBatches;
        public RentableInventorySettingsId ConfigKey { get; set; }

        public RentableInventorySettingsSource()
        {
        }
    }
}
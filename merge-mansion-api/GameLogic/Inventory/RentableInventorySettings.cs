using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;

namespace GameLogic.Inventory
{
    [MetaSerializable]
    public class RentableInventorySettings : IGameConfigData<RentableInventorySettingsId>, IGameConfigData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private RentableInventorySettingsId Id { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<long> BatchPrice { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public Currencies BatchPriceCurrency { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int BatchSlotCount { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int BatchExpireTime { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int MaximumBatches { get; set; }
        public RentableInventorySettingsId ConfigKey => Id;

        public RentableInventorySettings()
        {
        }

        public RentableInventorySettings(RentableInventorySettingsId id, List<long> batchPrice, Currencies batchPriceCurrency, int batchSlotCount, int batchExpireTime, int maximumBatches)
        {
        }
    }
}
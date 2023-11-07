using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class InventorySlotsConfig : IGameConfigData<InventorySlotId>, IGameConfigData, IGameConfigKey<InventorySlotId>
    {
        [MetaMember(1, 0)]
        public InventorySlotId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public Currencies Currency { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Cost { get; set; }

        public InventorySlotsConfig()
        {
        }

        public InventorySlotsConfig(int slotIndex, Currencies currency, int cost)
        {
        }

        public InventorySlotsConfig(InventorySlotId slotId, Currencies currency, int cost)
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using GameLogic.Player.Requirements;
using System;
using System.Linq;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class ProducerInventorySlotConfig : IGameConfigData<ProducerInventorySlotId>, IGameConfigData, IHasGameConfigKey<ProducerInventorySlotId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private ProducerInventorySlotId SlotId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private List<PlayerRequirement> TeaseRequirements { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private List<PlayerRequirement> UnlockRequirements { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int SlotIndex { get; set; }

        public ProducerInventorySlotId ConfigKey => SlotId;
        public PlayerRequirement UnlockRequirement => UnlockRequirements.FirstOrDefault();

        public ProducerInventorySlotConfig()
        {
        }

        public ProducerInventorySlotConfig(ProducerInventorySlotId slotId, IEnumerable<PlayerRequirement> teaseRequirements, IEnumerable<PlayerRequirement> unlockRequirements)
        {
        }
    }
}
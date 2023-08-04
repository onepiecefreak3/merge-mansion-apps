using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.Player.Requirements;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using System.Runtime.Serialization;

namespace Code.GameLogic.FlashSales
{
    [MetaSerializable]
    public class FlashSaleGroupDefinition : IGameConfigData<FlashSaleGroupId>, IGameConfigData, IHasRequirements
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public FlashSaleGroupId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Weight { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<MetaRef<FlashSaleDefinition>> OfferRefs { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public FlashSaleSlotId SlotId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        private List<PlayerRequirement> PlayerRequirements { get; set; }

        [IgnoreDataMember]
        public List<PlayerRequirement> Requirements { get; }

        [IgnoreDataMember]
        private IEnumerable<FlashSaleDefinition> Offers { get; }

        public FlashSaleGroupDefinition()
        {
        }

        public FlashSaleGroupDefinition(FlashSaleGroupId configKey, int weight, List<MetaRef<FlashSaleDefinition>> offers, FlashSaleSlotId slotId, List<PlayerRequirement> playerRequirements)
        {
        }
    }
}
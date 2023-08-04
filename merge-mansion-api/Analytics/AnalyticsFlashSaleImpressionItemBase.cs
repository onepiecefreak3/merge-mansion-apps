using Metaplay.Core.Model;
using Metaplay.Core.Serialization;
using GameLogic.Config.Costs;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [MetaSerializable]
    [MetaReservedMembers(100, 199)]
    [MetaDeserializationConvertFromConcreteDerivedType(typeof(AnalyticsFlashSaleImpressionItem))]
    public abstract class AnalyticsFlashSaleImpressionItemBase
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public ICost Cost { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        [JsonProperty("slot_id")]
        public int SlotId { get; set; }

        public AnalyticsFlashSaleImpressionItemBase()
        {
        }

        public AnalyticsFlashSaleImpressionItemBase(ICost cost, int slotId)
        {
        }
    }
}
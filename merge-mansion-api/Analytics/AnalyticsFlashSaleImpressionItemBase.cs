using Metaplay.Core.Model;
using Metaplay.Core.Serialization;
using GameLogic.Config.Costs;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Analytics
{
    [MetaDeserializationConvertFromConcreteDerivedType(typeof(AnalyticsFlashSaleImpressionItem))]
    [MetaReservedMembers(100, 199)]
    [MetaSerializable]
    public abstract class AnalyticsFlashSaleImpressionItemBase
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public ICost Cost { get; set; }

        [JsonProperty("slot_id")]
        [MetaMember(101, (MetaMemberFlags)0)]
        public int SlotId { get; set; }

        public AnalyticsFlashSaleImpressionItemBase()
        {
        }

        public AnalyticsFlashSaleImpressionItemBase(ICost cost, int slotId)
        {
        }

        [JsonProperty("attachment")]
        [Description("Attachment")]
        [MetaMember(102, (MetaMemberFlags)0)]
        public string Attachment { get; set; }

        [MetaMember(103, (MetaMemberFlags)0)]
        [JsonProperty("attachment_amount")]
        [Description("Attachment amount")]
        public int AttachmentAmount { get; set; }

        public AnalyticsFlashSaleImpressionItemBase(ICost cost, int slotId, string attachment, int attachmentAmount)
        {
        }
    }
}
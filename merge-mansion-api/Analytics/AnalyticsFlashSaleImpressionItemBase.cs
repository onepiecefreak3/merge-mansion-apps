using Metaplay.Core.Model;
using Metaplay.Core.Serialization;
using GameLogic.Config.Costs;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Analytics
{
    [MetaReservedMembers(100, 199)]
    [MetaSerializable]
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

        [JsonProperty("attachment")]
        [Description("Attachment")]
        [MetaMember(102, (MetaMemberFlags)0)]
        public string Attachment { get; set; }

        [JsonProperty("attachment_amount")]
        [Description("Attachment amount")]
        [MetaMember(103, (MetaMemberFlags)0)]
        public int AttachmentAmount { get; set; }

        public AnalyticsFlashSaleImpressionItemBase(ICost cost, int slotId, string attachment, int attachmentAmount)
        {
        }
    }
}
using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using GameLogic.Player;
using GameLogic;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 2, 10 })]
    [AnalyticsEvent(115, "Currency sink", 1, null, false, true, false)]
    public class AnalyticsEventCurrencySink : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("sink_type")]
        [Description("Type of currency sink")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public CurrencySink CurrencySinkTag { get; set; }

        [JsonProperty("cost")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Cost of the purchase/sink in game resources")]
        public GameResourceCost GameResourceCost { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("New balance of currency received via game mechanics")]
        [JsonProperty("new_saldo")]
        public long NewFreeCurrencySaldo { get; set; }

        [JsonProperty("new_saldo_hard")]
        [Description("New balance of currency received via real money purchases")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public long NewHardCurrencySaldo { get; set; }

        [JsonProperty("cost_soft")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Cost of purchase in soft currency (coins)")]
        public long CostSoft { get; set; }

        [Description("Cost of purchase in hard currency (gems)")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("cost_hard")]
        public long CostHard { get; set; }

        [Description("String describing the context of the purchase")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("context")]
        public string Context { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
        [Description("Target (item type, hotspot id, etc.)")]
        public string ItemName { get; set; }

        [JsonProperty("slot_id")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Slot id if used")]
        public int SlotId { get; set; }

        [JsonProperty("offer_set_id")]
        [Description("Event Offer Set Id")]
        [MetaMember(11, (MetaMemberFlags)0)]
        public string EventOfferSetId { get; set; }

        [JsonProperty("spawned_items", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("Items Spawned")]
        public List<string> SpawnedItems { get; set; }

        [JsonProperty("impression_id", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Impression Id")]
        public string ImpressionId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventCurrencySink()
        {
        }

        public AnalyticsEventCurrencySink(CurrencySink currencySink, GameResourceCost gameResourceCost, long costSoft, long costHard, long newFreeCurrencySaldo, long newHardCurrencySaldo, AnalyticsContext context)
        {
        }

        [Description("Is Producer affected by ProducerBoosterActivated_01")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("is_producer_booster_active", NullValueHandling = (NullValueHandling)1)]
        public bool IsProducerBoosterActive { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        [Description("Shop Item Id if a shop item")]
        [JsonProperty("shop_item_id", NullValueHandling = (NullValueHandling)1)]
        public string ShopItemId { get; set; }

        [JsonProperty("flash_sale_context", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(16, (MetaMemberFlags)0)]
        [Description("Flash sale context")]
        public string FlashSaleContext { get; set; }

        public AnalyticsEventCurrencySink(CurrencySink currencySink, GameResourceCost gameResourceCost, long costSoft, long costHard, long newFreeCurrencySaldo, long newHardCurrencySaldo, AnalyticsContext context, string flashSaleContext)
        {
        }
    }
}
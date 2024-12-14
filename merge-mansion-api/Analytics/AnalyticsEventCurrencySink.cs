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

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Type of currency sink")]
        [JsonProperty("sink_type")]
        public CurrencySink CurrencySinkTag { get; set; }

        [JsonProperty("cost")]
        [Description("Cost of the purchase/sink in game resources")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public GameResourceCost GameResourceCost { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("New balance of currency received via game mechanics")]
        [JsonProperty("new_saldo")]
        public long NewFreeCurrencySaldo { get; set; }

        [JsonProperty("new_saldo_hard")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("New balance of currency received via real money purchases")]
        public long NewHardCurrencySaldo { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Cost of purchase in soft currency (coins)")]
        [JsonProperty("cost_soft")]
        public long CostSoft { get; set; }

        [JsonProperty("cost_hard")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Cost of purchase in hard currency (gems)")]
        public long CostHard { get; set; }

        [JsonProperty("context")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("String describing the context of the purchase")]
        public string Context { get; set; }

        [Description("Target (item type, hotspot id, etc.)")]
        [JsonProperty("item_name")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public string ItemName { get; set; }

        [JsonProperty("slot_id", NullValueHandling = (NullValueHandling)1)]
        [Description("Slot id if used")]
        [MetaMember(17, (MetaMemberFlags)0)]
        public int? SlotId { get; set; }

        [JsonProperty("offer_set_id")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("Event Offer Set Id")]
        public string EventOfferSetId { get; set; }

        [Description("Items Spawned")]
        [JsonProperty("spawned_items")]
        [MetaMember(12, (MetaMemberFlags)0)]
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

        [JsonProperty("is_producer_booster_active", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("Is Producer affected by ProducerBoosterActivated_01")]
        public bool IsProducerBoosterActive { get; set; }

        [JsonProperty("shop_item_id", NullValueHandling = (NullValueHandling)1)]
        [Description("Shop Item Id if a shop item")]
        [MetaMember(15, (MetaMemberFlags)0)]
        public string ShopItemId { get; set; }

        [JsonProperty("flash_sale_context", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(16, (MetaMemberFlags)0)]
        [Description("Flash sale context")]
        public string FlashSaleContext { get; set; }

        public AnalyticsEventCurrencySink(CurrencySink currencySink, GameResourceCost gameResourceCost, long costSoft, long costHard, long newFreeCurrencySaldo, long newHardCurrencySaldo, AnalyticsContext context, string flashSaleContext)
        {
        }

        [Description("Current balance of Card collection stars")]
        [MetaMember(18, (MetaMemberFlags)0)]
        [JsonProperty("saldo_card_collection_stars")]
        public long CardCollectionStars { get; set; }

        public AnalyticsEventCurrencySink(CurrencySink currencySink, GameResourceCost gameResourceCost, long costSoft, long costHard, long newFreeCurrencySaldo, long newHardCurrencySaldo, long cardCollectionStars, AnalyticsContext context, string flashSaleContext)
        {
        }
    }
}
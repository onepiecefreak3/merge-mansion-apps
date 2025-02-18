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
    [AnalyticsEvent(115, "Currency sink", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 2, 10 })]
    public class AnalyticsEventCurrencySink : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("sink_type")]
        [Description("Type of currency sink")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public CurrencySink CurrencySinkTag { get; set; }

        [JsonProperty("cost")]
        [Description("Cost of the purchase/sink in game resources")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public GameResourceCost GameResourceCost { get; set; }

        [Description("New balance of currency received via game mechanics")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("new_saldo")]
        public long NewFreeCurrencySaldo { get; set; }

        [Description("New balance of currency received via real money purchases")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("new_saldo_hard")]
        public long NewHardCurrencySaldo { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("cost_soft")]
        [Description("Cost of purchase in soft currency (coins)")]
        public long CostSoft { get; set; }

        [JsonProperty("cost_hard")]
        [Description("Cost of purchase in hard currency (gems)")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public long CostHard { get; set; }

        [JsonProperty("context")]
        [Description("String describing the context of the purchase")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public string Context { get; set; }

        [Description("Target (item type, hotspot id, etc.)")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("slot_id", NullValueHandling = (NullValueHandling)1)]
        [Description("Slot id if used")]
        public int? SlotId { get; set; }

        [Description("Event Offer Set Id")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("offer_set_id")]
        public string EventOfferSetId { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("spawned_items")]
        [Description("Items Spawned")]
        public List<string> SpawnedItems { get; set; }

        [Description("Impression Id")]
        [JsonProperty("impression_id", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(13, (MetaMemberFlags)0)]
        public string ImpressionId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventCurrencySink()
        {
        }

        public AnalyticsEventCurrencySink(CurrencySink currencySink, GameResourceCost gameResourceCost, long costSoft, long costHard, long newFreeCurrencySaldo, long newHardCurrencySaldo, AnalyticsContext context)
        {
        }

        [Description("Is Producer affected by ProducerBoosterActivated_01")]
        [JsonProperty("is_producer_booster_active", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(14, (MetaMemberFlags)0)]
        public bool IsProducerBoosterActive { get; set; }

        [JsonProperty("shop_item_id", NullValueHandling = (NullValueHandling)1)]
        [Description("Shop Item Id if a shop item")]
        [MetaMember(15, (MetaMemberFlags)0)]
        public string ShopItemId { get; set; }

        [Description("Flash sale context")]
        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("flash_sale_context", NullValueHandling = (NullValueHandling)1)]
        public string FlashSaleContext { get; set; }

        public AnalyticsEventCurrencySink(CurrencySink currencySink, GameResourceCost gameResourceCost, long costSoft, long costHard, long newFreeCurrencySaldo, long newHardCurrencySaldo, AnalyticsContext context, string flashSaleContext)
        {
        }

        [Description("Current balance of Card collection stars")]
        [JsonProperty("saldo_card_collection_stars")]
        [MetaMember(18, (MetaMemberFlags)0)]
        public long CardCollectionStars { get; set; }

        public AnalyticsEventCurrencySink(CurrencySink currencySink, GameResourceCost gameResourceCost, long costSoft, long costHard, long newFreeCurrencySaldo, long newHardCurrencySaldo, long cardCollectionStars, AnalyticsContext context, string flashSaleContext)
        {
        }

        public override IEnumerable<string> KeywordsForEventInstance { get; }
    }
}
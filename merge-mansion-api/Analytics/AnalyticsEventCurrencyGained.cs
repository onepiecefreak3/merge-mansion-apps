using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using System;
using Code.GameLogic.GameEvents;
using GameLogic.Player;
using GameLogic;
using System.Collections.Generic;

namespace Analytics
{
    [AnalyticsEvent(116, "Currency gained", 1, null, false, true, false)]
    [MetaBlockedMembers(new int[] { 3, 6, 8 })]
    public class AnalyticsEventCurrencyGained : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Type of currency source")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("earn_type")]
        public CurrencySource CurrencySource { get; set; }

        [Description("Amount of game resources gained")]
        [JsonProperty("cost")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public GameResourceCost GameResourceCost { get; set; }

        [JsonProperty("new_saldo")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("New balance of currency received via game mechanics")]
        public long NewFreeCurrencySaldo { get; set; }

        [JsonProperty("new_saldo_hard")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("New balance of currency received via real money purchases")]
        public long NewHardCurrencySaldo { get; set; }

        [Description("New balance of gems received via real money purchases")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("saldo_diamond_purchased")]
        public long HardDiamondsSaldo { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("saldo_coins_purchased")]
        [Description("New balance of coins received via real money purchases")]
        public long HardCoinsSaldo { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("New balance of progress in Lindsay event")]
        [JsonProperty("saldo_event1_progress")]
        public int LindsayEventProgress { get; set; }

        [JsonProperty("saldo_event2_progress")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("New balance of progress in Casey&Skatie event")]
        public int CaseyAndSkatieProgress { get; set; }

        [Description("New balance of progress in TinCan (Ignatious) event")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("saldo_event3_progress")]
        public int IgnatiousEventProgress { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Value received in soft currency (coins)")]
        [JsonProperty("cost_soft")]
        public long CostSoft { get; set; }

        [JsonProperty("cost_hard")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("Value received in hard currency (gems)")]
        public long CostHard { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("context")]
        [Description("String describing the context of the receiving action")]
        public string Context { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
        [Description("Target of the earn (for example item type)")]
        public string ItemName { get; set; }

        [JsonProperty(PropertyName = "event_level_id", NullValueHandling = (NullValueHandling)1)]
        [Description("Event Level Id if Event level related")]
        [MetaMember(17, (MetaMemberFlags)0)]
        public EventLevelId EventLevelId { get; set; }

        [Description("True if collected from inventory")]
        [JsonProperty(PropertyName = "from_inventory", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(18, (MetaMemberFlags)0)]
        public bool? FromInventory { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        [Description("True if collected from pocket")]
        [JsonProperty(PropertyName = "from_pocket", NullValueHandling = (NullValueHandling)1)]
        public bool? FromPocket { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventCurrencyGained()
        {
        }

        public AnalyticsEventCurrencyGained(CurrencySource currencySource, GameResourceCost gameResourceCost, long costSoft, long costHard, long newFreeCurrencySaldo, long newHardCurrencySaldo, long hardDiamondsSaldo, long hardCoinsSaldo, int lindsayEventProgress, int caseyAndSkatieEventProgress, int ignatiousEventProgress, AnalyticsContext context)
        {
        }

        [JsonProperty("mystery_pass_track", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(20, (MetaMemberFlags)0)]
        [Description("Current active track in mystery pass event")]
        public string ProgressionEventTrack { get; set; }

        public AnalyticsEventCurrencyGained(CurrencySource currencySource, GameResourceCost gameResourceCost, long costSoft, long costHard, long newFreeCurrencySaldo, long newHardCurrencySaldo, long hardDiamondsSaldo, long hardCoinsSaldo, int lindsayEventProgress, int caseyAndSkatieEventProgress, int ignatiousEventProgress, string progressionEventTrack, AnalyticsContext context)
        {
        }

        [MetaMember(21, (MetaMemberFlags)0)]
        [Description("Current balance of Card collection stars")]
        [JsonProperty("saldo_card_collection_stars")]
        public long CardCollectionStars { get; set; }

        public AnalyticsEventCurrencyGained(CurrencySource currencySource, GameResourceCost gameResourceCost, long costSoft, long costHard, long newFreeCurrencySaldo, long newHardCurrencySaldo, long hardDiamondsSaldo, long hardCoinsSaldo, int lindsayEventProgress, int caseyAndSkatieEventProgress, int ignatiousEventProgress, string progressionEventTrack, long cardCollectionStars, AnalyticsContext context)
        {
        }

        public override IEnumerable<string> KeywordsForEventInstance { get; }
    }
}
using Metaplay.Core.Analytics;
using Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using GameLogic.CardCollection;
using System;

namespace GameLogic
{
    [AnalyticsEventKeywords(new string[] { "event", "discovery" })]
    [AnalyticsEvent(205, "Card Collection Changed", 1, null, true, true, false)]
    public class AnalyticsEventCardCollectionChanged : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("collection_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Unique ID for each collection")]
        public CardCollectionCardId CollectionId { get; set; }

        [JsonProperty("card_id")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Unique ID for each card")]
        public CardCollectionCardId CardId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("The number of stars for each card")]
        [JsonProperty("card_stars")]
        public CardStars CardStars { get; set; }

        [Description("The set ID for each card")]
        [JsonProperty("set_id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public CardCollectionCardSetId SetId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("pack_id")]
        [Description("The unique ID of the pack the card is coming from")]
        public CardCollectionPackId PackId { get; set; }

        [JsonProperty("pack_source")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Where the card pack is coming from")]
        public CurrencySource PackSource { get; set; }

        [Description("Based on config")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("balance_id")]
        public CardCollectionBalanceId BalanceId { get; set; }

        [JsonProperty("hidden_rarity")]
        [Description("The rarity of the card")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public CardHiddenRarity HiddenRarity { get; set; }

        [Description("Indicates if the card is special (yes/no)")]
        [JsonProperty("is_special")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public bool IsSpecial { get; set; }

        [JsonProperty("is_wild")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Indicates if the card was generated from a wild card (yes/no)")]
        public bool IsWild { get; set; }

        [Description("Collection completion status (0-not completed, 1-completed for the first time, etc.)")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("collection_completed")]
        public int CollectionCompleted { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("set_completed")]
        [Description("Set completion status (0-not completed, 1-completed for the first time, etc.)")]
        public int SetCompleted { get; set; }

        [JsonProperty("duplicate")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Number of times the card has been received as a duplicate (0 if not duplicate)")]
        public int Duplicate { get; set; }

        [JsonProperty("prestige_level")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("0 Player has not prestiged, 1 Player has prestiged")]
        public int PrestigeLevel { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventCardCollectionChanged()
        {
        }

        public AnalyticsEventCardCollectionChanged(CardCollectionCardId collectionId, CardCollectionCardId cardId, CardStars cardStars, CardCollectionCardSetId setId, CardCollectionPackId packId, CurrencySource packSource, CardCollectionBalanceId balanceId, CardHiddenRarity hiddenRarity, bool isSpecial, bool isWild, int collectionCompleted, int setCompleted, int duplicate, int prestigeLevel)
        {
        }
    }
}
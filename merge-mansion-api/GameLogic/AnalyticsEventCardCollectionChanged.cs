using Metaplay.Core.Analytics;
using Analytics;
using System.ComponentModel;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using GameLogic.CardCollection;
using System;

namespace GameLogic
{
    [AnalyticsEvent(205, "Card Collection Changed", 1, null, true, true, false)]
    public class AnalyticsEventCardCollectionChanged : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Unique ID for each collection")]
        [JsonProperty("collection_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public CardCollectionCardId CollectionId { get; set; }

        [Description("Unique ID for each card")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("card_id")]
        public CardCollectionCardId CardId { get; set; }

        [JsonProperty("card_stars")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("The number of stars for each card")]
        public CardStars CardStars { get; set; }

        [Description("The set ID for each card")]
        [JsonProperty("set_id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public CardCollectionCardSetId SetId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("pack_id")]
        [Description("The unique ID of the pack the card is coming from")]
        public CardCollectionPackId PackId { get; set; }

        [Description("Where the card pack is coming from")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("pack_source")]
        public CurrencySource PackSource { get; set; }

        [JsonProperty("balance_id")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Based on config")]
        public CardCollectionBalanceId BalanceId { get; set; }

        [JsonProperty("hidden_rarity")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("The rarity of the card")]
        public CardHiddenRarity HiddenRarity { get; set; }

        [JsonProperty("is_special")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Indicates if the card is special (yes/no)")]
        public bool IsSpecial { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Indicates if the card was generated from a wild card (yes/no)")]
        [JsonProperty("is_wild")]
        public bool IsWild { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("collection_completed")]
        [Description("Collection completion status (0-not completed, 1-completed for the first time, etc.)")]
        public int CollectionCompleted { get; set; }

        [JsonProperty("set_completed")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [Description("Set completion status (0-not completed, 1-completed for the first time, etc.)")]
        public int SetCompleted { get; set; }

        [Description("Number of times the card has been received as a duplicate (0 if not duplicate)")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("duplicate")]
        public int Duplicate { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("prestige_level")]
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
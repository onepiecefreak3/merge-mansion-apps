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
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("collection_id")]
        public CardCollectionCardId CollectionId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Unique ID for each card")]
        [JsonProperty("card_id")]
        public CardCollectionCardId CardId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("The number of stars for each card")]
        [JsonProperty("card_stars")]
        public CardStars CardStars { get; set; }

        [Description("The set ID for each card")]
        [JsonProperty("set_id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public CardCollectionCardSetId SetId { get; set; }

        [JsonProperty("pack_id")]
        [Description("The unique ID of the pack the card is coming from")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public CardCollectionPackId PackId { get; set; }

        [JsonProperty("pack_source")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Where the card pack is coming from")]
        public CurrencySource PackSource { get; set; }

        [JsonProperty("balance_id")]
        [Description("Based on config")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public CardCollectionBalanceId BalanceId { get; set; }

        [JsonProperty("hidden_rarity")]
        [Description("The rarity of the card")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public CardHiddenRarity HiddenRarity { get; set; }

        [JsonProperty("is_special")]
        [Description("Indicates if the card is special (yes/no)")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public bool IsSpecial { get; set; }

        [Description("Indicates if the card was generated from a wild card (yes/no)")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("is_wild")]
        public bool IsWild { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("collection_completed")]
        [Description("Collection completion status (0-not completed, 1-completed for the first time, etc.)")]
        public int CollectionCompleted { get; set; }

        [Description("Set completion status (0-not completed, 1-completed for the first time, etc.)")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("set_completed")]
        public int SetCompleted { get; set; }

        [Description("Number of times the card has been received as a duplicate (0 if not duplicate)")]
        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("duplicate")]
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
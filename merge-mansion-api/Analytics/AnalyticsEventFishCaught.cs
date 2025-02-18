using Metaplay.Core.Analytics;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Model;
using Merge;
using System;
using GameLogic.Player.Items.Fishing;
using GameLogic.Player;
using Code.GameLogic.GameEvents;

namespace Analytics
{
    [AnalyticsEvent(172, "Fish caught", 1, null, false, true, false)]
    public class AnalyticsEventFishCaught : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("board_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Id of the board where the fish was caught")]
        public MergeBoardId MergeBoardId { get; set; }

        [Description("Name of the item that was caught")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("weight_category")]
        [Description("Weight category of the fish that was caught")]
        public WeightCategory WeightCategory { get; set; }

        [Description("Weight of the fish that was caught")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("personal_high_score")]
        [Description("True if this fish was a personal weight high score for the player, false otherwise")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public bool PersonalHighScore { get; set; }

        [JsonProperty("world_high_score")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("True if this fish beat the previous \"world record\" (configured limit, or personal high score if that's higher), false otherwise")]
        public bool WorldHighScore { get; set; }

        [JsonProperty("event_id")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public string Context { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventFishCaught()
        {
        }

        public AnalyticsEventFishCaught(MergeBoardId mergeBoardId, string itemName, WeightCategory weightCategory, double weight, bool personalHighScore, bool worldHighScore, AnalyticsContext context)
        {
        }

        [JsonProperty("rarity")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public string Rarity { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [JsonProperty("lucky_event_type")]
        public string LuckyEventType { get; set; }

        [JsonProperty("merge_parts_weights")]
        [MetaMember(10, (MetaMemberFlags)0)]
        public double[] MergePartsWeight { get; set; }

        public AnalyticsEventFishCaught(MergeBoardId mergeBoardId, string itemName, WeightCategory weightCategory, double weight, bool personalHighScore, bool worldHighScore, AnalyticsContext context, LuckyType luckyType, FishRarity rarity, double[] mergePartsWeight)
        {
        }
    }
}
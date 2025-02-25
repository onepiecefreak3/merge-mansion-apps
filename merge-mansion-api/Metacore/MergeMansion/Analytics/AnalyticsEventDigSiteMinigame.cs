using Metaplay.Core.Analytics;
using Analytics;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace Metacore.MergeMansion.Analytics
{
    [AnalyticsEvent(212, "Archaeological Dig Event Minigame", 1, null, false, true, false)]
    public class AnalyticsEventDigSiteMinigame : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [JsonProperty("board_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Dig site board id")]
        public string BoardId { get; set; }

        [JsonProperty("items_discovered")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Items found from the board")]
        public List<string> ItemsDiscovered { get; set; }

        [JsonProperty("progress")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Number of taps that have at least partially revealed items")]
        public int Progress { get; set; }

        [JsonProperty("requirement")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Number of tiles the board has")]
        public int Requirement { get; set; }

        [JsonProperty("completed")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("If the board is completed or not")]
        public bool Completed { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("number_of_taps")]
        [Description("Number of taps (use of pickaxes) made by the user")]
        public int NumberOfTaps { get; set; }

        [Description("Minigame name")]
        [JsonProperty("mini_game_name")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public string MinigameName { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventDigSiteMinigame()
        {
        }

        public AnalyticsEventDigSiteMinigame(string boardId, List<string> itemsDiscovered, int progress, int requirement, bool completed, int numberOfTaps)
        {
        }
    }
}
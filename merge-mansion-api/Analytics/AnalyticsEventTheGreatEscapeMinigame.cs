using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using System;
using Metaplay.Core.Math;

namespace Analytics
{
    [AnalyticsEvent(209, "The Great Escape Minigame", 1, null, false, true, false)]
    public class AnalyticsEventTheGreatEscapeMinigame : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("The progress made during the run")]
        [JsonProperty("progress")]
        public int Progress { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("requirement")]
        [Description("The required progress to complete the minigame")]
        public int Requirement { get; set; }

        [Description("If minigame is completed or not")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("completed")]
        public bool Completed { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("bars_destroyed")]
        [Description("The number of bars destroyed")]
        public int BarsDestroyed { get; set; }

        [Description("The number of taps the user made")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("number_of_taps")]
        public int NumberOfTaps { get; set; }

        [Description("The number of seconds player used during the run")]
        [JsonProperty("timer_seconds")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public F32 TimerSeconds { get; set; }

        [Description("The number of tries player had in minigame")]
        [JsonProperty("tries")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public int Tries { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventTheGreatEscapeMinigame()
        {
        }

        public AnalyticsEventTheGreatEscapeMinigame(int progress, int requirement, bool completed, int barsDestroyed, int numberOfTaps, F32 timerSeconds, int tries)
        {
        }
    }
}
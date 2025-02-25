using Metaplay.Core.Analytics;
using Analytics;
using System;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Model;
using Metaplay.Core.Math;

namespace Code.Analytics
{
    [AnalyticsEventKeywords(new string[] { "event", "task" })]
    [AnalyticsEvent(197, "Solo Milestone Token Received", 1, null, true, true, false)]
    public class AnalyticsEventSoloMilestone : AnalyticsServersideEventBase
    {
        public override string EventDescription { get; }
        public override AnalyticsEventType EventType { get; }

        [Description("Event instance number, increments per event instance")]
        [JsonProperty("event_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string EventId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("token_rarity")]
        [Description("Rarity of token received")]
        public string TokenRarity { get; set; }

        [Description("Current milestone of the event")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("current_milestone")]
        public int CurrentMilestone { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("token_spawn_source")]
        [Description("Source of token spawned")]
        public string TokenSpawnSource { get; set; }

        [Description("Source name of spawned token")]
        [JsonProperty("token_source_name")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public string TokenSourceName { get; set; }

        [JsonProperty("token_base_amount")]
        [Description("Base amount of token received")]
        [MetaMember(6, (MetaMemberFlags)0)]
        public int TokenBaseAmount { get; set; }

        [JsonProperty("token_base_amount_currency")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Currency of base am")]
        public string TokenBaseAmountCurrency { get; set; }

        [JsonProperty("token_multiplier")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [Description("Token multiplier")]
        public F32 TokenMultiplier { get; set; }

        [JsonProperty("token_amount")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Amount of token received")]
        public int TokenAmount { get; set; }

        [JsonProperty("token_saldo")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Amount of tokens after receiving new tokens")]
        public long TokenSaldo { get; set; }

        [Description("Chance of token spawned")]
        [JsonProperty("token_chance")]
        [MetaMember(11, (MetaMemberFlags)0)]
        public int TokenChance { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("token_segment_for_points")]
        [Description("Segement of milestones")]
        public string TokenSegmentForPoints { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("tokens_segment_for_rewards")]
        [Description("Segement of rewards")]
        public string TokenSegmentForRewards { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("New milestone reached")]
        [JsonProperty("new_milestone_reached")]
        public int NewMilestoneReached { get; set; }

        [JsonProperty("max_milestone")]
        [Description("Max number of milestones")]
        [MetaMember(15, (MetaMemberFlags)0)]
        public int MaxMilestones { get; set; }

        public AnalyticsEventSoloMilestone()
        {
        }

        public AnalyticsEventSoloMilestone(string eventId, string tokenRarity, int currentMilestone, string tokenSpawnSource, string tokenSourceName, int tokenBaseAmount, string tokenBaseAmountCurrency, F32 tokenMultiplier, int tokenAmount, long tokenSaldo, int tokenChance, string tokenSegmentForPoints, string tokenSegmentForRewards, int newMilestoneReached, int maxMilestones)
        {
        }
    }
}
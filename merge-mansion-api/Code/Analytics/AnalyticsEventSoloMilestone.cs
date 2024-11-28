using Metaplay.Core.Analytics;
using Analytics;
using System;
using Newtonsoft.Json;
using System.ComponentModel;
using Metaplay.Core.Model;
using Metaplay.Core.Math;

namespace Code.Analytics
{
    [AnalyticsEvent(197, "Solo Milestone Token Received", 1, null, true, true, false)]
    public class AnalyticsEventSoloMilestone : AnalyticsServersideEventBase
    {
        public override string EventDescription { get; }
        public override AnalyticsEventType EventType { get; }

        [Description("Event instance number, increments per event instance")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [JsonProperty("token_rarity")]
        [Description("Rarity of token received")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public string TokenRarity { get; set; }

        [Description("Current milestone of the event")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("current_milestone")]
        public int CurrentMilestone { get; set; }

        [Description("Source of token spawned")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("token_spawn_source")]
        public string TokenSpawnSource { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Source name of spawned token")]
        [JsonProperty("token_source_name")]
        public string TokenSourceName { get; set; }

        [JsonProperty("token_base_amount")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [Description("Base amount of token received")]
        public int TokenBaseAmount { get; set; }

        [JsonProperty("token_base_amount_currency")]
        [Description("Currency of base am")]
        [MetaMember(7, (MetaMemberFlags)0)]
        public string TokenBaseAmountCurrency { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("token_multiplier")]
        [Description("Token multiplier")]
        public F32 TokenMultiplier { get; set; }

        [JsonProperty("token_amount")]
        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Amount of token received")]
        public int TokenAmount { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("token_saldo")]
        [Description("Amount of tokens after receiving new tokens")]
        public long TokenSaldo { get; set; }

        [Description("Chance of token spawned")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [JsonProperty("token_chance")]
        public int TokenChance { get; set; }

        [Description("Segement of milestones")]
        [JsonProperty("token_segment_for_points")]
        [MetaMember(12, (MetaMemberFlags)0)]
        public string TokenSegmentForPoints { get; set; }

        [JsonProperty("tokens_segment_for_rewards")]
        [Description("Segement of rewards")]
        [MetaMember(13, (MetaMemberFlags)0)]
        public string TokenSegmentForRewards { get; set; }

        [Description("New milestone reached")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("new_milestone_reached")]
        public int NewMilestoneReached { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("max_milestone")]
        [Description("Max number of milestones")]
        public int MaxMilestones { get; set; }

        public AnalyticsEventSoloMilestone()
        {
        }

        public AnalyticsEventSoloMilestone(string eventId, string tokenRarity, int currentMilestone, string tokenSpawnSource, string tokenSourceName, int tokenBaseAmount, string tokenBaseAmountCurrency, F32 tokenMultiplier, int tokenAmount, long tokenSaldo, int tokenChance, string tokenSegmentForPoints, string tokenSegmentForRewards, int newMilestoneReached, int maxMilestones)
        {
        }
    }
}
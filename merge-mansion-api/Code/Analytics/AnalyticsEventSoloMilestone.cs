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

        [JsonProperty("event_id")]
        [Description("Event instance number, increments per event instance")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string EventId { get; set; }

        [Description("Rarity of token received")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("token_rarity")]
        public string TokenRarity { get; set; }

        [Description("Current milestone of the event")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("current_milestone")]
        public int CurrentMilestone { get; set; }

        [JsonProperty("token_spawn_source")]
        [Description("Source of token spawned")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string TokenSpawnSource { get; set; }

        [Description("Source name of spawned token")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("token_source_name")]
        public string TokenSourceName { get; set; }

        [Description("Base amount of token received")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("token_base_amount")]
        public int TokenBaseAmount { get; set; }

        [Description("Currency of base am")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("token_base_amount_currency")]
        public string TokenBaseAmountCurrency { get; set; }

        [JsonProperty("token_multiplier")]
        [Description("Token multiplier")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public F32 TokenMultiplier { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Amount of token received")]
        [JsonProperty("token_amount")]
        public int TokenAmount { get; set; }

        [JsonProperty("token_saldo")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Amount of tokens after receiving new tokens")]
        public long TokenSaldo { get; set; }

        [JsonProperty("token_chance")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("Chance of token spawned")]
        public int TokenChance { get; set; }

        [Description("Segement of milestones")]
        [MetaMember(12, (MetaMemberFlags)0)]
        [JsonProperty("token_segment_for_points")]
        public string TokenSegmentForPoints { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [JsonProperty("tokens_segment_for_rewards")]
        [Description("Segement of rewards")]
        public string TokenSegmentForRewards { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("new_milestone_reached")]
        [Description("New milestone reached")]
        public int NewMilestoneReached { get; set; }

        [Description("Max number of milestones")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("max_milestone")]
        public int MaxMilestones { get; set; }

        public AnalyticsEventSoloMilestone()
        {
        }

        public AnalyticsEventSoloMilestone(string eventId, string tokenRarity, int currentMilestone, string tokenSpawnSource, string tokenSourceName, int tokenBaseAmount, string tokenBaseAmountCurrency, F32 tokenMultiplier, int tokenAmount, long tokenSaldo, int tokenChance, string tokenSegmentForPoints, string tokenSegmentForRewards, int newMilestoneReached, int maxMilestones)
        {
        }
    }
}
using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using GameLogic.Banks;
using System;
using Metaplay.Core.Math;
using System.Collections.Generic;
using Metaplay.Core.Player;
using GameLogic;

namespace Analytics
{
    [AnalyticsEventKeywords(new string[] { "event" })]
    [AnalyticsEvent(159, "Currency Bank action", 1, null, true, true, false)]
    public class AnalyticsEventCurrencyBankAction : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Currency Bank Id from config")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("bank_id")]
        public CurrencyBankId CurrencyBankId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("bank_threshold_value")]
        [Description("Threshold value for this stash")]
        public int Threshold { get; set; }

        [Description("Max value for the stash")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("bank_max_value")]
        public int MaxValue { get; set; }

        [Description("Multiplier")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("bank_multiplier")]
        public F64 Multiplier { get; set; }

        [Description("Currency Bank Action")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("bank_action")]
        public CurrencyBankAction Action { get; set; }

        [Description("Id of the source that is causing the action")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("bank_action_trigger")]
        public string TriggerId { get; set; }

        [JsonProperty("bank_resource_type")]
        [MetaMember(7, (MetaMemberFlags)0)]
        [Description("Currency Type deposit / withdrawn from the bank")]
        public Currencies CurrencyType { get; set; }

        [Description("How much resource was used in the action / how much resource was withdrawn")]
        [MetaMember(8, (MetaMemberFlags)0)]
        [JsonProperty("bank_resource_amount")]
        public int Amount { get; set; }

        [Description("Change of points introduced by the action")]
        [JsonProperty("bank_points_amount")]
        [MetaMember(9, (MetaMemberFlags)0)]
        public int Points { get; set; }

        [Description("Current amount of points after the action has been performed")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [JsonProperty("bank_amount_status")]
        public int AmountTotal { get; set; }

        [Description("Current status of the timer")]
        [JsonProperty("bank_timer")]
        [MetaMember(11, (MetaMemberFlags)0)]
        public double StashTimer { get; set; }

        [Description("Duration hidden in hours")]
        [JsonProperty("bank_duration_hidden")]
        [MetaMember(12, (MetaMemberFlags)0)]
        public double DurationHidden { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Segments")]
        [JsonProperty("segments")]
        public List<PlayerSegmentId> Segments { get; set; }

        [JsonProperty("bank_action_trigger_type")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [Description("Bank action trigger type, for example Task")]
        public CurrencyBankTriggerType TriggerType { get; set; }

        [Description("Unique id for this players activation")]
        [JsonProperty("activation_id")]
        [MetaMember(15, (MetaMemberFlags)0)]
        public string ActivationId { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        [Description("Duration bank not full")]
        [JsonProperty("bank_duration_not_full")]
        public double DurationNotFull { get; set; }

        [Description("Max value of the timer")]
        [JsonProperty("bank_duration_full")]
        [MetaMember(17, (MetaMemberFlags)0)]
        public double DurationFull { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventCurrencyBankAction()
        {
        }

        public AnalyticsEventCurrencyBankAction(CurrencyBankId currencyBankId, int threshold, int maxValue, F64 multiplier, CurrencyBankAction action, string triggerId, Currencies currencyType, int amount, int points, int amountTotal, double stashTimer, double durationHidden, double durationNotFull, double durationFull, List<PlayerSegmentId> segments, CurrencyBankTriggerType triggerType, string activationId)
        {
        }
    }
}
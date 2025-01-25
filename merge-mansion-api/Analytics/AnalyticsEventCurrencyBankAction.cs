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
        [JsonProperty("bank_id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public CurrencyBankId CurrencyBankId { get; set; }

        [JsonProperty("bank_threshold_value")]
        [Description("Threshold value for this stash")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Threshold { get; set; }

        [Description("Max value for the stash")]
        [JsonProperty("bank_max_value")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int MaxValue { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        [Description("Multiplier")]
        [JsonProperty("bank_multiplier")]
        public F64 Multiplier { get; set; }

        [JsonProperty("bank_action")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [Description("Currency Bank Action")]
        public CurrencyBankAction Action { get; set; }

        [Description("Id of the source that is causing the action")]
        [MetaMember(6, (MetaMemberFlags)0)]
        [JsonProperty("bank_action_trigger")]
        public string TriggerId { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        [JsonProperty("bank_resource_type")]
        [Description("Currency Type deposit / withdrawn from the bank")]
        public Currencies CurrencyType { get; set; }

        [JsonProperty("bank_resource_amount")]
        [Description("How much resource was used in the action / how much resource was withdrawn")]
        [MetaMember(8, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        [Description("Change of points introduced by the action")]
        [JsonProperty("bank_points_amount")]
        public int Points { get; set; }

        [JsonProperty("bank_amount_status")]
        [MetaMember(10, (MetaMemberFlags)0)]
        [Description("Current amount of points after the action has been performed")]
        public int AmountTotal { get; set; }

        [JsonProperty("bank_timer")]
        [MetaMember(11, (MetaMemberFlags)0)]
        [Description("Current status of the timer")]
        public double StashTimer { get; set; }

        [Description("Duration hidden in hours")]
        [JsonProperty("bank_duration_hidden")]
        [MetaMember(12, (MetaMemberFlags)0)]
        public double DurationHidden { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        [Description("Segments")]
        [JsonProperty("segments")]
        public List<PlayerSegmentId> Segments { get; set; }

        [Description("Bank action trigger type, for example Task")]
        [MetaMember(14, (MetaMemberFlags)0)]
        [JsonProperty("bank_action_trigger_type")]
        public CurrencyBankTriggerType TriggerType { get; set; }

        [Description("Unique id for this players activation")]
        [MetaMember(15, (MetaMemberFlags)0)]
        [JsonProperty("activation_id")]
        public string ActivationId { get; set; }

        [Description("Duration bank not full")]
        [MetaMember(16, (MetaMemberFlags)0)]
        [JsonProperty("bank_duration_not_full")]
        public double DurationNotFull { get; set; }

        [Description("Max value of the timer")]
        [MetaMember(17, (MetaMemberFlags)0)]
        [JsonProperty("bank_duration_full")]
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
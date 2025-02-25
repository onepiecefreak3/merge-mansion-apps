using Metaplay.Core.Analytics;
using System.ComponentModel;
using Newtonsoft.Json;
using Metaplay.Core.Model;
using GameLogic.Banks;
using System;

namespace Analytics
{
    [AnalyticsEvent(162, "Currency Bank state changed", 1, null, true, true, false)]
    [AnalyticsEventKeywords(new string[] { "event" })]
    public class AnalyticsEventCurrencyBankStateChanged : AnalyticsServersideEventBase
    {
        public sealed override AnalyticsEventType EventType { get; }

        [Description("Currency Bank Id from config")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("bank_id")]
        public CurrencyBankId CurrencyBankId { get; set; }

        [Description("Threshold value for this stash")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("state")]
        public CurrencyBankState CurrencyBankState { get; set; }

        [Description("Unique id for this players activation")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("activation_id")]
        public string ActivationId { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventCurrencyBankStateChanged()
        {
        }

        public AnalyticsEventCurrencyBankStateChanged(CurrencyBankId currencyBankId, CurrencyBankState currencyBankState, string activationId)
        {
        }
    }
}
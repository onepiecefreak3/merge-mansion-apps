using Metaplay.Core.Analytics;
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using GameLogic.Banks;
using System;
using GameLogic;

namespace Analytics
{
    [AnalyticsEvent(160, "Currency Bank Impression", 1, null, false, true, false)]
    public class AnalyticsEventCurrencyBankImpression : AnalyticEventGeneralImpression
    {
        public override AnalyticsEventType EventType { get; }

        [JsonProperty("item_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Currency Bank Id")]
        public CurrencyBankId CurrencyBankId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Currency Bank amount")]
        [JsonProperty("currency_amount")]
        public long Amount { get; set; }

        [JsonProperty("currency_type")]
        [Description("Currency Bank currency type")]
        [MetaMember(3, (MetaMemberFlags)0)]
        public Currencies CurrencyType { get; set; }
        public override string EventDescription { get; }

        public AnalyticsEventCurrencyBankImpression()
        {
        }

        public AnalyticsEventCurrencyBankImpression(CurrencyBankId currencyBankId, Currencies currencyType, long amount, string platformId, string placementId, string impressionId)
        {
        }
    }
}
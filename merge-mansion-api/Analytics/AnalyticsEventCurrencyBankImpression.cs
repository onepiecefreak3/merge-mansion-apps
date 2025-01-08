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

        [Description("Currency Bank Id")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("item_name")]
        public CurrencyBankId CurrencyBankId { get; set; }

        [JsonProperty("currency_amount")]
        [Description("Currency Bank amount")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public long Amount { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("currency_type")]
        [Description("Currency Bank currency type")]
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
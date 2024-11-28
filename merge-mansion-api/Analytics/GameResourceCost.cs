using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;
using Code.GameLogic.GameEvents;
using GameLogic;

namespace Analytics
{
    [MetaSerializable]
    public class GameResourceCost
    {
        [JsonProperty("virtual_currency_name")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Type of the currency used")]
        public Currencies Currency { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Amount of the currency used")]
        [JsonProperty("value")]
        public int Amount { get; set; }

        [Description("Amount of the currency used")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("event_currency_id")]
        public EventCurrencyId EventCurrencyId { get; set; }

        public GameResourceCost()
        {
        }

        public GameResourceCost(Currencies currency, int amount, EventCurrencyId eventCurrencyId)
        {
        }
    }
}
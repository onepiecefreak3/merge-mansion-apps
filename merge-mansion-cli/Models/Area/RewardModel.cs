using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace merge_mansion_cli.Models.Area
{
    public class RewardModel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public RewardType Type { get; set; }
        public string Value { get; set; }
        public int Amount { get; set; }
    }

    public enum RewardType
    {
        Item,
        Experience,
        Coins,
        Diamonds,
        Decoration,
        EventCurrency,
        EventPoints
    }
}

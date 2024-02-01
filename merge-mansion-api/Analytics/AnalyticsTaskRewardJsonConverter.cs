using Newtonsoft.Json;
using System;

namespace Analytics
{
    public class AnalyticsTaskRewardJsonConverter : JsonConverter<AnalyticsPlayerReward>
    {
        public override bool CanRead { get; }

        public AnalyticsTaskRewardJsonConverter()
        {
        }

        public override void WriteJson(JsonWriter writer, AnalyticsPlayerReward value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override AnalyticsPlayerReward ReadJson(JsonReader reader, Type objectType, AnalyticsPlayerReward existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
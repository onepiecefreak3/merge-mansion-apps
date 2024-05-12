using Newtonsoft.Json;
using System;

namespace Analytics
{
    public class AnalyticsEventThirdPartySurveyCompletedJsonConverter : JsonConverter<AnalyticsEventThirdPartySurveyCompleted>
    {
        public override bool CanRead { get; }

        public AnalyticsEventThirdPartySurveyCompletedJsonConverter()
        {
        }

        public override void WriteJson(JsonWriter writer, AnalyticsEventThirdPartySurveyCompleted value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override AnalyticsEventThirdPartySurveyCompleted ReadJson(JsonReader reader, Type objectType,
            AnalyticsEventThirdPartySurveyCompleted existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
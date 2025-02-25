using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [MetaSerializable]
    public class AnalyticsBoardStateDecorationMetaData
    {
        [JsonProperty("item_type")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string DecorationId { get; set; }

        [JsonProperty("is_active")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public bool IsActive { get; set; }

        [JsonProperty("level", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(3, (MetaMemberFlags)0)]
        public int? Level { get; set; }

        public AnalyticsBoardStateDecorationMetaData()
        {
        }

        public AnalyticsBoardStateDecorationMetaData(string decorationId, bool isActive, int? level)
        {
        }
    }
}
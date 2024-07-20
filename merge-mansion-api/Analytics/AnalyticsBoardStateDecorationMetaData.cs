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

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("level", NullValueHandling = (NullValueHandling)1)]
        public int? Level { get; set; }

        public AnalyticsBoardStateDecorationMetaData()
        {
        }

        public AnalyticsBoardStateDecorationMetaData(string decorationId, bool isActive, int? level)
        {
        }
    }
}
using Metaplay.Core.Model;
using Newtonsoft.Json;
using System;
using Metaplay.Core;
using GameLogic.Player.Items;

namespace Analytics
{
    [MetaSerializable]
    public class AnalyticsBoardStateMetaData
    {
        [JsonProperty("item_type")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public string ItemType { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("charges", NullValueHandling = (NullValueHandling)1)]
        public int? Charges { get; set; }

        [JsonProperty("duration_left", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaDuration? TimeContainerRemaining { get; set; }

        [JsonProperty("is_active", NullValueHandling = (NullValueHandling)1)]
        [MetaMember(4, (MetaMemberFlags)0)]
        public bool? IsActive { get; set; }

        public AnalyticsBoardStateMetaData()
        {
        }

        public AnalyticsBoardStateMetaData(MergeItem item)
        {
        }
    }
}
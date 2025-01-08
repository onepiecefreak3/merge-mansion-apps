using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Analytics
{
    [MetaSerializable]
    public class ItemSinkProgressStatus
    {
        [Description("How many items have been fed to the sink")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("current")]
        public int Current { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("How many items the sink expects")]
        [JsonProperty("target")]
        public int Target { get; set; }

        public ItemSinkProgressStatus()
        {
        }

        public ItemSinkProgressStatus(int current, int target)
        {
        }
    }
}
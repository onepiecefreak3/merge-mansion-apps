using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Analytics
{
    [MetaSerializable]
    public class ItemSinkProgressStatus
    {
        [JsonProperty("current")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("How many items have been fed to the sink")]
        public int Current { get; set; }

        [Description("How many items the sink expects")]
        [MetaMember(2, (MetaMemberFlags)0)]
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
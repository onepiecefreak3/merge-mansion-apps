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
        [JsonProperty("current")]
        [MetaMember(1, (MetaMemberFlags)0)]
        public int Current { get; set; }

        [Description("How many items the sink expects")]
        [JsonProperty("target")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Target { get; set; }

        public ItemSinkProgressStatus()
        {
        }

        public ItemSinkProgressStatus(int current, int target)
        {
        }
    }
}
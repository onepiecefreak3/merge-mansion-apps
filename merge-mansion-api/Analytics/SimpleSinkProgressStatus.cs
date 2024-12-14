using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Analytics
{
    [MetaSerializable]
    public class SimpleSinkProgressStatus
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [JsonProperty("current")]
        [Description("Current sink progress")]
        public int Current { get; set; }

        [Description("Target sink progress")]
        [JsonProperty("target")]
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Target { get; set; }

        public SimpleSinkProgressStatus()
        {
        }

        public SimpleSinkProgressStatus(int current, int target)
        {
        }
    }
}
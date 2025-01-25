using Metaplay.Core.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System;

namespace Analytics
{
    [MetaSerializable]
    public class SimpleSinkProgressStatus
    {
        [JsonProperty("current")]
        [MetaMember(1, (MetaMemberFlags)0)]
        [Description("Current sink progress")]
        public int Current { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("target")]
        [Description("Target sink progress")]
        public int Target { get; set; }

        public SimpleSinkProgressStatus()
        {
        }

        public SimpleSinkProgressStatus(int current, int target)
        {
        }
    }
}
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
        [Description("Current sink progress")]
        [JsonProperty("current")]
        public int Current { get; set; }

        [JsonProperty("target")]
        [MetaMember(2, (MetaMemberFlags)0)]
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
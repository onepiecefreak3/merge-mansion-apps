using Metaplay.Core.Model;
using System.ComponentModel;
using Newtonsoft.Json;
using System;

namespace Analytics
{
    [MetaBlockedMembers(new int[] { 1 })]
    [MetaSerializable]
    public class LeaderboardSnapshotPlayerEntry
    {
        [JsonProperty("rank")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [Description("Rank")]
        public int Rank { get; set; }

        [Description("Points")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [JsonProperty("points")]
        public int Points { get; set; }

        [Description("Association Id")]
        [JsonProperty("association_id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        public string AssociationId { get; set; }

        private LeaderboardSnapshotPlayerEntry()
        {
        }

        public LeaderboardSnapshotPlayerEntry(string associationId, int rank, int points)
        {
        }
    }
}
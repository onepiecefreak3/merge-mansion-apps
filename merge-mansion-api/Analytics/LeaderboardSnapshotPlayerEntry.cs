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
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("rank")]
        [Description("Rank")]
        public int Rank { get; set; }

        [JsonProperty("points")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Points")]
        public int Points { get; set; }

        [Description("Association Id")]
        [MetaMember(4, (MetaMemberFlags)0)]
        [JsonProperty("association_id")]
        public string AssociationId { get; set; }

        private LeaderboardSnapshotPlayerEntry()
        {
        }

        public LeaderboardSnapshotPlayerEntry(string associationId, int rank, int points)
        {
        }

        [JsonProperty("bot_type")]
        [Description("Bot Type")]
        [MetaMember(5, (MetaMemberFlags)0)]
        public string BotType { get; set; }

        public LeaderboardSnapshotPlayerEntry(string associationId, int rank, int points, string botType)
        {
        }
    }
}
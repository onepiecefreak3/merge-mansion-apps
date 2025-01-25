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
        [Description("Rank")]
        [MetaMember(2, (MetaMemberFlags)0)]
        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("points")]
        [MetaMember(3, (MetaMemberFlags)0)]
        [Description("Points")]
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

        [Description("Bot Type")]
        [MetaMember(5, (MetaMemberFlags)0)]
        [JsonProperty("bot_type")]
        public string BotType { get; set; }

        public LeaderboardSnapshotPlayerEntry(string associationId, int rank, int points, string botType)
        {
        }
    }
}
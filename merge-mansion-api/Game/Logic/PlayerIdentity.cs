using Metaplay.Core.Model;
using System;
using Metaplay.Core;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Game.Logic
{
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 1 })]
    public class PlayerIdentity
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        private string associationIdentifier { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private bool hasDisabledAnalytics { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private TOSAcceptance tosAcceptance { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        private MetaTime tosAcceptanceTime { get; set; }

        [ServerOnly]
        [MetaMember(6, (MetaMemberFlags)0)]
        private HashSet<PlayerNameHistoryEntry> PlayerNameHistoryEntries { get; set; }

        [JsonProperty(NullValueHandling = (NullValueHandling)1)]
        [MetaMember(7, (MetaMemberFlags)0)]
        public int? BotInstance { get; set; }

        public PlayerIdentity()
        {
        }
    }
}
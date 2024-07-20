using Metaplay.Core.Model;
using System;
using Metaplay.Core;
using System.Collections.Generic;
using GameLogic;
using Newtonsoft.Json;

namespace Game.Logic
{
    [MetaBlockedMembers(new int[] { 1 })]
    [MetaSerializable]
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

        public PlayerIdentity(RandomPCG random)
        {
        }

        [MetaMember(8, (MetaMemberFlags)0)]
        public bool PlayerNameChangeDisabled { get; set; }
    }
}
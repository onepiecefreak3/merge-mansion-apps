using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace Metaplay.Core.Player
{
    [MetaBlockedMembers(new int[] { 1 })]
    [MetaSerializable]
    public class PlayerDeviceEntry
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public string DeviceModel { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaTime FirstSeenAt { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaTime LastLoginAt { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public bool IncompleteHistory { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int NumLogins { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public ClientPlatform ClientPlatform { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public HashSet<AuthenticationKey> LoginMethods { get; set; }

        private PlayerDeviceEntry()
        {
        }

        [MetaMember(9, (MetaMemberFlags)0)]
        public string LastSeenOperatingSystem { get; set; }
    }
}
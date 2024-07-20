using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.Math;
using Merge;

namespace GameLogic.Player
{
    [MetaBlockedMembers(new int[] { 2, 3, 4, 5, 6, 7, 8, 11, 12, 13, 14 })]
    [MetaSerializable]
    public class Statistics
    {
        [MetaMember(16, (MetaMemberFlags)0)]
        private Dictionary<string, string> testGroupDictionary;
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime FirstGameStartTimestamp { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        private long LastEnergyRefillBuyDay { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        private int CurrentEnergyRefillCounter { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        private long Level1ExperienceCollected { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        private F64 PlayerLtvInEur { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        private Dictionary<MergeBoardId, int> mergeCounts { get; set; }

        public Statistics()
        {
        }

        public Statistics(MetaTime currentTime)
        {
        }

        [MetaMember(19, (MetaMemberFlags)0)]
        public MetaDuration TotalPlaytimeApprox { get; set; }
    // STUB
    }
}
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

        [MetaMember(20, (MetaMemberFlags)0)]
        public Dictionary<int, int> ItemMergeCount { get; set; }

        [MetaMember(21, (MetaMemberFlags)0)]
        public Dictionary<Currencies, long> ResourceSpentCount { get; set; }

        [MetaMember(22, (MetaMemberFlags)0)]
        public Dictionary<Currencies, long> ResourceGainedCount { get; set; }

        [MetaMember(23, (MetaMemberFlags)0)]
        public int BubblesBurstCount { get; set; }

        [MetaMember(24, (MetaMemberFlags)0)]
        public Dictionary<int, int> ProducerUseCount { get; set; }

        [MetaMember(25, (MetaMemberFlags)0)]
        public Dictionary<int, int> ItemsClaimedFromShopCount { get; set; }

        [MetaMember(26, (MetaMemberFlags)0)]
        public Dictionary<int, int> ChestsOpenedCount { get; set; }

        [MetaMember(27, (MetaMemberFlags)0)]
        public Dictionary<int, int> TaskCompletedCount { get; set; }
    // STUB
    }
}
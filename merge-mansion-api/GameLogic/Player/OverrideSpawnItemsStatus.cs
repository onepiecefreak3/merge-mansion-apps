using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using Metaplay.Core;

namespace GameLogic.Player
{
    [MetaSerializable]
    public class OverrideSpawnItemsStatus
    {
        private static int SpawnHistoryLength;
        [MetaMember(1, (MetaMemberFlags)0)]
        private Dictionary<int, OverrideSpawnItemsStatus.SpawnHistory> RecordedSpawns { get; set; }

        public OverrideSpawnItemsStatus()
        {
        }

        [MetaSerializable]
        public class SpawnHistory
        {
            [MetaMember(1, (MetaMemberFlags)0)]
            public long AllTimeTotal { get; set; }

            [MetaMember(2, (MetaMemberFlags)0)]
            public List<MetaTime> RecentRecords { get; set; }

            public SpawnHistory()
            {
            }
        }
    }
}
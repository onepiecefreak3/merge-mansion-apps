using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.GameEvents.SoloMilestone;
using System;
using Metaplay.Core.Player;
using Code.GameLogic.StatsTracking;
using Metaplay.Core.Math;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class SoloMilestoneTokenSpawnsInfo : IGameConfigData<SoloMilestoneTokenSpawnsId>, IGameConfigData, IHasGameConfigKey<SoloMilestoneTokenSpawnsId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public SoloMilestoneTokenSpawnsId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public SoloMilestoneEventId EventId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Milestone { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public PlayerSegmentId Segment { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public StatsTrackingType TokenSource { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int BaseTokenSpawnChance { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public bool BaseTokenSpawnEnabled { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public F32 BaseTokenSpawnMultiplierMin { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public F32 BaseTokenSpawnMultiplierMax { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public List<int> Parameters { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public int SegmentPriority { get; set; }

        public SoloMilestoneTokenSpawnsInfo()
        {
        }

        public SoloMilestoneTokenSpawnsInfo(SoloMilestoneTokenSpawnsId configKey, SoloMilestoneEventId eventId, int milestone, PlayerSegmentId segment, int segmentPriority, StatsTrackingType tokenSource, int baseTokenSpawnChance, bool baseTokenSpawnEnabled, F32 baseTokenSpawnMultiplierMin, F32 baseTokenSpawnMultiplierMax, List<int> parameters)
        {
        }
    }
}
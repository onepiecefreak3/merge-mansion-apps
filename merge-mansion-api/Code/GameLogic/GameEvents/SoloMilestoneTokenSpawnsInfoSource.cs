using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using Code.GameLogic.StatsTracking;

namespace Code.GameLogic.GameEvents
{
    public class SoloMilestoneTokenSpawnsInfoSource : IConfigItemSource<SoloMilestoneTokenSpawnsInfo, SoloMilestoneTokenSpawnsId>, IGameConfigSourceItem<SoloMilestoneTokenSpawnsId, SoloMilestoneTokenSpawnsInfo>, IHasGameConfigKey<SoloMilestoneTokenSpawnsId>
    {
        private static char DashMarker;
        public SoloMilestoneTokenSpawnsId ConfigKey { get; set; }
        public string BaseTokenSpawnMultiplier { get; set; }
        public int BaseTokenSpawnChance { get; set; }
        public bool BaseTokenSpawnEnabled { get; set; }
        public string EventId { get; set; }
        public int Milestone { get; set; }
        public string Segment { get; set; }
        public int SegmentPriority { get; set; }
        public StatsTrackingType TokenSource { get; set; }
        public string Parameters { get; set; }

        public SoloMilestoneTokenSpawnsInfoSource()
        {
        }
    }
}
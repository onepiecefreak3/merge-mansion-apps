using Metaplay.Core.Model;
using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Analytics;

namespace GameLogic.StatsTracking
{
    [MetaSerializable]
    public abstract class StatsObjective
    {
        [IgnoreDataMember]
        public int lastProgress;
        public abstract StatsObjectiveType ObjectiveType { get; }
        public abstract long SnapshotAmount { get; set; }
        public abstract string ObjectiveId { get; set; }
        public abstract ObjectiveState State { get; set; }
        public abstract int ProgressIndex { get; set; }
        public abstract List<int> ObjectiveRequirements { get; set; }
        public virtual string ObjectiveTypeString { get; }

        protected StatsObjective()
        {
        }

        public abstract TaskType TypeTask { get; set; }
        public bool HasFullProgress { get; set; }
    }
}
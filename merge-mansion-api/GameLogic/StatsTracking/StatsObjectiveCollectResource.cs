using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using Metaplay.Core;

namespace GameLogic.StatsTracking
{
    [MetaSerializableDerived(5)]
    public class StatsObjectiveCollectResource : StatsObjective
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        public Currencies TargetResource { get; set; }

        [MetaMember(101, (MetaMemberFlags)0)]
        public sealed override long SnapshotAmount { get; set; }

        [MetaMember(102, (MetaMemberFlags)0)]
        public sealed override string ObjectiveId { get; set; }

        [MetaMember(103, (MetaMemberFlags)0)]
        public sealed override ObjectiveState State { get; set; }

        [MetaMember(104, (MetaMemberFlags)0)]
        public sealed override int ProgressIndex { get; set; }

        [MetaMember(105, (MetaMemberFlags)0)]
        public sealed override List<int> ObjectiveRequirements { get; set; }
        public override StatsObjectiveType ObjectiveType { get; }
        public override string ObjectiveTypeString { get; }

        public StatsObjectiveCollectResource()
        {
        }

        public StatsObjectiveCollectResource(string targetItemId, IStringId objectiveId, long snapshotAmount, List<int> objectiveRequirements)
        {
        }

        public StatsObjectiveCollectResource(Currencies targetResource, IStringId objectiveId, long snapshotAmount, List<int> objectiveRequirements)
        {
        }
    }
}
using Code.GameLogic.Config;
using Merge;
using Metaplay.Core.Config;
using Events;
using Metaplay.Core;
using System;
using System.Collections.Generic;
using Code.GameLogic.GameEvents;

namespace TimedMergeBoards
{
    public class TimedMergeBoardSource : IConfigItemSource<TimedMergeBoard, MergeBoardId>, IGameConfigSourceItem<MergeBoardId, TimedMergeBoard>, IHasGameConfigKey<MergeBoardId>
    {
        private MergeBoardId EventId { get; set; }
        private MergeBoardGeneratorId GeneratorId { get; set; }
        private MetaDuration Duration { get; set; }
        private string FinalItemId { get; set; }
        private List<string> RequirementType { get; set; }
        private List<string> RequirementId { get; set; }
        private List<string> RequirementAmount { get; set; }
        private List<string> RequirementAux0 { get; set; }
        private List<string> CompleteRequirementType { get; set; }
        private List<string> CompleteRequirementId { get; set; }
        private List<string> CompleteRequirementAmount { get; set; }
        private List<string> CompleteRequirementAux0 { get; set; }
        public List<MetaRef<EventLevelInfo>> LevelInfos { get; set; }
        public MergeBoardId ConfigKey { get; }

        public TimedMergeBoardSource()
        {
        }
    }
}
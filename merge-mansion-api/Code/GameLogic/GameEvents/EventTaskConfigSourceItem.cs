using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.Math;

namespace Code.GameLogic.GameEvents
{
    public class EventTaskConfigSourceItem : IConfigItemSource<EventTaskInfo, EventTaskId>, IGameConfigSourceItem<EventTaskId, EventTaskInfo>, IHasGameConfigKey<EventTaskId>
    {
        private EventTaskId EventTaskId { get; set; }
        private string DisplayName { get; set; }
        private string Description { get; set; }
        private string TaskTitleLocId { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        private List<string> RequirementType { get; set; }
        private List<string> RequirementId { get; set; }
        private List<string> RequirementAmount { get; set; }
        private List<string> RequirementAux0 { get; set; }
        private List<MetaRef<EventTaskInfo>> UnlocksTasks { get; set; }
        private List<string> CompleteAction { get; set; }
        private int? EventLevelMin { get; set; }
        private int? EventLevelMax { get; set; }
        private bool ForceHideOnEventLevelMax { get; set; }
        private bool IsDynamicTask { get; set; }
        private string DifficultyCurve_Item1 { get; set; }
        private string DefaultDifficultyCurve_Item1 { get; set; }
        private F32 RangeMin_Item1 { get; set; }
        private F32 RangeMax_Item1 { get; set; }
        private F32 LeftoversWeightMultiplier_Item1 { get; set; }
        private string DifficultyCurve_Item2 { get; set; }
        private string DefaultDifficultyCurve_Item2 { get; set; }
        private F32 RangeMin_Item2 { get; set; }
        private F32 RangeMax_Item2 { get; set; }
        private F32 LeftoversWeightMultiplier_Item2 { get; set; }
        public EventTaskId ConfigKey { get; }

        public EventTaskConfigSourceItem()
        {
        }
    }
}
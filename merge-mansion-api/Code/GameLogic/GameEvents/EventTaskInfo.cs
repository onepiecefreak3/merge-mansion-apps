using System.Collections.Generic;
using GameLogic.Player.Requirements;
using GameLogic.Player.Rewards;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Model;
using Code.GameLogic.Config;
using System.Runtime.Serialization;
using System;
using GameLogic.Player.Items;
using Metaplay.Core.Math;
using GameLogic.Player.Director.Config;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventTaskInfo : IGameConfigData<EventTaskId>, IGameConfigData, IHasGameConfigKey<EventTaskId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EventTaskId EventTaskId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DisplayName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string Description { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<PlayerItemRequirement> Requirements { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<MetaRef<EventTaskInfo>> UnlockTaskRefs { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public string TaskTitleLocId { get; set; }
        public EventTaskId ConfigKey => EventTaskId;

        [IgnoreDataMember]
        public IEnumerable<EventTaskInfo> UnlockTasks { get; }

        public EventTaskInfo()
        {
        }

        public EventTaskInfo(EventTaskId eventTaskId, string displayName, string description, List<PlayerReward> rewards, List<PlayerItemRequirement> requirements, List<MetaRef<EventTaskInfo>> unlocksTasks, string taskTitleLocId)
        {
        }

        [MetaMember(8, (MetaMemberFlags)0)]
        public bool IsDynamicTask { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public string DifficultyCurve_Item1 { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public string DefaultDifficultyCurve_Item1 { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public F32 RangeMin_Item1 { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public F32 RangeMax_Item1 { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public F32 LeftoversWeightMultiplier_Item1 { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public string DifficultyCurve_Item2 { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        public string DefaultDifficultyCurve_Item2 { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        public F32 RangeMin_Item2 { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        public F32 RangeMax_Item2 { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        public F32 LeftoversWeightMultiplier_Item2 { get; set; }

        public EventTaskInfo(EventTaskId eventTaskId, string displayName, string description, List<PlayerReward> rewards, List<PlayerItemRequirement> requirements, List<MetaRef<EventTaskInfo>> unlocksTasks, string taskTitleLocId, bool isDynamicTask, string difficultyCurveItem1, string defaultDifficultyCurveItem1, F32 rangeMinItem1, F32 rangeMaxItem1, F32 leftoversWeightMultiplier_Item1, string difficultyCurveItem2, string defaultDifficultyCurveItem2, F32 rangeMinItem2, F32 rangeMaxItem2, F32 leftoversWeightMultiplier_Item2)
        {
        }

        [MetaMember(19, (MetaMemberFlags)0)]
        public List<IDirectorAction> CompleteActions { get; set; }

        [MetaMember(20, (MetaMemberFlags)0)]
        private int? EventLevelMin { get; set; }

        [MetaMember(21, (MetaMemberFlags)0)]
        private int? EventLevelMax { get; set; }

        [MetaMember(22, (MetaMemberFlags)0)]
        private bool ForceHideOnEventLevelMax { get; set; }

        public EventTaskInfo(EventTaskId eventTaskId, string displayName, string description, List<PlayerReward> rewards, List<PlayerItemRequirement> requirements, List<MetaRef<EventTaskInfo>> unlocksTasks, string taskTitleLocId, bool isDynamicTask, string difficultyCurveItem1, string defaultDifficultyCurveItem1, F32 rangeMinItem1, F32 rangeMaxItem1, F32 leftoversWeightMultiplier_Item1, string difficultyCurveItem2, string defaultDifficultyCurveItem2, F32 rangeMinItem2, F32 rangeMaxItem2, F32 leftoversWeightMultiplier_Item2, List<IDirectorAction> completeActions, int? eventLevelMin, int? eventLevelMax, bool forceHideOnEventLevelMax)
        {
        }
    }
}
using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using Merge;
using System.Collections.Generic;
using Code.GameLogic.Hotspots;
using Metaplay.Core;
using GameLogic.Config.Map.Characters;
using GameLogic.Area;

namespace GameLogic.Hotspots
{
    public class HotspotDefinitionSource : IConfigItemSource<HotspotDefinition, HotspotId>, IGameConfigSourceItem<HotspotId, HotspotDefinition>, IHasGameConfigKey<HotspotId>
    {
        private HotspotId HotspotId { get; set; }
        public HotspotType Type { get; set; }
        private string TitleId { get; set; }
        private MergeBoardId MergeBoardId { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        private List<string> RequirementType { get; set; }
        private List<string> RequirementId { get; set; }
        private List<string> RequirementAmount { get; set; }
        private List<string> RequirementAux0 { get; set; }
        private List<string> CompleteAction { get; set; }
        private int CompleteActionMax { get; set; }
        private HotspotId? CompleteFocusHotspotId { get; set; }
        private List<MetaRef<MapCharacterEventDefinition>> CompleteMapCharacterEvents { get; set; }
        private string CompleteVFXId { get; set; }
        private List<string> FinalizeAction { get; set; }
        private List<string> AppearAction { get; set; }
        private int AppearActionMax { get; set; }
        private List<MetaRef<MapCharacterEventDefinition>> AppearMapCharacterEvents { get; set; }
        public List<HotspotId> UnlockingParents { get; set; }
        public MapSpotId MapSpotId { get; set; }
        public TaskGroupId TaskGroupId { get; set; }
        public bool IsIndependentTask { get; set; }
        private List<string> UnlockingRequirementType { get; set; }
        private List<string> UnlockingRequirementId { get; set; }
        private List<string> UnlockingRequirementAmount { get; set; }
        private List<string> UnlockingRequirementAux0 { get; set; }
        private List<string> BonusRewardType { get; set; }
        private List<string> BonusRewardId { get; set; }
        private List<string> BonusRewardAux0 { get; set; }
        private List<string> BonusRewardAux1 { get; set; }
        private List<int> BonusRewardAmount { get; set; }
        private MetaDuration BonusTimerDuration { get; set; }
        private string DescriptionLocalizationId { get; set; }
        public LocationTravelId LocationTravelId { get; set; }
        public AreaId AreaInfoOverride { get; set; }
        public HotspotId ConfigKey { get; }

        [Obsolete("Replaced by UnlockingParents")]
        public List<HotspotId> OpenedHotspotId { get; set; }
        public HotspotId SourceConfigKey { get; }

        public HotspotDefinitionSource()
        {
        }

        public CustomHotspotTableId CustomHotspotTableId { get; set; }
        public int SoloMilestoneHotspotValue { get; set; }
        public MultistepGroupId MultistepGroupId { get; set; }
        public int BoultonLeaguePoints { get; set; }
        public bool DelayDebrisAnimation { get; set; }
        public int Difficulty { get; set; }
        private List<string> DifficultyRewardType { get; set; }
        private List<string> DifficultyRewardId { get; set; }
        private List<string> DifficultyRewardAux0 { get; set; }
        private List<string> DifficultyRewardAux1 { get; set; }
        private List<int> DifficultyRewardAmount { get; set; }
    }
}
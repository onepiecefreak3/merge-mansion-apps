using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace GameLogic.GameFeatures
{
    public class ReEngagementSettingsSource : IConfigItemSource<ReEngagementSettings, ReEngagementSettingsId>, IGameConfigSourceItem<ReEngagementSettingsId, ReEngagementSettings>, IHasGameConfigKey<ReEngagementSettingsId>
    {
        public ReEngagementSettingsId ConfigKey { get; set; }
        private bool Enabled { get; set; }
        private string ItemTypesToSell { get; set; }
        private string[] RewardType { get; set; }
        private string[] RewardId { get; set; }
        private int[] RewardAmount { get; set; }
        private string[] RewardAux0 { get; set; }
        private string[] RewardAux1 { get; set; }
        private string[] RequirementType { get; set; }
        private string[] RequirementId { get; set; }
        private string[] RequirementAmount { get; set; }
        private string[] RequirementAux0 { get; set; }

        public ReEngagementSettingsSource()
        {
        }
    }
}
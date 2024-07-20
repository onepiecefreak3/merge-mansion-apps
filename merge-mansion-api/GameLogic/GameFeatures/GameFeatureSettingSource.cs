using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using Metaplay.Core.Player;

namespace GameLogic.GameFeatures
{
    public class GameFeatureSettingSource : IConfigItemSource<GameFeatureSetting, GameFeatureId>, IGameConfigSourceItem<GameFeatureId, GameFeatureSetting>, IHasGameConfigKey<GameFeatureId>
    {
        private GameFeatureId GameFeatureId { get; set; }
        private bool IsEnabled { get; set; }
        private bool ShouldBePersisted { get; set; }
        private List<string> PreviewRequirementType { get; set; }
        private List<string> PreviewRequirementId { get; set; }
        private List<string> PreviewRequirementAmount { get; set; }
        private List<string> PreviewRequirementAux0 { get; set; }
        private List<string> UnlockRequirementType { get; set; }
        private List<string> UnlockRequirementId { get; set; }
        private List<string> UnlockRequirementAmount { get; set; }
        private List<string> UnlockRequirementAux0 { get; set; }
        private string PersistedAction { get; set; }
        private List<MetaRef<PlayerSegmentInfoBase>> Segments { get; set; }
        public GameFeatureId ConfigKey { get; }

        public GameFeatureSettingSource()
        {
        }
    }
}
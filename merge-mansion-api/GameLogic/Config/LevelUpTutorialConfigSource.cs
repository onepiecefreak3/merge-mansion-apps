using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Config
{
    public class LevelUpTutorialConfigSource : IConfigItemSource<LevelUpTutorialConfig, LevelUpTutorialConfigId>, IGameConfigSourceItem<LevelUpTutorialConfigId, LevelUpTutorialConfig>, IHasGameConfigKey<LevelUpTutorialConfigId>
    {
        private LevelUpTutorialConfigId ConfigId { get; set; }
        private bool Enabled { get; set; }
        private int RequiredPendingLevelUps { get; set; }
        private int[] ForcedPromptLevels { get; set; }
        public LevelUpTutorialConfigId ConfigKey { get; }

        public LevelUpTutorialConfigSource()
        {
        }
    }
}
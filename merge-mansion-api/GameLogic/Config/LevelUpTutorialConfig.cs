using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class LevelUpTutorialConfig : IGameConfigData<LevelUpTutorialConfigId>, IGameConfigData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private LevelUpTutorialConfigId ConfigId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private bool Enabled { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private int RequiredPendingLevelUps { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private int[] ForcedPromptLevels { get; set; }
        public LevelUpTutorialConfigId ConfigKey => ConfigId;

        public LevelUpTutorialConfig()
        {
        }

        public LevelUpTutorialConfig(LevelUpTutorialConfigId id, bool enabled, int requiredPendingLevelUps, int[] forcedPromptLevels)
        {
        }
    }
}
using Code.GameLogic.Config;
using System;
using Metaplay.Core.Config;
using System.Collections.Generic;

namespace Player
{
    public class PlayerLevelDataSource : IConfigItemSource<PlayerLevelData, int>, IGameConfigSourceItem<int, PlayerLevelData>, IHasGameConfigKey<int>
    {
        private int LevelKey { get; set; }
        private int NextLevelExperience { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        public int ConfigKey { get; }

        public PlayerLevelDataSource()
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace Player
{
    [MetaSerializable]
    public class PlayerLevelData : IGameConfigData<int>, IGameConfigData, IGameConfigKey<int>
    {
        public int ConfigKey => Level;

        [MetaMember(1, (MetaMemberFlags)0)]
        public int Level { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int NextLevelExperience { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        public PlayerLevelData()
        {
        }

        public PlayerLevelData(int level, int nextLevelExperience, IEnumerable<PlayerReward> rewards)
        {
        }
    }
}
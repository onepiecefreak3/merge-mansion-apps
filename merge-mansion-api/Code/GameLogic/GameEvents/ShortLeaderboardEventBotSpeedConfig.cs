using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class ShortLeaderboardEventBotSpeedConfig : IGameConfigData<int>, IGameConfigData, IHasGameConfigKey<int>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string BotName { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int Stage { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int Time { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int MinPoints { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int MaxPoints { get; set; }

        public ShortLeaderboardEventBotSpeedConfig()
        {
        }

        public ShortLeaderboardEventBotSpeedConfig(int configKey, string botName, int stage, int time, int minPoints, int maxPoints)
        {
        }
    }
}
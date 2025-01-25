using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using Metaplay.Core.Player;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class ShortLeaderboardEventBotSelection : IGameConfigData<int>, IGameConfigData, IHasGameConfigKey<int>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<string> BotsPool { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int BotsMin { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int BotsMax { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int MinSpend { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public PlayerSegmentId SegmentId { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public int SegmentIdPriority { get; set; }

        public ShortLeaderboardEventBotSelection()
        {
        }

        public ShortLeaderboardEventBotSelection(int configKey, List<string> botsPool, int botsMin, int botsMax, int minSpend, PlayerSegmentId segmentId, int segmentIdPriority)
        {
        }
    }
}
using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using GameLogic.Player.Requirements;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class LeaderboardEventMatchmakingBucketsInfo : IGameConfigData<LeaderboardEventMatchmakingBucketsId>, IGameConfigData, IHasGameConfigKey<LeaderboardEventMatchmakingBucketsId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public LeaderboardEventMatchmakingBucketsId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<PlayerRequirement> Requirements { get; set; }

        public LeaderboardEventMatchmakingBucketsInfo()
        {
        }

        public LeaderboardEventMatchmakingBucketsInfo(LeaderboardEventMatchmakingBucketsId configKey, List<PlayerRequirement> requirements)
        {
        }
    }
}
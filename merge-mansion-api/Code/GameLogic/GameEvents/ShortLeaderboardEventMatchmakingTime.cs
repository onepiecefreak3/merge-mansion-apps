using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class ShortLeaderboardEventMatchmakingTime : IGameConfigData<ShortLeaderboardEventMatchmakingTimeId>, IGameConfigData, IHasGameConfigKey<ShortLeaderboardEventMatchmakingTimeId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ShortLeaderboardEventMatchmakingTimeId TimeMax { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaDuration Value { get; set; }
        public ShortLeaderboardEventMatchmakingTimeId ConfigKey { get; }

        public ShortLeaderboardEventMatchmakingTime()
        {
        }

        public ShortLeaderboardEventMatchmakingTime(ShortLeaderboardEventMatchmakingTimeId configKey, MetaDuration value)
        {
        }
    }
}
using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineLeaderboardConfigSource : IConfigItemSource<MysteryMachineLeaderboardConfigInfo, MysteryMachineLeaderboardConfigId>, IGameConfigSourceItem<MysteryMachineLeaderboardConfigId, MysteryMachineLeaderboardConfigInfo>, IHasGameConfigKey<MysteryMachineLeaderboardConfigId>
    {
        public MysteryMachineLeaderboardConfigId ConfigKey { get; set; }
        public List<MetaRef<MysteryMachineLeaderboardTopRankingRewardInfo>> TopRankingRewards { get; set; }
        public List<MetaRef<MysteryMachineLeaderboardPercentileRankingRewardInfo>> PercentileRankingRewards { get; set; }
        public MetaDuration BecomeAvailableDelay { get; set; }

        public MysteryMachineLeaderboardConfigSource()
        {
        }
    }
}
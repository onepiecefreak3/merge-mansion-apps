using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;
using System.Runtime.Serialization;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineLeaderboardConfigInfo : IGameConfigData<MysteryMachineLeaderboardConfigId>, IGameConfigData, IHasGameConfigKey<MysteryMachineLeaderboardConfigId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineLeaderboardConfigId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<MetaRef<MysteryMachineLeaderboardTopRankingRewardInfo>> TopRankingRewardRefs { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<MetaRef<MysteryMachineLeaderboardPercentileRankingRewardInfo>> PercentileRankingRewardRefs { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaDuration BecomeAvailableDelay { get; set; }

        [IgnoreDataMember]
        public int TopRankingCount { get; }

        public MysteryMachineLeaderboardConfigInfo()
        {
        }

        public MysteryMachineLeaderboardConfigInfo(MysteryMachineLeaderboardConfigId configKey, List<MetaRef<MysteryMachineLeaderboardTopRankingRewardInfo>> topRankingRewardRefs, List<MetaRef<MysteryMachineLeaderboardPercentileRankingRewardInfo>> percentileRankingRewardRefs, MetaDuration becomeAvailableDelay)
        {
        }
    }
}
using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;
using Metaplay.Core.Player;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineLeaderboardRewardSource : IConfigItemSource<MysteryMachineLeaderboardRewardInfo, MysteryMachineLeaderboardRewardId>, IGameConfigSourceItem<MysteryMachineLeaderboardRewardId, MysteryMachineLeaderboardRewardInfo>, IHasGameConfigKey<MysteryMachineLeaderboardRewardId>
    {
        public MysteryMachineLeaderboardRewardId ConfigKey { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }
        private List<PlayerSegmentId> RewardSegment { get; set; }

        public MysteryMachineLeaderboardRewardSource()
        {
        }
    }
}
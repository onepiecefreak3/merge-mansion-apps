using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Metaplay.Core.Player;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class SoloMilestoneMilestonesInfo : IGameConfigData<SoloMilestoneMilestonesId>, IGameConfigData, IHasGameConfigKey<SoloMilestoneMilestonesId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public SoloMilestoneMilestonesId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Requirement { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<PlayerSegmentId> RewardSegment { get; set; }

        public SoloMilestoneMilestonesInfo()
        {
        }

        public SoloMilestoneMilestonesInfo(SoloMilestoneMilestonesId configKey, int requirement, List<PlayerReward> rewards, List<PlayerSegmentId> rewardSegment)
        {
        }
    }
}
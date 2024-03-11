using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Rewards;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class ProgressionEventStreakRewards : IGameConfigData<ProgressionEventStreakId>, IGameConfigData, IHasGameConfigKey<ProgressionEventStreakId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ProgressionEventStreakId Id { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int PurchaseCount { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerReward> Rewards { get; set; }
        public ProgressionEventStreakId ConfigKey => Id;

        public ProgressionEventStreakRewards()
        {
        }

        public ProgressionEventStreakRewards(ProgressionEventStreakId id, int purchaseCount, List<PlayerReward> rewards)
        {
        }
    }
}
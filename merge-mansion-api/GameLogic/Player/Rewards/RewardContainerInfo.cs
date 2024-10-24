using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace GameLogic.Player.Rewards
{
    [MetaSerializable]
    public class RewardContainerInfo : IGameConfigData<RewardContainerId>, IGameConfigData, IHasGameConfigKey<RewardContainerId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public RewardContainerId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string PoolTag { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string SkinName { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private string OverrideLocalizationRewardContainerId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int MinAmount { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int MaxAmount { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public List<RewardContainerItem> Items { get; set; }

        public RewardContainerInfo()
        {
        }

        public RewardContainerInfo(RewardContainerId configKey, string poolTag, string skinName, string overrideLocalizationRewardContainerId, int minAmount, int maxAmount, List<RewardContainerItem> items)
        {
        }
    }
}
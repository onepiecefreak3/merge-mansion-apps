using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.ConfigPrefabs;

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

        [MetaMember(8, (MetaMemberFlags)0)]
        public ConfigAssetPackId ModelId { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public bool UseIconLibrary { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public string SfxClose { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public string SfxOpen { get; set; }

        public RewardContainerInfo(RewardContainerId configKey, string poolTag, string skinName, string overrideLocalizationRewardContainerId, int minAmount, int maxAmount, List<RewardContainerItem> items, ConfigAssetPackId modelId, bool useIconLibrary, string sfxClose, string sfxOpen)
        {
        }
    }
}
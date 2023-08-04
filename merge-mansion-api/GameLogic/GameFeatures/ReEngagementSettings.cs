using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using GameLogic.Player.Requirements;
using GameLogic.Player.Rewards;

namespace GameLogic.GameFeatures
{
    [MetaSerializable]
    public class ReEngagementSettings : IGameConfigData<ReEngagementSettingsId>, IGameConfigData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ReEngagementSettingsId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public bool Enabled { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private List<PlayerRequirement> PlayerRequirements { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private List<PlayerReward> Rewards { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        private List<int> ItemsToSell { get; set; }

        public ReEngagementSettings()
        {
        }

        public ReEngagementSettings(ReEngagementSettingsId configKey, bool enabled, IEnumerable<PlayerRequirement> playerRequirements, IEnumerable<PlayerReward> playerRewards, IEnumerable<int> itemsToSell)
        {
        }
    }
}
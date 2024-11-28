using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Metaplay.Core.Config;
using Metaplay.Core.Model;

namespace GameLogic.Codex
{
    [MetaSerializable]
    public class CodexDiscoveryRewardInfo : IGameConfigData<CodexDiscoveryRewardId>, IGameConfigData, IHasGameConfigKey<CodexDiscoveryRewardId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public CodexDiscoveryRewardId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public PlayerReward DiscoveryCompletionReward { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerReward> DiscoveryRewards { get; set; }

        public CodexDiscoveryRewardInfo()
        {
        }

        public CodexDiscoveryRewardInfo(CodexDiscoveryRewardId configKey, PlayerReward discoveryCompletionReward, List<PlayerReward> discoveryRewards)
        {
        }
    }
}
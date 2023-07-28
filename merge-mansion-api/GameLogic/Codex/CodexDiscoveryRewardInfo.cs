using System.Collections.Generic;
using GameLogic.Player.Rewards;
using Metaplay.Core.Config;
using Metaplay.Core.Model;

namespace GameLogic.Codex
{
    [MetaSerializable]
    public class CodexDiscoveryRewardInfo : IGameConfigData<CodexDiscoveryRewardId>
    {
        [MetaMember(1, 0)]
        public CodexDiscoveryRewardId ConfigKey { get; set; }
        [MetaMember(2, 0)]
        public PlayerReward DiscoveryCompletionReward { get; set; }
        [MetaMember(3, 0)]
        public List<PlayerReward> DiscoveryRewards { get; set; }
	}
}

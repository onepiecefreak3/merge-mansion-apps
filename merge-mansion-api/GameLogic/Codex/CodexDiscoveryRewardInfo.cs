using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Player.Rewards;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Codex
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

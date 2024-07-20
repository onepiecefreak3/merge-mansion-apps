using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace GameLogic.Codex
{
    public class CodexDiscoveryRewardSource : IConfigItemSource<CodexDiscoveryRewardInfo, CodexDiscoveryRewardId>, IGameConfigSourceItem<CodexDiscoveryRewardId, CodexDiscoveryRewardInfo>, IHasGameConfigKey<CodexDiscoveryRewardId>
    {
        public CodexDiscoveryRewardId ConfigKey { get; set; }
        private string CompletionRewardType { get; set; }
        private string CompletionRewardId { get; set; }
        private string CompletionRewardAux0 { get; set; }
        private string CompletionRewardAux1 { get; set; }
        private int CompletionRewardAmount { get; set; }
        private List<string> RewardType { get; set; }
        private List<string> RewardId { get; set; }
        private List<string> RewardAux0 { get; set; }
        private List<string> RewardAux1 { get; set; }
        private List<int> RewardAmount { get; set; }

        public CodexDiscoveryRewardSource()
        {
        }
    }
}
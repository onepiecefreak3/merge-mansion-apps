using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;
using GameLogic.Codex;

namespace GameLogic.MergeChains
{
    public class MergeChainSource : IConfigItemSource<MergeChainDefinition, MergeChainId>, IGameConfigSourceItem<MergeChainId, MergeChainDefinition>, IHasGameConfigKey<MergeChainId>
    {
        public MergeChainId ConfigKey { get; set; }
        private List<string> Item { get; set; }
        private List<string> FallbackItem { get; set; }
        private CodexCategoryId CodexCategory { get; set; }
        private CodexDiscoveryRewardId DiscoveryReward { get; set; }
        private string CompletionSfx { get; set; }
        private string OverrideMergeChainSfx { get; set; }
        private int? InitialLevel { get; set; }
        private int? UnsellableUntilPlayerLevel { get; set; }
        private int? ShowSellConfirmationUntilPlayerLevel { get; set; }

        public MergeChainSource()
        {
        }
    }
}
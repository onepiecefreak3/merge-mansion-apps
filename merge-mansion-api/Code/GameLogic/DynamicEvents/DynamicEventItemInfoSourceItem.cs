using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using GameLogic.MergeChains;

namespace Code.GameLogic.DynamicEvents
{
    public class DynamicEventItemInfoSourceItem : IConfigItemSource<DynamicEventItemInfo, DynamicEventItemId>, IGameConfigSourceItem<DynamicEventItemId, DynamicEventItemInfo>, IHasGameConfigKey<DynamicEventItemId>
    {
        public DynamicEventItemId ConfigKey { get; set; }
        private string Item { get; set; }
        private MergeChainId MergeChain { get; set; }
        private int LevelNumber { get; set; }
        private int TotalToLvl1 { get; set; }
        private int[] DefaultValue { get; set; }
        private int[] DifficultyValue { get; set; }
        private int RewardPoints { get; set; }

        public DynamicEventItemInfoSourceItem()
        {
        }
    }
}
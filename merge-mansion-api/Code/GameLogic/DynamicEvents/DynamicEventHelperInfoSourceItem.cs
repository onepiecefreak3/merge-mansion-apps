using Code.GameLogic.Config;
using Metaplay.Core.Config;
using GameLogic.MergeChains;
using Metaplay.Core.Math;

namespace Code.GameLogic.DynamicEvents
{
    public class DynamicEventHelperInfoSourceItem : IConfigItemSource<DynamicEventHelperInfo, DynamicEventHelperId>, IGameConfigSourceItem<DynamicEventHelperId, DynamicEventHelperInfo>, IHasGameConfigKey<DynamicEventHelperId>
    {
        public DynamicEventHelperId ConfigKey { get; set; }
        private MergeChainId MergeChainB { get; set; }
        private MergeChainId MergeChain { get; set; }
        private F32 AmountLvl1 { get; set; }

        public DynamicEventHelperInfoSourceItem()
        {
        }
    }
}
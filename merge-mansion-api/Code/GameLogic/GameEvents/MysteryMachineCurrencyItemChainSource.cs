using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineCurrencyItemChainSource : IConfigItemSource<MysteryMachineCurrencyItemChainInfo, MysteryMachineCurrencyItemChainId>, IGameConfigSourceItem<MysteryMachineCurrencyItemChainId, MysteryMachineCurrencyItemChainInfo>, IHasGameConfigKey<MysteryMachineCurrencyItemChainId>
    {
        public MysteryMachineCurrencyItemChainId ConfigKey { get; set; }
        private List<MetaRef<MysteryMachineCurrencyItemInfo>> Items { get; set; }

        public MysteryMachineCurrencyItemChainSource()
        {
        }
    }
}
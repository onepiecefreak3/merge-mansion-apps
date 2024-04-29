using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineCurrencyItemChainInfo : IGameConfigData<MysteryMachineCurrencyItemChainId>, IGameConfigData, IHasGameConfigKey<MysteryMachineCurrencyItemChainId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineCurrencyItemChainId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public List<MetaRef<MysteryMachineCurrencyItemInfo>> ItemRefs { get; set; }

        public MysteryMachineCurrencyItemChainInfo()
        {
        }

        public MysteryMachineCurrencyItemChainInfo(MysteryMachineCurrencyItemChainId configKey, List<MetaRef<MysteryMachineCurrencyItemInfo>> itemRefs)
        {
        }
    }
}
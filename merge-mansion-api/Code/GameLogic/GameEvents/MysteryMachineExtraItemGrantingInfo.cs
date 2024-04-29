using Metaplay.Core.Model;
using Metaplay.Core.Config;
using GameLogic.MergeChains;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Player.Items;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineExtraItemGrantingInfo : IGameConfigData<MysteryMachineExtraItemGrantingId>, IGameConfigData, IHasGameConfigKey<MysteryMachineExtraItemGrantingId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineExtraItemGrantingId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MergeChainId ChainId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<MetaRef<ItemDefinition>> ItemRefs { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public List<int> ExtraItemAmounts { get; set; }

        public MysteryMachineExtraItemGrantingInfo()
        {
        }

        public MysteryMachineExtraItemGrantingInfo(MysteryMachineExtraItemGrantingId configKey, MergeChainId chainId, List<MetaRef<ItemDefinition>> itemRefs, List<int> extraItemAmounts)
        {
        }
    }
}
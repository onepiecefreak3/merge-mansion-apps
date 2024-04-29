using Code.GameLogic.Config;
using Metaplay.Core.Config;
using GameLogic.MergeChains;
using System.Collections.Generic;
using System;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineExtraItemGrantingSource : IConfigItemSource<MysteryMachineExtraItemGrantingInfo, MysteryMachineExtraItemGrantingId>, IGameConfigSourceItem<MysteryMachineExtraItemGrantingId, MysteryMachineExtraItemGrantingInfo>, IHasGameConfigKey<MysteryMachineExtraItemGrantingId>
    {
        public MysteryMachineExtraItemGrantingId ConfigKey { get; set; }
        public MergeChainId ChainId { get; set; }
        private List<string> ItemId { get; set; }
        private List<int> ExtraItemCount { get; set; }

        public MysteryMachineExtraItemGrantingSource()
        {
        }
    }
}
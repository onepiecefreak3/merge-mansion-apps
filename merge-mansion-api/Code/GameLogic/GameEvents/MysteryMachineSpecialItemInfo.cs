using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineSpecialItemInfo : IGameConfigData<MysteryMachineSpecialItemItemId>, IGameConfigData, IHasGameConfigKey<MysteryMachineSpecialItemItemId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineSpecialItemItemId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int ItemId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public List<MysteryMachineSpecialityType> SpecialityType { get; set; }

        public MysteryMachineSpecialItemInfo()
        {
        }

        public MysteryMachineSpecialItemInfo(MysteryMachineSpecialItemItemId configKey, int itemId, List<MysteryMachineSpecialityType> specialityType)
        {
        }
    }
}
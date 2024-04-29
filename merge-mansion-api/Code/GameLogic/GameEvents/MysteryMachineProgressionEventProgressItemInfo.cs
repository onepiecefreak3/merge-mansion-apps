using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineProgressionEventProgressItemInfo : IGameConfigData<MysteryMachineProgressionEventProgressItemId>, IGameConfigData, IHasGameConfigKey<MysteryMachineProgressionEventProgressItemId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineProgressionEventProgressItemId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        public MysteryMachineProgressionEventProgressItemInfo()
        {
        }

        public MysteryMachineProgressionEventProgressItemInfo(MysteryMachineProgressionEventProgressItemId configKey, int amount)
        {
        }
    }
}